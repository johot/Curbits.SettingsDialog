using System;

namespace Curbits.SettingsDialog
{
    public class TitleAttribute : Attribute
    {
        public TitleAttribute(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
