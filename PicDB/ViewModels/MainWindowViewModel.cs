using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            get { return _currentPicture; }
            set { SetProperty(ref _currentPicture, value); }
        }




        /// <summary>
        /// ViewModel with a list of all Pictures
        /// </summary>
        public IPictureListViewModel List { get; } = new PictureListViewModel()
        {
            List = new List<IPictureViewModel>(){ new PictureViewModel(new PictureModel("Img1.jpg")), new PictureViewModel(new PictureModel("Img2.jpg")), new PictureViewModel(new PictureModel("Img3.jpg")), new PictureViewModel(new PictureModel("Img4.jpg")) }
        };

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
            CurrentPicture = collection.First();
        }

        #endregion
    }
}
