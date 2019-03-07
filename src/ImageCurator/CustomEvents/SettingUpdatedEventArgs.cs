namespace ImageCurator.CustomEvents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SettingUpdatedEventArgs : EventArgs
    {
        public SettingUpdatedEventArgs(string settingName, string newValue)
        {
            this._settingName = settingName;
            this._settingNewValue = newValue;
        }

        private string _settingName;
        private string _settingNewValue;

        public string SettingName
        {
            get
            {
                return _settingName;
            }
        }

        public string SettingValue
        {
            get
            {
                return _settingNewValue;
            }
        }
    }
}
