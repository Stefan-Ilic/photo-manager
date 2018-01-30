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
    /// Viewmodel for photographer list
    /// </summary>
    public class PhotographerListViewModel : BindableBase, IPhotographerListViewModel
    {
        /// <summary>
        /// List of all PhotographerViewModel
        /// </summary>
       public  IEnumerable<IPhotographerViewModel> List { get; }

        /// <summary>
        /// The currently selected PhotographerViewModel
        /// </summary>
        public IPhotographerViewModel CurrentPhotographer { get; }
    }
}
