namespace ImageCurator.Helpers
{
    using System.Collections.Generic;

    using ImageCurator.Resources;
    using ImageCurator.CustomEvents;

    using Newtonsoft.Json;

    /// <summary>
    /// Wraps the retrieval/saving of user-specific settings in the application so that the application is agnostic to whatever framework
    /// is used to actually store/retrieve those settings at runtime.
    /// 
    /// Currently the wrapper uses .NET's Application Settings provider, with a single setting, which is a Dictionary serialized with JSON.</string>.
    /// </summary>
    public class UserSettingsProvider
    {
        private Constants appConstants = new Constants();
        private Properties.Settings settingBase = Properties.Settings.Default;

        public delegate void SettingUpdatedEventHandler(object sender, SettingUpdatedEventArgs args);

        private Dictionary<string, object> appSettings = new Dictionary<string, object>();


        public UserSettingsProvider()
        {
        }

        /// <summary>
        /// Gets or sets the root image path that the application will do work upon.
        /// </summary>
        /// <remarks>Still uncertain whether app settings should be managed with explicit properties like these, using
        /// so-called Generic settings for temporary settings or settings of no interest to the user, or if all settings
        /// might as well use the latter framework.</remarks>
        public string RootPath
        {
            get
            {
                var rootPath = this.GetGenericSetting(Constants.Configuration.ROOT_IMAGE_PATH);
                if (rootPath != null)
                {
                    return (string)rootPath;
                }
                return null;
            }
            set
            {
                this.SetGenericSetting(Constants.Configuration.ROOT_IMAGE_PATH, value);
            }
        }

        public void Initialize()
        {
            this.settingBase.Upgrade();
            this.settingBase.Reload();

            this.initialLoadSettings();
        }


        public void SetGenericSetting(string settingName, object settingValue)
        {
            // Update data structure
            this.appSettings[settingName] = settingValue;

            // Raise SettingUpdated event
            var args = new SettingUpdatedEventArgs(settingName, settingValue);
            this.OnSettingUpdated(args);
        }

        public object GetGenericSetting(string settingName)
        {
            return this.getSetting(settingName);
        }

        public void Save()
        {
            this.saveSettings();
        }

        private object getSetting(string settingName)
        {
            if (this.appSettings.ContainsKey(settingName))
            {
                return this.appSettings[settingName];
            }
            return null;
        }

        private string generateJson()
        {
            var json = JsonConvert.SerializeObject(this.appSettings);

            return json;
        }

        private void initialLoadSettings()
        {
            this.loadSettings();
        }

        private void loadSettings()
        {
            var json = this.settingBase.AppSettings;
            var settingsObject = JsonConvert.DeserializeObject(json, typeof(Dictionary<string, object>));
            var settingsDict = (Dictionary<string, object>)settingsObject;

            if (settingsDict != null)
            {
                foreach (var key in new List<string>(settingsDict.Keys))
                {
                    this.SetGenericSetting(key, settingsDict[key]);
                }
            }
        }

        private void saveSettings()
        {
            var toSave = this.generateJson();
            this.settingBase.AppSettings = toSave;

            this.settingBase.Save();
        }

        public event SettingUpdatedEventHandler SettingUpdated;

        protected virtual void OnSettingUpdated(SettingUpdatedEventArgs e)
        {
            var handler = SettingUpdated;
            handler?.Invoke(this, e);
        }
    }
}
