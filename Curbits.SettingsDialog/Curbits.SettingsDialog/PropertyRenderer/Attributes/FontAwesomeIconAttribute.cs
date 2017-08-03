using System;
using FontAwesome.WPF;

namespace Curbits.SettingsDialog
{
    public class FontAwesomeIconAttribute : Attribute
    {
        public FontAwesomeIconAttribute(FontAwesomeIcon fontAwesomeIcon)
        {
            FontAwesomeIcon = fontAwesomeIcon;
        }

        public FontAwesomeIcon FontAwesomeIcon { get; set; }
    }
}