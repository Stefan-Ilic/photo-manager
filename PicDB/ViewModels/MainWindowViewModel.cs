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
    /// Viewmodel for the main window
    /// </summary>
    public class MainWindowViewModel : BindableBase, IMainWindowViewModel
    {
        /// <summary>
        /// The current picture ViewModel
        /// </summary>
        public IPictureViewModel CurrentPicture { get; } = new PictureViewModel();

        /// <summary>
        /// ViewModel with a list of all Pictures
        /// </summary>
        public IPictureListViewModel List { get; } = new PictureListViewModel();

        /// <summary>
        /// Search ViewModel
        /// </summary>
        public ISearchViewModel Search { get; } = new SearchViewModel();
    }
}
