using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using CefSharp;
using CefSharp.Wpf;
using Microsoft.Win32;
using Models;
using RegistryManager;
using WebBrowserUI.Commands;
using WebBrowserUI.Events;
using WebBrowserUI.ViewModels;

namespace WebBrowserUI
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {



        public ObservableCollection<BrowserWrapper> Browsers { get; set; }

        private BrowserWrapper _actualBrowser;

        public ICommand OpenAddBookmarksCommand { get; set; }
        public ICommand ClearHistoryCommand { get; set; }
        public ICommand ForwardCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand LoadBookmarksCommand { get; set; }
        public ICommand NewTabCommand { get; set; }
        public ICommand OpenBookmarksCommand { get; set; }
        public ICommand OpenHistoryCommand { get; set; }
        public ICommand OpenMenuCommand { get; set; }
        public ICommand OpenSettingsCommand { get; set; }
        public ICommand PreviousCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SaveBookmarksCommand { get; set; }
        public ICommand GoToBookmarksCommand { get; set; }

        private HistoryViewModel _historyViewModel;
        public BookmarksViewModel BookMarkViewModel;

        public BrowserWrapper ActualBrowser
        {
            get
            {
                return _actualBrowser;
            }
            set
            {
                _actualBrowser = value;
                PropertyChangedEventHandler();
            }
        }

        public MainViewModel()
        {
            Browsers = new ObservableCollection<BrowserWrapper>();

            NewBrowser();

            BookMarkViewModel = new BookmarksViewModel();
            _historyViewModel = new HistoryViewModel();

            OpenAddBookmarksCommand = new OpenAddBookmarksCommand(BookMarkViewModel, this);
            ClearHistoryCommand = new ClearHistoryCommand(_historyViewModel);
            ForwardCommand = new ForwardCommand(this);
            HomeCommand = new HomeCommand(this);
            LoadBookmarksCommand = new LoadBookmarksCommand(BookMarkViewModel);    
            NewTabCommand = new NewTabCommand(this);
            OpenBookmarksCommand = new GoToBookmarksCommand(this);
            OpenHistoryCommand = new OpenHistoryCommand(_historyViewModel);
            OpenMenuCommand = new OpenMenuCommand();
            PreviousCommand = new PreviousCommand(this);  
            RefreshCommand = new RefreshCommand(this);
            SaveBookmarksCommand = new SaveBookmarksCommand(BookMarkViewModel);
            GoToBookmarksCommand = new GoToBookmarksCommand(this);
    }

        public void NewBrowser()
        {
            ActualBrowser = new BrowserWrapper();
            Load(RegistryUtils.getDefaultUrl());
            ActualBrowser.Browser.FrameLoadEnd += OnFrameLoadEnd;
            ActualBrowser.Browser.AddressChanged += Browser_AddressChanged;
            ActualBrowser.Browser.TitleChanged += Browser_TitleChanged;
            Browsers.Add(ActualBrowser);
        }

        private void Browser_TitleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                ActualBrowser.CurrentTitle = e.NewValue as string;

            }));
        }

        private void Browser_AddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                ActualBrowser.CurrentUrl = e.NewValue as string;

            }));
        }

        private void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.HttpStatusCode == 200)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    HistoryWebPage historyWebPage = new(ActualBrowser.CurrentUrl, ActualBrowser.CurrentTitle);
                    _historyViewModel.AddHistory(historyWebPage);
                }));
            }
        }

        public void Load(string url)
        {
            ActualBrowser.CurrentUrl = url;
            ActualBrowser.Browser.Load(url);
        }
    }
}
