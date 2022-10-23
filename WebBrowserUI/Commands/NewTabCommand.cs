using CefSharp;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class NewTabCommand : CommandBase
    {

        private readonly MainViewModel mainViewModel;

        public NewTabCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            mainViewModel.NewBrowser();
        }
    }
}
