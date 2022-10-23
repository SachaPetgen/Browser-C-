using CefSharp.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models
{
    public class BrowserWrapper : INotifyPropertyChanged
    {

        #region PRIVATE

        private string _currentUrl;
        private string _currentTitle;
        #endregion

        #region PUBLIC

        public ChromiumWebBrowser Browser { get; set; }

        public string CurrentUrl
        {
            get { return _currentUrl; }
            set
            {
                if (_currentUrl != value)
                {
                    _currentUrl = value;
                    PropertyChangedEventHandler();
                    
                }
            }
        }

        public string CurrentTitle
        {
            get { return _currentTitle; }
            set
            {
                _currentTitle = value;
                PropertyChangedEventHandler();
            }
        }

        #region CONSTRUCTORS

        public BrowserWrapper()
        {
            Browser = new ChromiumWebBrowser();
            _currentUrl = String.Empty;
            _currentTitle = String.Empty;

        }

        #endregion

        protected void PropertyChangedEventHandler([CallerMemberName] string? propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion
    }
}
