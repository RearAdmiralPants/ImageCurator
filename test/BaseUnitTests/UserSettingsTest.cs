namespace BaseUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ImageCurator.Resources;
    using ImageCurator.Helpers;

    [TestClass]
    public class UserSettingsTest
    {
        private UserSettingsProvider userProvider;

        public UserSettingsTest()
        {
            this.userProvider = new UserSettingsProvider();
        }

        [TestMethod]
        public void VerifyRandomSettingsNotCreated()
        {
            var randomSetting = "22039h5803298hg0298hg";

            Assert.IsNull(this.userProvider.GetGenericSetting(randomSetting));
        }

        [TestMethod]
        public void VerifyConstantSettingValue()
        {
            var settingValue = this.userProvider.GetGenericSetting(Constants.Configuration.ROOT_IMAGE_PATH);
            string currentRootPath = null;
            if (settingValue != null)
            {
                currentRootPath = (string)settingValue;
            }

            var newRootPath = "New Root Path";
            this.userProvider.SetGenericSetting(Constants.Configuration.ROOT_IMAGE_PATH, newRootPath);

            Assert.IsTrue((string)this.userProvider.GetGenericSetting(Constants.Configuration.ROOT_IMAGE_PATH) == newRootPath);

            if (!(currentRootPath is null))
            {
                this.userProvider.SetGenericSetting(Constants.Configuration.ROOT_IMAGE_PATH, currentRootPath);
            }
        }

        [TestMethod]
        public void VerifyDynamicSettingCreated()
        {
            var dynamicSetting = "2903jf0329hg0";
            int dynamicValue = 92;
            this.userProvider.SetGenericSetting(dynamicSetting, dynamicValue);

            var settingValue = this.userProvider.GetGenericSetting(dynamicSetting);
            var settingType = settingValue.GetType();
            Assert.IsInstanceOfType(settingValue, typeof(int));
            var settingInt = (int)settingValue;
            Assert.AreEqual(dynamicValue, settingInt);
        }

        [TestMethod]
        public void UserSettingsPersist()
        {
            var testSetting = "TestSettingPersist";
            var testValue = "TestSettingPersistValue";

            this.userProvider.SetGenericSetting(testSetting, testValue);
            this.userProvider.Save();

            var newProvider = new UserSettingsProvider();

            var testPersistence = (string)newProvider.GetGenericSetting(testSetting);

            Assert.IsNotNull(testPersistence);
            Assert.AreEqual(testValue, testPersistence);
        }
    }
}
