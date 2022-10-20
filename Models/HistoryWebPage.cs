
namespace Models
{
    [Serializable]
    public class HistoryWebPage : WebPage
    {

        private DateTime _date; 
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
                PropertyChangedEventHandler();
            }

        }

        public HistoryWebPage(string url, string title) : base(url, title)
        {
            Date = DateTime.Now;

        }

        public HistoryWebPage() : base()
        {
            Date = DateTime.MinValue;
        }

    }
}
