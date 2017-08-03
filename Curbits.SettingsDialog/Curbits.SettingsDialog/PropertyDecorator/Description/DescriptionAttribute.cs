using System;

namespace Curbits.SettingsDialog
{
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}