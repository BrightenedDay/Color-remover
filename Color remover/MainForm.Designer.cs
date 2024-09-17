namespace Color_remover
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            previewBox = new PictureBox();
            regenButton = new Button();
            autoBox = new CheckBox();
            colorPreview = new PictureBox();
            Rcolor = new ValueTextbox();
            Gcolor = new ValueTextbox();
            Bcolor = new ValueTextbox();
            colorPicker = new Button();
            openImage = new Button();
            saveImage = new Button();
            rangeBox = new ValueTextbox();
            label1 = new Label();
            label2 = new Label();
            clipboardButton = new Button();
            colorRange = new TrackBar();
            colRangeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorRange).BeginInit();
            SuspendLayout();
            // 
            // previewBox
            // 
            previewBox.Anchor = AnchorStyles.Top;
            previewBox.BackColor = Color.Transparent;
            previewBox.BorderStyle = BorderStyle.Fixed3D;
            previewBox.Location = new Point(110, 20);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(250, 250);
            previewBox.SizeMode = PictureBoxSizeMode.Zoom;
            previewBox.TabIndex = 0;
            previewBox.TabStop = false;
            // 
            // regenButton
            // 
            regenButton.Anchor = AnchorStyles.None;
            regenButton.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            regenButton.Location = new Point(153, 276);
            regenButton.Name = "regenButton";
            regenButton.Size = new Size(154, 41);
            regenButton.TabIndex = 1;
            regenButton.Text = "Regenerate";
            regenButton.UseVisualStyleBackColor = true;
            regenButton.Click += regenButton_Click;
            // 
            // autoBox
            // 
            autoBox.Anchor = AnchorStyles.None;
            autoBox.AutoSize = true;
            autoBox.Location = new Point(313, 285);
            autoBox.Name = "autoBox";
            autoBox.Size = new Size(63, 24);
            autoBox.TabIndex = 2;
            autoBox.Text = "Auto";
            autoBox.UseVisualStyleBackColor = true;
            autoBox.CheckedChanged += autoBox_CheckedChanged;
            // 
            // colorPreview
            // 
            colorPreview.Anchor = AnchorStyles.None;
            colorPreview.BackColor = Color.Red;
            colorPreview.BorderStyle = BorderStyle.Fixed3D;
            colorPreview.Location = new Point(212, 323);
            colorPreview.Name = "colorPreview";
            colorPreview.Size = new Size(40, 40);
            colorPreview.TabIndex = 4;
            colorPreview.TabStop = false;
            // 
            // Rcolor
            // 
            Rcolor.Anchor = AnchorStyles.None;
            Rcolor.Location = new Point(168, 369);
            Rcolor.MaxLength = 3;
            Rcolor.MaxValue = (ushort)255;
            Rcolor.Name = "Rcolor";
            Rcolor.PlaceholderText = "Red 0-255";
            Rcolor.Size = new Size(125, 27);
            Rcolor.TabIndex = 5;
            Rcolor.Text = "255";
            Rcolor.TextAlign = HorizontalAlignment.Center;
            Rcolor.WordWrap = false;
            Rcolor.OnSafeKeyPress += Rcolor_OnSafeKeyPress;
            // 
            // Gcolor
            // 
            Gcolor.Anchor = AnchorStyles.None;
            Gcolor.Location = new Point(168, 402);
            Gcolor.MaxLength = 3;
            Gcolor.MaxValue = (ushort)255;
            Gcolor.Name = "Gcolor";
            Gcolor.PlaceholderText = "Green 0-255";
            Gcolor.Size = new Size(125, 27);
            Gcolor.TabIndex = 6;
            Gcolor.Text = "255";
            Gcolor.TextAlign = HorizontalAlignment.Center;
            Gcolor.WordWrap = false;
            Gcolor.OnSafeKeyPress += Gcolor_OnSafeKeyPress;
            // 
            // Bcolor
            // 
            Bcolor.Anchor = AnchorStyles.None;
            Bcolor.Location = new Point(168, 435);
            Bcolor.MaxLength = 3;
            Bcolor.MaxValue = (ushort)255;
            Bcolor.Name = "Bcolor";
            Bcolor.PlaceholderText = "Blue 0-255";
            Bcolor.Size = new Size(125, 27);
            Bcolor.TabIndex = 7;
            Bcolor.Text = "255";
            Bcolor.TextAlign = HorizontalAlignment.Center;
            Bcolor.WordWrap = false;
            Bcolor.OnSafeKeyPress += Bcolor_OnSafeKeyPress;
            // 
            // colorPicker
            // 
            colorPicker.Location = new Point(299, 400);
            colorPicker.Name = "colorPicker";
            colorPicker.Size = new Size(100, 29);
            colorPicker.TabIndex = 8;
            colorPicker.Text = "Color Picker";
            colorPicker.UseVisualStyleBackColor = true;
            colorPicker.Click += colorPicker_Click;
            // 
            // openImage
            // 
            openImage.Location = new Point(10, 20);
            openImage.Name = "openImage";
            openImage.Size = new Size(94, 29);
            openImage.TabIndex = 9;
            openImage.Text = "Open...";
            openImage.UseVisualStyleBackColor = true;
            openImage.Click += openImage_Click;
            // 
            // saveImage
            // 
            saveImage.Location = new Point(10, 55);
            saveImage.Name = "saveImage";
            saveImage.Size = new Size(94, 29);
            saveImage.TabIndex = 10;
            saveImage.Text = "Save as...";
            saveImage.UseVisualStyleBackColor = true;
            saveImage.Click += saveImage_Click;
            // 
            // rangeBox
            // 
            rangeBox.Anchor = AnchorStyles.None;
            rangeBox.Location = new Point(22, 369);
            rangeBox.MaxLength = 3;
            rangeBox.MaxValue = (ushort)255;
            rangeBox.Name = "rangeBox";
            rangeBox.PlaceholderText = "Alpha 0-255";
            rangeBox.Size = new Size(125, 27);
            rangeBox.TabIndex = 11;
            rangeBox.Text = "220";
            rangeBox.TextAlign = HorizontalAlignment.Center;
            rangeBox.WordWrap = false;
            rangeBox.OnSafeKeyPress += rangeBox_OnSafeKeyPress;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 341);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 12;
            label1.Text = "Range (Alpha)";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(243, 480);
            label2.Name = "label2";
            label2.Size = new Size(239, 21);
            label2.TabIndex = 13;
            label2.Text = "Copyright © 2024 Sabastian. MIT";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // clipboardButton
            // 
            clipboardButton.Location = new Point(366, 20);
            clipboardButton.Name = "clipboardButton";
            clipboardButton.Size = new Size(99, 29);
            clipboardButton.TabIndex = 14;
            clipboardButton.Text = "Copy Result";
            clipboardButton.UseVisualStyleBackColor = true;
            clipboardButton.Click += clipboardButton_Click;
            // 
            // colorRange
            // 
            colorRange.Anchor = AnchorStyles.None;
            colorRange.Location = new Point(17, 435);
            colorRange.Maximum = 100;
            colorRange.Name = "colorRange";
            colorRange.Size = new Size(130, 56);
            colorRange.TabIndex = 15;
            colorRange.TickStyle = TickStyle.None;
            colorRange.ValueChanged += colorRange_ValueChanged;
            // 
            // colRangeLabel
            // 
            colRangeLabel.Anchor = AnchorStyles.None;
            colRangeLabel.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            colRangeLabel.Location = new Point(22, 407);
            colRangeLabel.Name = "colRangeLabel";
            colRangeLabel.Size = new Size(140, 25);
            colRangeLabel.TabIndex = 16;
            colRangeLabel.Text = "Color Range (0)";
            colRangeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(482, 500);
            Controls.Add(colRangeLabel);
            Controls.Add(colorRange);
            Controls.Add(clipboardButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rangeBox);
            Controls.Add(saveImage);
            Controls.Add(openImage);
            Controls.Add(colorPicker);
            Controls.Add(Bcolor);
            Controls.Add(Gcolor);
            Controls.Add(Rcolor);
            Controls.Add(colorPreview);
            Controls.Add(autoBox);
            Controls.Add(regenButton);
            Controls.Add(previewBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Color Remover";
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorRange).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox previewBox;
        private Button regenButton;
        private CheckBox autoBox;
        private PictureBox colorPreview;
        private ValueTextbox Rcolor;
        private ValueTextbox Gcolor;
        private ValueTextbox Bcolor;
        private Button colorPicker;
        private Button openImage;
        private Button saveImage;
        private ValueTextbox rangeBox;
        private Label label1;
        private Label label2;
        private Button clipboardButton;
        private TrackBar colorRange;
        private Label colRangeLabel;
    }
}
