namespace BaseUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ImageCurator.Resources;
    using ImageCurator.Helpers;

    [TestClass]
    public class UserSettingsTest
    {
        private OldUserSettingsProvider userProvider;

        public UserSettingsTest()
        {
            this.userProvider = new OldUserSettingsProvider();
        }

        [TestMethod]
        public void VerifyConstantsSettingCreation()
        {
            var curatorConstants = new Constants();

            Assert.IsTrue(this.userProvider.SettingExists(Constants.Configuration.ROOT_PATH));
        }

        [TestMethod]
        public void VerifyRandomSettingsNotCreated()
        {
            var randomSetting = "22039h5803298hg0298hg";

            Assert.IsFalse(this.userProvider.SettingExists(randomSetting));
        }

        [TestMethod]
        public void VerifyConstantSettingValue()
        {
            string currentValue = null;
            if (this.userProvider.SettingExists(Constants.Configuration.ROOT_PATH))
            {
                currentValue = this.userProvider.RootPath;
            }

            var newRootPath = "New Root Path";
            this.userProvider.RootPath = newRootPath;

            Assert.IsTrue(this.userProvider.RootPath == newRootPath);

            if (!(currentValue is null))
            {
                this.userProvider.RootPath = currentValue;
            }
        }

        [TestMethod]
        public void VerifyDynamicSettingCreated()
        {
            var dynamicSetting = "2903jf0329hg0";
            var dynamicValue = "Test Value";
            this.userProvider.SetDynamicSetting(dynamicSetting, dynamicValue);

            Assert.IsTrue(this.userProvider.SettingExists(dynamicSetting));
            var pants = this.userProvider.GetDynamicSetting(dynamicSetting);
            Assert.AreEqual(this.userProvider.GetDynamicSetting(dynamicSetting), dynamicValue);
        }
    }
}
