using System;

namespace Curbits.SettingsDialog
{
    public class SpacingAttribute : Attribute
    {
        public SpacingAttribute(double spacingTop, double spacingBottom)
        {
            SpacingTop = spacingTop;
            SpacingBottom = spacingBottom;
        }

        public double SpacingTop { get; }
        public double SpacingBottom { get; }

    }
}