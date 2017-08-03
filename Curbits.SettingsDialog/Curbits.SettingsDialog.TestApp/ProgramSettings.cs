using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FontAwesome.WPF;

namespace Curbits.SettingsDialog.TestApp
{
    public class ProgramSettings
    {
        public bool CanUserExit { get; set; } = true;

        [FontAwesomeIcon(FontAwesomeIcon.Android)]
        [Title("Whohoo")]
        public FirstPage FirstPage { get; set; } = new FirstPage();
        public SecondPage SecondPage { get; set; } = new SecondPage();
    }

    public class SecondPage
    {
        public bool CanUserExit { get; set; } = true;
    }

    public class FirstPage
    {
        [SectionHeader("Environment Settings")]
        [Title("hello hey!")]
        //[Description("This setting is very cool")]
        public bool ThisIsASetting { get; set; }

        public bool helloHiThereMrBister { get; set; }

        [Description("Aargh")]
        [Spacing(100.0d, 20.0d)]
        public bool areYouAPirte { get; set; }
    }
}
