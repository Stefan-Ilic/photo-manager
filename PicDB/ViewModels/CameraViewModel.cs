using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using Prism.Mvvm;

namespace PicDB.ViewModels
{
    /// <summary>
    /// A viewmodel for a camera
    /// </summary>
    public class CameraViewModel : BindableBase, ICameraViewModel
    {
        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Name of the producer
        /// </summary>
        public string Producer { get; set; }

        /// <summary>
        /// Name of camera
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Optional: date, when the camera was bought
        /// </summary>
        public DateTime? BoughtOn { get; set; }

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
        public bool IsValid { get; }

        /// <summary>
        /// Returns a summary of validation errors
        /// </summary>
        public string ValidationSummary { get; }

        /// <summary>
        /// returns true if the producer name is valid
        /// </summary>
        public bool IsValidProducer { get; }

        /// <summary>
        /// returns true if the make is valid
        /// </summary>
        public bool IsValidMake { get; }

        /// <summary>
        /// returns true if the "bought on" date is valid
        /// </summary>
        public bool IsValidBoughtOn { get; }

        /// <summary>
        /// Max ISO Value for good results. 0 means "not defined"
        /// </summary>
        public decimal ISOLimitGood { get; set; }

        /// <summary>
        /// Max ISO Value for acceptable results. 0 means "not defined"
        /// </summary>
        public decimal ISOLimitAcceptable { get; set; }

        /// <summary>
        /// Translates a given ISO value to a ISO rating
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public ISORatings TranslateISORating(decimal iso)
        {
            return new decimal();
        }
    }
}
