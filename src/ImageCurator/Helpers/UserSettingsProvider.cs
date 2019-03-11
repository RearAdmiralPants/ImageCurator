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

        /// <summary>
        /// Determines if a setting exists in the collection.
        /// </summary>
        /// <param name="settingName">The name of the estting.</param>
        /// <returns>A value indicating whether the setting exists in the collection.</returns>
        /// <remarks>Should only be used for testing purposes.</remarks>
        public bool SettingExists(string settingName)
        {
            return this.getCurrentProperties().Contains(settingName);
        }

        private void Initialize()
        {
            var allProperties = appConstants.GetAllSettingConstants();          // Can we do this static?
            this.settingBase.Reload();
            var existProperties = this.getCurrentProperties();

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

        private HashSet<string> getCurrentProperties()
        {
            var existProperties = new HashSet<string>();
            foreach (var propObj in this.settingBase.Properties)
            {
                var property = propObj as SettingsProperty;
                if (!(property is null))
                {
                    existProperties.Add(property.Name);
                }
            }

            return existProperties;
        }

        private void initializeNewSetting(string settingName)
        {
            var existProperties = this.getCurrentProperties();
            if (existProperties.Contains(settingName)) { return; }

            var newProp = new SettingsProperty(settingName);
            newProp.PropertyType = typeof(string);
            var newValue = new SettingsPropertyValue(newProp);

            this.settingBase.Properties.Add(newProp);

            this.settingBase.Save();

            this.settingBase.Reload();
        }

        public string RootPath
        {
            get
            {
                var shit = this.settingBase[Constants.Configuration.ROOT_PATH];
                return (string)this.settingBase[Constants.Configuration.ROOT_PATH];
            }
            set
            {
                this.setSettingValue(Constants.Configuration.ROOT_PATH, value);
            }
        }

        public void SetDynamicSetting(string settingName, string settingValue)
        {
            if (!this.getCurrentProperties().Contains(settingName))
            {
                this.initializeNewSetting(settingName);
            }

            this.setSettingValue(settingName, settingValue);
        }

        public string GetDynamicSetting(string settingName)
        {
            return (string)this.settingBase[settingName];
        }

        private void setSettingValue(string settingName, string settingValue)
        {
            var property = this.settingBase.Properties[settingName];
            var newValue = new SettingsPropertyValue(property);
            newValue.PropertyValue = settingValue;

            this.settingBase.Save();

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
