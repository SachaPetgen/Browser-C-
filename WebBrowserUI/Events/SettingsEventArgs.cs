using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowserUI.Events
{
    public class SettingsEventArgs : EventArgs
    {

        public  bool isDarkMode { get; set; }   
        public string defaultUrl { get; set; }

        public SettingsEventArgs(bool isDarkMode, string defaultUrl)
        {
            this.isDarkMode = isDarkMode;
            this.defaultUrl = defaultUrl;
        }
    }
}
