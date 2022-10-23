using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI
{
    public class BookmarksViewModel
    {

        public ObservableCollection<BookMarkWebPage> BookMarksList { get; set; }

        public BookmarksViewModel()
        {
            BookMarksList = new ObservableCollection<BookMarkWebPage>();
        }

        public void AddBookMark(BookMarkWebPage bookmarkWebPage)
        {
            BookMarksList.Add(bookmarkWebPage);
        }

        public void RemoveBookMark(BookMarkWebPage bookmarkWebPage)
        {
            BookMarksList.Remove(bookmarkWebPage);
        }

        public void SaveBookMarksToXML(string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<BookMarkWebPage>));
            using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, BookMarksList);
            }
        }

        public void LoadBookMarksFromXML(string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<BookMarkWebPage>));
            using (Stream fStream = File.OpenRead(filename))
            {
                ObservableCollection<BookMarkWebPage> bookmarksList = (ObservableCollection<BookMarkWebPage>)xmlFormat.Deserialize(fStream);
                foreach (BookMarkWebPage webPage in bookmarksList)
                {
                    BookMarksList.Add(webPage);
                }
            }
        }
    }
}
