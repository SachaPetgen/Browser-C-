using CefSharp;
using Models;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class ForwardCommand : CommandBase
    {

        private readonly MainViewModel _mainViewModel;

        public ForwardCommand(MainViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
        }


        public override void Execute(object parameter)
        {
            if (_mainViewModel.ActualBrowser.Browser.CanGoForward)
            {
                _mainViewModel.ActualBrowser.Browser.Forward();

            }
        }
    }
}
