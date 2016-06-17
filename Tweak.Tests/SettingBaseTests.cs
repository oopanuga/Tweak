using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tweak.Tests.TestClasses;

namespace Tweak.Tests
{
    [TestFixture]
    public class SettingBaseTests
    {
        [Category("ReadingSettings")]
        public class ReadingSettings
        {
            [Test]
            public void Should_match_property_name_with_full_setting_key_name_when_setting_key_has_no_dot()
            {
                var settings = new Dictionary<string, string>();
                var clientId = 4;
                var apiKey = "1067bf35-f5b5-4939-9207-4a43cdd824dd";
                settings.Add("ClientId", clientId.ToString());
                settings.Add("ApiKey", apiKey);
                CustomSettingReader.Settings = settings;

                var apiClientSettings = new ApiSettings();

                Assert.AreEqual(clientId, apiClientSettings.ClientId);
                Assert.AreEqual(apiKey, apiClientSettings.ApiKey);
            }

            [Test]
            public void Should_match_class_name_with_left_side_of_dot_and_property_name_with_right_side_of_dot_when_setting_key_has_only_one_dot()
            {
                var settings = new Dictionary<string, string>();
                var clientId = 4;
                settings.Add("ApiSettings.ClientId", clientId.ToString());
                CustomSettingReader.Settings = settings;

                var apiClientSettings = new ApiSettings();
                var clientDetails = new ClientDetails();

                Assert.AreEqual(clientId, apiClientSettings.ClientId);
                Assert.AreEqual(0, clientDetails.ClientId);
            }

            [Test]
            public void Should_match_full_class_name_with_left_side_of_last_dot_and_property_name_with_right_side_of_last_dot_when_setting_key_has_more_than_one_dot()
            {
                var settings = new Dictionary<string, string>();
                var clientId = 4;
                settings.Add("Tweak.Tests.TestClasses.ApiSettings.ClientId", clientId.ToString());
                CustomSettingReader.Settings = settings;

                var apiClientSettings = new ApiSettings();
                var clientDetails = new ClientDetails();

                Assert.AreEqual(clientId, apiClientSettings.ClientId);
                Assert.AreEqual(0, clientDetails.ClientId);
            }

            [Test]
            public void Should_not_match_property_name_with_setting_key_when_casing_is_different()
            {
                var settings = new Dictionary<string, string>();
                var clientId = 4;
                settings.Add("clientId", clientId.ToString());
                CustomSettingReader.Settings = settings;

                var apiClientSettings = new ApiSettings();

                Assert.AreEqual(0, apiClientSettings.ClientId);
            }

            [Test]
            public void Should_throw_exception_when_setting_value_type_is_different_from_property_type()
            {
                var settings = new Dictionary<string, string>();
                var clientId = "someclientid";
                settings.Add("ClientId", clientId);
                CustomSettingReader.Settings = settings;

                Assert.Throws<FormatException>(() => { new ApiSettings(); });
            }

            [Test]
            public void Should_read_the_last_matching_setting_if_multiple_setting_keys_match_propery_name()
            {
                var settings = new Dictionary<string, string>();
                var clientId1 = 4;
                var clientId2 = 10;
                settings.Add("ClientId", clientId1.ToString());
                settings.Add("Tweak.Tests.TestClasses.ApiSettings.ClientId", clientId2.ToString());
                CustomSettingReader.Settings = settings;

                var apiClientSettings = new ApiSettings();

                Assert.AreEqual(clientId2, apiClientSettings.ClientId);
            }
        }

        [Category("WritingSettings")]
        public class WritingSettings
        {
            [Test]
            public void Should_update_settings_with_new_value_when_supplied()
            {
                var settings = new Dictionary<string, string>();
                var clientId = 4;
                var apiKey = "1067bf35-f5b5-4939-9207-4a43cdd824dd";
                settings.Add("ClientId", clientId.ToString());
                settings.Add("ApiKey", apiKey);
                CustomSettingReader.Settings = settings;

                var apiClientSettings = new ApiSettings();

                Assert.AreEqual(clientId, apiClientSettings.ClientId);
                Assert.AreEqual(apiKey, apiClientSettings.ApiKey);

                var newClientId = 5;
                var newApiKey = "5611f7e8-d0cd-44c6-ad66-9929b397009f";

                apiClientSettings.ClientId = newClientId;
                apiClientSettings.ApiKey = newApiKey;
                apiClientSettings.Write();

                Assert.AreEqual(newClientId.ToString(), CustomSettingWriter.Settings["ClientId"]);
                Assert.AreEqual(newApiKey, CustomSettingWriter.Settings["ApiKey"]);
            }
        }
    }
}
