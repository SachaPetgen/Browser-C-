using Models;
using System.Windows;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI.Commands
{
    public class OpenAddBookmarksCommand : CommandBase
    {

        private BookmarksViewModel _bookmarksViewModel;
        private MainViewModel _mainViewModel;

        public OpenAddBookmarksCommand(BookmarksViewModel bookmarksViewModel, MainViewModel mainViewModel)
        {
            this._bookmarksViewModel = bookmarksViewModel;
            this._mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            AddBookmarksWindow addBookMarksWindow = new AddBookmarksWindow();

            addBookMarksWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            addBookMarksWindow.BookMarkAddEvent += OnBookMarkAddEvent;
            addBookMarksWindow.Show();
        }

        
        public void OnBookMarkAddEvent(object sender, BookMarkAddEventArgs e)
        {
            BookMarkWebPage bookMarkWebPage = new BookMarkWebPage(_mainViewModel.ActualBrowser.CurrentUrl, _mainViewModel.ActualBrowser.CurrentTitle, e.Name, e.TagList);
            _bookmarksViewModel.AddBookMark(bookMarkWebPage);

        }
    }
}
