using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebBrowserUI.ViewModels
{
    public class DelegateCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private readonly Action<object> _execute;

        public DelegateCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}
