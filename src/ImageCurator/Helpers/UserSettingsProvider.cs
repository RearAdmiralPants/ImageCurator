namespace ImageCurator.Helpers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

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

        private Constants appConstants = new Constants();
        private ApplicationSettingsBase settingBase = Properties.Settings.Default;

        public UserSettingsProvider()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            var allProperties = appConstants.GetAllSettingConstants();          // Can we do this static?
            var existProperties = new List<string>();
            this.settingBase.Reload();
            foreach (var propObj in this.settingBase.Properties)
            {
                var property = propObj as SettingsProperty;
                if (!(property is null))
                {
                    existProperties.Add(property.Name);
                }
            }

            foreach (var unsavedProperty in allProperties.Where(propName => !existProperties.Contains(propName)))
            {
                var newProp = new SettingsProperty(unsavedProperty);
                newProp.PropertyType = typeof(string);
                var newValue = new SettingsPropertyValue(newProp);

                this.settingBase.Properties.Add(newProp);
            }

            this.settingBase.Save();

            this.settingBase.Reload();
        }

        public string RootPath
        {
            get
            {
                return (string)this.settingBase[Constants.Configuration.ROOT_PATH];
            }
            set
            {
                this.SetSettingValue(Constants.Configuration.ROOT_PATH, value);
            }
        }

        private void SetSettingValue(string settingName, string settingValue)
        {
            var property = this.settingBase.Properties[settingName];
            var newValue = new SettingsPropertyValue(property);
            newValue.PropertyValue = settingValue;
                        

            // Raise updated event
            var args = new SettingUpdatedEventArgs(settingName, settingValue);
            this.OnSettingUpdated(args);
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
