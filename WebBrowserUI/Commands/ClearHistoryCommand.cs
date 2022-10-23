using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class ClearHistoryCommand : CommandBase
    {

        private readonly HistoryViewModel _historyViewModel;

        public ClearHistoryCommand(HistoryViewModel historyViewModel)
        {
            _historyViewModel = historyViewModel;
        }

        public override void Execute(object parameter)
        {
            _historyViewModel.ClearHistory();

        }
    }
}
