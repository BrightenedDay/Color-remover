using System.ComponentModel;

namespace Color_remover
{
    public delegate void OnSafeKeyPress(object sender, SafeKeyPressEventArgs e);

    public class ValueTextbox : TextBox
    {
        private ushort maxValue = 255;

        [Category("Key")]
        [Browsable(true)]
        public event OnSafeKeyPress? OnSafeKeyPress;

        [Category("Behavior")]
        public ushort MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            ushort value;
            ushort.TryParse(Text + e.KeyChar, out value);

            if (value > maxValue)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Back || e.KeyChar == '\b')
            {
                if (Text.Length > 0)
                    OnSafeKeyPress?.Invoke(this, new SafeKeyPressEventArgs(Text.Remove(Text.Length - 1)));
            }
            else if (Text.Length == 3 || (Text + e.KeyChar).Length == 0)
                e.Handled = true;
            else
                OnSafeKeyPress?.Invoke(this, new SafeKeyPressEventArgs(Text + e.KeyChar));
        }
    }
}