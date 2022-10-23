using CefSharp;
using Microsoft.Win32;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class LoadBookmarksCommand : CommandBase
    {

        private readonly BookmarksViewModel _bookMarkViewModel;

        public LoadBookmarksCommand(BookmarksViewModel bookMarkViewModel)
        {
            this._bookMarkViewModel = bookMarkViewModel;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xml file|*.xml";
            openFileDialog.Title = "Save bookmarks to xml";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                _bookMarkViewModel.LoadBookMarksFromXML(openFileDialog.FileName);
            }
        }
    }
}
