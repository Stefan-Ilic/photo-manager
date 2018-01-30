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
    /// A viewmodel for cameralist
    /// </summary>
    public class CameraListViewModel : BindableBase, ICameraListViewModel
    {
        /// <summary>
        /// List of all CameraListViewModel
        /// </summary>
        public IEnumerable<ICameraViewModel> List { get; }

        /// <summary>
        /// The currently selected CameraListViewModel
        /// </summary>
        public ICameraViewModel CurrentCamera { get; }
    }
}
