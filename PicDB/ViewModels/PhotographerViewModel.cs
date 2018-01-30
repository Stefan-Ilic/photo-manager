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
    /// Viewmodel for photographer
    /// </summary>
    public class PhotographerViewModel : BindableBase, IPhotographerViewModel
    {
        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Firstname, including middle name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Lastname
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Returns the number of Pictures
        /// </summary>
       public  int NumberOfPictures { get; }

        /// <summary>
        /// Returns true, if the model is valid
        /// </summary>
        public bool IsValid { get; }
        /// <summary>
        /// Returns a summary of validation errors
        /// </summary>
        public string ValidationSummary { get; }

        /// <summary>
        /// returns true if the last name is valid
        /// </summary>
        public bool IsValidLastName { get; }

        /// <summary>
        /// returns true if the birthday is valid
        /// </summary>
        public bool IsValidBirthDay { get; }
    }
}
