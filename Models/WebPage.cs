using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]

    public class WebPage : INotifyPropertyChanged
    {

        #region PUBLIC

        public string Url { get; set; }

        public string Title { get; set; }

        #endregion

        #region CONSTRUCTORS

        public WebPage(string url, string title)
        {
            Url = url;
            Title = title;
        }

        public WebPage()
        {
            Url = string.Empty;
            Title = string.Empty;
        }

        #endregion


        protected void PropertyChangedEventHandler([CallerMemberName] string? propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
