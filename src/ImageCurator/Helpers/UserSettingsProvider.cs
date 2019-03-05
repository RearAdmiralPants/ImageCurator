namespace ImageCurator.Helpers
{
    using ImageCurator.Resources;

    /// <summary>
    /// Wraps the retrieval/saving of user-specific settings in the application so that the application is agnostic to whatever framework
    /// is used to actually store/retrieve those settings at runtime.
    /// 
    /// Currently the wrapper uses .NET's Application Settings provider.
    /// </summary>
    public class UserSettingsProvider
    {
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
            Properties.Settings.Default[settingName] = settingValue;
        }

        private void ForceSave()
        {
            Properties.Settings.Default.Save();
        }

        private void ForceLoad()
        {
            Properties.Settings.Default.Reload();
        }
    }
}
