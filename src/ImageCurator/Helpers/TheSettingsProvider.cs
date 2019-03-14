namespace ImageCurator.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ImageCurator.Resources;
    using ImageCurator.CustomEvents;

    public class TheSettingsProvider
    {
        private ApplicationSettingsBase settingBase = Properties.Settings.Default;
        private HashSet<Tuple<string, Type, object>> appSettings = new HashSet<Tuple<string, Type, object>>();

        public TheSettingsProvider()
        {

        }

        public void Save()
        {
            
        }
    }
}
