using System.Drawing.Imaging;

namespace Color_remover
{
    public partial class mainForm : Form
    {
        //////////// Parameters

        ushort limitRange = 220;

        //////////////

        ushort red = 255;
        ushort green = 255;
        ushort blue = 255;
        bool working = false;
        bool incomingCall = false;
        Color lastUsedColor = Color.White;
        Image? openedImage;
        Bitmap? bitmap = null;

        public mainForm()
        {
            InitializeComponent();
            colorPreview.BackColor = Color.FromArgb(255, red, green, blue);

            previewBox.BackgroundImage = CreateCheckerboardPattern(16);
            previewBox.Invalidate();

            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;

            tip.SetToolTip(autoBox, "Auto regenerate when any parameters change.\nMAY OR MAY NOT GIVE ERRORS EVERY SO OFTEN.");
            tip.SetToolTip(colorRange, "Used for removing similar colors.");
        }

        Bitmap CreateCheckerboardPattern(int squareSize)
        {
            int patternSize = squareSize * 2;
            Bitmap bitmap = new Bitmap(patternSize, patternSize);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);

                using (Brush whiteBrush = new SolidBrush(Color.White))
                using (Brush grayBrush = new SolidBrush(Color.LightGray))
                {
                    // Draw the checkerboard pattern
                    for (int y = 0; y < patternSize; y += squareSize)
                    {
                        for (int x = 0; x < patternSize; x += squareSize)
                        {
                            Brush brush = ((x / squareSize + y / squareSize) % 2 == 0) ? whiteBrush : grayBrush;
                            g.FillRectangle(brush, x, y, squareSize, squareSize);
                        }
                    }
                }
            }

            return bitmap;
        }

        void Regenerate()
        {
            bool ignoreIncoming = false;

            if (bitmap != null)
                bitmap.Dispose();

            if (openedImage != null)
            {
                short colorRan = (short)colorRange.Value;

                Task.Run(() =>
                {
                    try
                    {
                        SetTitle("Color Remover (working)");

                        short Rr = (short)red;
                        short Rg = (short)green;
                        short Rb = (short)blue;
                        short Rl = (short)limitRange;

                        bitmap = new Bitmap(openedImage);

                        for (int y = 0; bitmap.Height > y; y++)
                        {
                            for (int x = 0; bitmap.Width > x; x++)
                            {
                                Color col = bitmap.GetPixel(x, y);

                                // Remove obvious matching colors
                                if (colorRan > 0)
                                {
                                    if ((col.R <= Rr + colorRan && col.R >= Rr - colorRan)
                                    && (col.G <= Rg + colorRan && col.G >= Rg - colorRan)
                                    && (col.B <= Rb + colorRan && col.B >= Rb - colorRan))
                                    {
                                        bitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
                                        continue;
                                    }
                                }
                                else
                                {
                                    if (col.R == Rr && col.G == Rg && col.B == Rb)
                                    {
                                        bitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
                                        continue;
                                    }
                                }


                                // Semi-fix for alpha

                                if (col.A < 180)
                                    continue;

                                ushort red = col.R;
                                ushort green = col.G;
                                ushort blue = col.B;
                                ushort alpha = 255;

                                if (InRange(red, green, blue, Rr, Rg, Rb, Rl))
                                {
                                    for (byte i = 0; i < 255; i++)
                                    {
                                        red -= 1;
                                        green -= 1;
                                        blue -= 1;
                                        alpha -= 1;
                                        if (!InRange(red, green, blue, Rr, Rg, Rb, Rl))
                                            break;
                                    }
                                }

                                red = Clamp(red, 0, 255);
                                green = Clamp(green, 0, 255);
                                blue = Clamp(blue, 0, 255);
                                alpha = Clamp(alpha, 0, 255);

                                bitmap.SetPixel(x, y, Color.FromArgb(alpha, red, green, blue));
                            }
                        }

                        if (previewBox.InvokeRequired)
                        {
                            previewBox.Invoke(() => { previewBox.Image = bitmap; previewBox.Invalidate(); });
                        }
                        else
                        {
                            previewBox.Image = bitmap;
                            previewBox.Invalidate();
                        }

                    }
                    catch (Exception ex)
                    {
                        ignoreIncoming = true;
                        MessageBox.Show($"An error occurred during generation. ErrMes: {ex.Message}", "Issue with generating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    SetTitle("Color Remover");

                    working = false;
                });
            }

            if (!working && incomingCall && !ignoreIncoming)
            {
                incomingCall = false;
                Regenerate();
            }
        }

        bool InRange(ushort red, ushort green, ushort blue, short Rr, short Rg, short Rb, short range)
        {
            if (
                red < Rr + range && red > Rg - range
                && green < Rg + range && green > Rg - range
                && blue < Rb + range && blue > Rb - range
                ) return true;
            return false;
        }

        ushort Clamp(ushort value, ushort min, ushort max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            return value;
        }

        void SetTitle(string title)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(() => { this.Text = title; });
            }
            else
            {
                this.Text = title;
            }
        }

        void TriggerGeneration()
        {
            colorPreview.BackColor = Color.FromArgb(255, red, green, blue);

            if (!working && autoBox.Checked)
            {
                working = true;
                Regenerate();
            }
            else if (working && autoBox.Checked)
                incomingCall = true;
        }


        #region Window Button Functions

        void Rcolor_OnSafeKeyPress(object sender, SafeKeyPressEventArgs e)
        {
            if (e.SafeText.Length > 0)
            {
                ushort value;
                ushort.TryParse(e.SafeText, out value);

                red = Clamp(value, 0, 255);
            }
            else
                red = 0;

            TriggerGeneration();
        }

        void Gcolor_OnSafeKeyPress(object sender, SafeKeyPressEventArgs e)
        {
            if (e.SafeText.Length > 0)
            {
                ushort value;
                ushort.TryParse(e.SafeText, out value);

                green = Clamp(value, 0, 255);
            }
            else
                green = 0;

            TriggerGeneration();
        }

        void Bcolor_OnSafeKeyPress(object sender, SafeKeyPressEventArgs e)
        {
            if (e.SafeText.Length > 0)
            {
                ushort value;
                ushort.TryParse(e.SafeText, out value);

                blue = Clamp(value, 0, 255);
            }
            else
                blue = 0;

            TriggerGeneration();
        }

        void rangeBox_OnSafeKeyPress(object sender, SafeKeyPressEventArgs e)
        {
            if (e.SafeText.Length > 0)
            {
                ushort value;
                ushort.TryParse(e.SafeText, out value);

                limitRange = Clamp(value, 0, 255);
            }
            else
                limitRange = 0;

            TriggerGeneration();
        }

        void regenButton_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                working = true;
                Regenerate();
            }
        }

        void colorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            col.FullOpen = true;
            col.Color = lastUsedColor;

            if (col.ShowDialog() == DialogResult.OK)
            {
                lastUsedColor = col.Color;
                red = col.Color.R;
                Rcolor.Text = red.ToString();
                green = col.Color.G;
                Gcolor.Text = green.ToString();
                blue = col.Color.B;
                Bcolor.Text = blue.ToString();
                TriggerGeneration();
            }
        }

        void openImage_Click(object sender, EventArgs e)
        {
            if (working)
                return;

            OpenFileDialog fileDial = new OpenFileDialog();
            fileDial.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png";

            if (fileDial.ShowDialog() == DialogResult.OK && File.Exists(fileDial.FileName))
            {
                using (FileStream stream = new FileStream(fileDial.FileName, FileMode.Open, FileAccess.Read))
                {
                    openedImage = Image.FromStream(stream);
                }

                previewBox.Image = openedImage;
                previewBox.Invalidate();
                TriggerGeneration();
            }
        }

        void saveImage_Click(object sender, EventArgs e)
        {
            if (openedImage != null && previewBox.Image != null)
            {
                if (working)
                    return;

                try
                {
                    SaveFileDialog fileDial = new SaveFileDialog();
                    fileDial.Filter = "PNG|*.png|JPEG|*.jpeg|JPG|*.jpg|Bitmap|*.bmp";

                    if (fileDial.ShowDialog() == DialogResult.OK)
                    {
                        ImageFormat format = ImageFormat.Png;

                        switch (Path.GetExtension(fileDial.FileName).ToLower())
                        {
                            case "jpeg":
                                format = ImageFormat.Jpeg;
                                break;

                            case "jpg":
                                format = ImageFormat.Jpeg;
                                break;

                            case "bmp":
                                format = ImageFormat.Bmp;
                                break;
                        }

                        previewBox.Image.Save(fileDial.FileName, format);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred trying to save image: {ex.Message}", "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        async void clipboardButton_Click(object sender, EventArgs e)
        {
            if (openedImage != null && previewBox.Image != null && !working)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    DataObject dataObject = new DataObject();

                    previewBox.Image.Save(stream, ImageFormat.Png);

                    Clipboard.SetData("PNG", stream);
                }

                clipboardButton.Text = "Copied!";
                await Task.Delay(800);
                clipboardButton.Text = "Copy Result";
            }
        }

        void autoBox_CheckedChanged(object sender, EventArgs e)
        {
            TriggerGeneration();
        }

        void colorRange_ValueChanged(object sender, EventArgs e)
        {
            colRangeLabel.Text = $"Color Range ({colorRange.Value})";
            TriggerGeneration();
        }

        #endregion
    }
}