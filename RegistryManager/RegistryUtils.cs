using Microsoft.Win32;
using Models;
using System.Diagnostics;

namespace RegistryManager
{
    public class RegistryUtils
    {

        public static RegistryKey SettingKey()
        {

            return Registry.CurrentUser.CreateSubKey(@"SOFTWARE\PetgenWebBrowser\Settings");
        }

        public static void SetDefaultValues()
        {
            if (SettingKey().GetValue("darkMode") is null)
            {
                SettingKey().SetValue("darkMode", "false");
            }

            if (SettingKey().GetValue("defaultUrl") is null)
            {
                SettingKey().SetValue("defaultUrl", "https://www.google.com/");
            }
        }

        public static bool getDarkMode()
        {
            if (SettingKey().GetValue("darkMode").Equals("true"))
            {
                return true;
            }
            return false;
        }

        public static string getDefaultUrl()
        {
            return (string)SettingKey().GetValue("defaultUrl");
        }

        public static void setDarkMode(bool darkMode)
        {
            SettingKey().SetValue("darkMode", darkMode ? "true" : "false");
        }

        public static void setDefaultUrl(string defaultUrl)
        {
            SettingKey().SetValue("defaultUrl", defaultUrl);
        }
    }
}