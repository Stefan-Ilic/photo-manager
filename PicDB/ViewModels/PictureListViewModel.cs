using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;
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
        public IEnumerable<IPictureViewModel> List { get; set; }

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
        public int Count => List.Count();

        /// <summary>
        /// The current Index, 1 based
        /// </summary>
        public int CurrentIndex { get; }

        /// <summary>
        /// {CurrentIndex} of {Cout}
        /// </summary>
        public string CurrentPictureAsString { get; }

        /// <summary>
        /// Creates PictureList from the directory
        /// </summary>
        public PictureListViewModel()
        {
            List = GetPictureViewModels();
        }

        private static IEnumerable<IPictureViewModel> GetPictureViewModels()
        {
            //if (!Directory.Exists(@"Pictures\")) { return list; }
            //var fullFiles = Directory.GetFiles(@"Pictures\", "*.jpg", SearchOption.TopDirectoryOnly);
            //var files = fullFiles.Select(Path.GetFileName).ToList();
            //list.AddRange(files.Select(file => new PictureViewModel(new PictureModel(file))));
            var bl = new BusinessLayer();
            var pictureModels = bl.GetPictures();
            return pictureModels.Select(pictureModel => new PictureViewModel(pictureModel)).Cast<IPictureViewModel>().ToList();
        }
    }
}
