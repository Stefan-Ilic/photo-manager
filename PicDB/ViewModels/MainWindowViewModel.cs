using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
            CurrentExifProperty = "Make";
            DisplayExifProperty = CurrentPicture.EXIF.Make;

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
            set
            {
                SetProperty(ref _currentPicture, value);
                SetExifProperty();
            }

        }

        /// <summary>
        /// ViewModel with a list of all Pictures
        /// </summary>
        public IPictureListViewModel List { get; } = new PictureListViewModel()
        {
            List = new List<IPictureViewModel>() { new PictureViewModel(new PictureModel("Img1.jpg")), new PictureViewModel(new PictureModel("Img2.jpg")), new PictureViewModel(new PictureModel("Img3.jpg")), new PictureViewModel(new PictureModel("Img4.jpg")) }
        };

        /// <summary>
        /// Search ViewModel
        /// </summary>
        public ISearchViewModel Search { get; } = new SearchViewModel();

        /// <summary>
        /// List of things showing in EXIF combobox
        /// </summary>
        public List<string> ExifList { get; } = new List<string>() { "Make", "FNumber", "Exposure Time", "ISO Value", "Flash", "Exposure Program" };


        private string _currentExifProperty = "Make";
        /// <summary>
        /// The current EXIF property chosen in theh combobox
        /// </summary>	
        public string CurrentExifProperty
        {
            get => _currentExifProperty;
            set
            {
                SetProperty(ref _currentExifProperty, value);
                SetExifProperty();
            }
        }

        private void SetExifProperty()
        {
            switch (_currentExifProperty)
            {
                case "Make":
                    DisplayExifProperty = CurrentPicture.EXIF.Make;
                    break;
                case "FNumber":
                    DisplayExifProperty = CurrentPicture.EXIF.FNumber.ToString(CultureInfo.InvariantCulture);
                    break;
                case "Exposure Time":
                    DisplayExifProperty = CurrentPicture.EXIF.ExposureTime.ToString(CultureInfo.InvariantCulture);
                    break;
                case "ISO Value":
                    DisplayExifProperty = CurrentPicture.EXIF.ISOValue.ToString(CultureInfo.InvariantCulture);
                    break;
                case "Flash":
                    DisplayExifProperty = CurrentPicture.EXIF.Flash.ToString();
                    break;
                case "Exposure Program":
                    DisplayExifProperty = CurrentPicture.EXIF.ExposureProgram;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }


        private string _displayExifProperty;
        /// <summary>
        /// Exif property that is currently being viewed
        /// </summary>	
        public string DisplayExifProperty
        {
            get => _displayExifProperty;
            set => SetProperty(ref _displayExifProperty, value);
        }

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
    }
}
