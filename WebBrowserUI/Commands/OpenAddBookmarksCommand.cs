using CefSharp;
using Models;
using System;
using System.Windows;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class OpenAddBookmarksCommand : CommandBase
    {



        public override void Execute(object parameter)
        {
            AddBookmarksWindow addBookMarksWindow = new AddBookmarksWindow();

            addBookMarksWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            addBookMarksWindow.BookMarkAddEvent += OnBookMarkAddEvent;
            addBookMarksWindow.Show();
        }


        public void OnBookMarkAddEvent(object sender, BookMarkAddEventArgs e)
        {

        }
    }
}
