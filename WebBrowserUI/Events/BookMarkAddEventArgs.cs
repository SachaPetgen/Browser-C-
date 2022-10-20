using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowserUI
{
    public class BookMarkAddEventArgs : EventArgs
    {

        public string Name { get; set; }
        public List<string> TagList { get; set; }

        public BookMarkAddEventArgs(string name, List<string> tagList)
        {
            Name = name;
            TagList = tagList; 
        }

    }
}
