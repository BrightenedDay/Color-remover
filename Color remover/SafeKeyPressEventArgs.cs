namespace Color_remover
{
    public class SafeKeyPressEventArgs
    {
        public SafeKeyPressEventArgs(string safeText)
        {
            SafeText = safeText;
        }

        public string SafeText { get; }
    }
}