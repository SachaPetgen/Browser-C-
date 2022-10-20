using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;

namespace WebBrowserUI
{
    public class HistoryViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<HistoryWebPage> HistoryList { get; set; }

        public List<HistoryWebPage> SelectedHistory { get; set; }

        public HistoryViewModel()
        {
            HistoryList = new ObservableCollection<HistoryWebPage>();
            SelectedHistory = new List<HistoryWebPage>();
        }

        public void ClearHistory()
        {
            if (HistoryList.Count > 0)
            {
                HistoryList.Clear();
            }
        }

        public void AddHistory(HistoryWebPage historyWebPage)
        {
            if (HistoryList.Count > 0)
            {
                if (!HistoryList.First().Url.Equals(historyWebPage.Url))
                {

                    HistoryList.Insert(0, historyWebPage);

                }
                else
                {
                    HistoryList.First().Date = DateTime.Now;
                }
            }
            else
            {
                HistoryList.Insert(0, historyWebPage);

            }

        }

        public void RemoveHistory(HistoryWebPage historyWebPage)
        {
            if (HistoryList.Contains(historyWebPage))
            {
                HistoryList.Remove(historyWebPage);
            }

        }

        public void RemoveSelectedHistory()
        {

            if(SelectedHistory.Count > 0)
            {
                foreach (HistoryWebPage history in SelectedHistory)
                {
                    RemoveHistory(history);

                }
            }
        }
        
        public void SaveHistoryToXML(string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<HistoryWebPage>));
            using (Stream fStream = new FileStream(filename, FileMode.Create,
            FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, HistoryList);
            }
        }

        public void LoadHistoryFromXML(string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<HistoryWebPage>));
            using (Stream fStream = File.OpenRead(filename))
            {
                ObservableCollection<HistoryWebPage> historyList = (ObservableCollection<HistoryWebPage>)xmlFormat.Deserialize(fStream);
                HistoryList.Clear();
                foreach (HistoryWebPage webPage in historyList)
                {
                    HistoryList.Add(webPage);
                }
            }
        }

        private void PropertyChangedEventHandler([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
