using CefSharp;
using Models;
using RegistryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebBrowserUI.Events;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class OpenSettingsCommand : CommandBase
    {

        public override void Execute(object parameter)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settingsWindow.SettingsSetEvent += OnSettingsSetEvent;
            settingsWindow.ShowDialog();
        }
        
        public void OnSettingsSetEvent(object sender, SettingsEventArgs e)
        {
            if (e.defaultUrl != "")
            {
                RegistryUtils.setDefaultUrl(e.defaultUrl);
            }

            RegistryUtils.setDarkMode(e.isDarkMode);
        }
    }
}
