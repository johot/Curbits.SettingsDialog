using System;

namespace Curbits.SettingsDialog
{
    public class SectionHeaderAttribute : Attribute
    {
        public SectionHeaderAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}