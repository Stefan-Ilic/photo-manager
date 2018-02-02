using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces.ViewModels;
using Prism.Mvvm;

namespace PicDB.ViewModels
{
    /// <summary>
    /// Viewmodel for picturelist
    /// </summary>
    public class PictureListViewModel : BindableBase, IPictureListViewModel
    {
        /// <summary>
        /// ViewModel of the current picture
        /// </summary>
        public IPictureViewModel CurrentPicture { get; }

        /// <summary>
        /// List of all PictureViewModels
        /// </summary>
        public IEnumerable<IPictureViewModel> List { get; }

        /// <summary>
        /// All prev. pictures to the current selected picture.
        /// </summary>
        public IEnumerable<IPictureViewModel> PrevPictures { get; }

        /// <summary>
        /// All next pictures to the current selected picture.
        /// </summary>
        public IEnumerable<IPictureViewModel> NextPictures { get; }

        /// <summary>
        /// Number of all images
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// The current Index, 1 based
        /// </summary>
        public int CurrentIndex { get; }

        /// <summary>
        /// {CurrentIndex} of {Cout}
        /// </summary>
        public string CurrentPictureAsString { get; }
    }
}
