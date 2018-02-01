using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces.Models;
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
        /// Empty ctor
        /// </summary>
        public PhotographerViewModel()
        {

        }

        /// <summary>
        /// Ctor that accepts model
        /// </summary>
        /// <param name="mdl"></param>
        public PhotographerViewModel(IPhotographerModel mdl)
        {
            FirstName = mdl.FirstName;
            LastName = mdl.LastName;
            BirthDay = mdl.BirthDay;
        }

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
        public int NumberOfPictures { get; }

        /// <summary>
        /// Returns true, if the model is valid
        /// </summary>
        public bool IsValid => IsValidLastName && IsValidBirthDay;

        /// <summary>
        /// Returns a summary of validation errors
        /// </summary>
        public string ValidationSummary
        {
            get
            {
                if (IsValid)
                {
                    return "";
                }
                var lastName = IsValidLastName ? "" : "LastName";
                var birthDay = IsValidBirthDay ? "" : "BirthDay";
                return $"The following validations failed: {lastName} {birthDay}";
            }
        }

        /// <summary>
        /// returns true if the last name is valid
        /// </summary>
        public bool IsValidLastName => !string.IsNullOrEmpty(LastName);

        /// <summary>
        /// returns true if the birthday is valid
        /// </summary>
        public bool IsValidBirthDay => DateTime.Today > BirthDay || BirthDay == null;
    }
}
