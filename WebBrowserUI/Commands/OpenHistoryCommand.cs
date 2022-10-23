using CefSharp;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class OpenHistoryCommand : CommandBase
    {

        private readonly HistoryViewModel _historyViewModel;

        public OpenHistoryCommand(HistoryViewModel historyViewModel)
        {
            this._historyViewModel = historyViewModel;
        }

        public override void Execute(object parameter)
        {
            HistoryWindow historyWindow = new HistoryWindow(_historyViewModel);


            historyWindow.Show();

        }
    }
}
