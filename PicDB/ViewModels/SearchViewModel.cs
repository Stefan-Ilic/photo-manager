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
    /// Viewmodel for a search
    /// </summary>
    public class SearchViewModel : BindableBase, ISearchViewModel
    {
        /// <summary>
        /// The search text
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// True, if a search is active
        /// </summary>
        public bool IsActive => !string.IsNullOrEmpty(SearchText);

        /// <summary>
        /// Number of photos found.
        /// </summary>
        public int ResultCount { get; }
    }
}
