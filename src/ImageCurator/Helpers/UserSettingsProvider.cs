namespace ImageCurator.Helpers
{
    using ImageCurator.Resources;
    using ImageCurator.CustomEvents;

    /// <summary>
    /// Wraps the retrieval/saving of user-specific settings in the application so that the application is agnostic to whatever framework
    /// is used to actually store/retrieve those settings at runtime.
    /// 
    /// Currently the wrapper uses .NET's Application Settings provider.
    /// </summary>
    public class UserSettingsProvider
    {
        public delegate void SettingUpdatedEventHandler(object sender, SettingUpdatedEventArgs args);

        public string RootPath
        {
            get
            {
                return (string)Properties.Settings.Default[Constants.Configuration.ROOT_PATH];
            }
            set
            {
                this.SetSettingValue(Constants.Configuration.ROOT_PATH, value);
            }
        }

        private void SetSettingValue(string settingName, string settingValue)
        {
            if (!SettingsPropertyExists(settingName))
            {
                var prop = new System.Configuration.SettingsProperty(settingName);
                Properties.Settings.Default.Properties.Add(prop);
            }
            Properties.Settings.Default.Properties[settingName] = settingValue;
            

            // Raise updated event
            var args = new SettingUpdatedEventArgs(settingName, settingValue);
            this.OnSettingUpdated(args);
        }

        private bool SettingsPropertyExists(string settingName)
        {
            foreach (var property in Properties.Settings.Default.Properties)
            {
                if (property.ToString() == settingName)
                {
                    return true;
                }
            }
            return false;
        }

        private void ForceSave()
        {
            Properties.Settings.Default.Save();
        }

        private void ForceLoad()
        {
            Properties.Settings.Default.Reload();
        }

        public event SettingUpdatedEventHandler SettingUpdated;

        protected virtual void OnSettingUpdated(SettingUpdatedEventArgs e)
        {
            var handler = SettingUpdated;
            handler?.Invoke(this, e);
        }
    }
}
