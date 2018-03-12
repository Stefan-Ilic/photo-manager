using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BIF.SWE2.Interfaces.ViewModels;
using MetadataExtractor.Formats.Exif.Makernotes;
using PicDB.Models;
using PicDB.Reporting;
using PicDB.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace PicDB.ViewModels
{
    /// <summary>
    /// Viewmodel for the main window
    /// </summary>
    public class MainWindowViewModel : BindableBase, IMainWindowViewModel
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public MainWindowViewModel()
        {
            var type = AppContext.Instance.IsMock ? "mock" : "real";
            var bl = new BusinessLayer(type);
            bl.Sync();
            List = new PictureListViewModel();
            if (List.Count != 0)
            {
                CurrentPicture = List.List.First();
            }
        }


        private IPictureViewModel _currentPicture;
        /// <summary>
        /// The current picture ViewModel
        /// </summary>	
        public IPictureViewModel CurrentPicture
        {
            get => _currentPicture;
            set => SetProperty(ref _currentPicture, value);
        }

        /// <summary>
        /// ViewModel with a list of all Pictures
        /// </summary>
        public IPictureListViewModel List { get; }

        /// <summary>
        /// Search ViewModel
        /// </summary>
        public ISearchViewModel Search { get; } = new SearchViewModel();

        #region Commands

        /// <summary>
        /// This command selects a picture if you click on its thumbnail on the bottom
        /// </summary>
        public ICommand SelectPictureCommand => new DelegateCommand<object>(SelectPicture);

        private void SelectPicture(object obj)
        {
            var items = (IList)obj;
            var collection = items.Cast<IPictureViewModel>();
            CurrentPicture = collection.Single();
        }

        /// <summary>
        /// Creates a Report for the CurrentPicture
        /// </summary>
        public ICommand ReportSingleCommand => new DelegateCommand(ReportSingle);

        private void ReportSingle()
        {
            Report.Create(CurrentPicture);
            MessageBox.Show("Report created!");
        }

        /// <summary>
        /// Opens the about window
        /// </summary>
        public ICommand OpenAboutCommand => new DelegateCommand(OpenAbout);

        private static void OpenAbout()
        {
            var about = new About();
            about.ShowDialog();
        }

        #endregion
    }
}
