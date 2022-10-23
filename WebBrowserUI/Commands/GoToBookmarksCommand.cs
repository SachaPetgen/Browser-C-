using Models;
using System.Windows;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class GoToBookmarksCommand : CommandBase
    {

        private readonly MainViewModel _mainViewModel;

        public GoToBookmarksCommand(MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            _mainViewModel.ActualBrowser.CurrentUrl = parameter.ToString();
        }
    }
}
