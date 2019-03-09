namespace ImageCurator.Resources
{
    using System.Collections.Generic;
    public class Constants
    {
        public class Configuration
        {
            public const string ROOT_PATH = "Constants.Configuration.RootPath";
        }

        /// <summary>
        /// Stub method; will use reflection to determine all current configuration-related constants
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllSettingConstants()
        {
            var result = new List<string>();

            result.Add("Constants.Configuration.RootPath");
            result.Add("Test1");
            result.Add("Test2");

            return result;
        }
    }
}
