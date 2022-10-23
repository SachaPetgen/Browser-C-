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
    public class SaveBookmarksCommand : CommandBase
    {

        private readonly BookmarksViewModel _bookMarkViewModel;

        public SaveBookmarksCommand(BookmarksViewModel bookMarkViewModel)
        {
            this._bookMarkViewModel = bookMarkViewModel;
        }

        public override void Execute(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml file|*.xml";
            saveFileDialog.Title = "Save bookmarks to xml";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                _bookMarkViewModel.SaveBookMarksToXML(saveFileDialog.FileName);
            }
        }
    }
}
