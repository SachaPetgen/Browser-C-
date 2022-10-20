using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]

    public class BookMarkWebPage : WebPage
    {

        public string Name { get; set; }

        public List<string> Tags { get; set; }

        public BookMarkWebPage(string url, string title, string name, List<String> tagList) : base(url, title)
        {
            Name = name;
            Tags = tagList;
        }

        public BookMarkWebPage() : base()
        {
            Name = string.Empty;
            Tags = new List<string>();
        }
    }
}
