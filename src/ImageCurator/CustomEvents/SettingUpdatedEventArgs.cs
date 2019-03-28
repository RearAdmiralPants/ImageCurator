namespace ImageCurator.CustomEvents
{
    using System;

    public class SettingUpdatedEventArgs : EventArgs
    {
        public SettingUpdatedEventArgs(string settingName, object newValue)
        {
            this._settingName = settingName;
            this._settingNewValue = newValue;
        }

        private string _settingName;
        private object _settingNewValue;

        public string SettingName
        {
            get
            {
                return _settingName;
            }
        }

        public object SettingValue
        {
            get
            {
                return _settingNewValue;
            }
        }
    }
}
