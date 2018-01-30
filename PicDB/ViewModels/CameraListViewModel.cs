using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class CameraListViewModel : ICameraListViewModel
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
