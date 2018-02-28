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
            List = new PictureListViewModel(GetPictureViewModels());
            CurrentPicture = List.List.First();

            //Commands
            SelectPictureCommand = new DelegateCommand<object>(SelectPicture);
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
        public ICommand SelectPictureCommand { get; set; }

        private void SelectPicture(object obj)
        {
            var items = (IList)obj;
            var collection = items.Cast<IPictureViewModel>();
            CurrentPicture = collection.Single();
        }

        #endregion

        #region Helper

        private static IEnumerable<IPictureViewModel> GetPictureViewModels()
        {
            var list = new List<IPictureViewModel>();
            var fullFiles = Directory.GetFiles(@"C:\projects\SWE2\SWE2-CS\deploy\Pictures\", "*.jpg", SearchOption.TopDirectoryOnly);
            var files = fullFiles.Select(Path.GetFileName).ToList();
            foreach (var file in files)
            {
                list.Add(new PictureViewModel(new PictureModel(file)));
            }
            return list;
        }

        #endregion
    }
}
