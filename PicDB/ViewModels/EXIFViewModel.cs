using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;
using Prism.Mvvm;

namespace PicDB.ViewModels
{
    /// <summary>
    /// A viewmodel for EXIF data
    /// </summary>
    public class EXIFViewModel : BindableBase, IEXIFViewModel
    {
        /// <summary>
        /// ctor with model
        /// </summary>
        /// <param name="mdl"></param>
        public EXIFViewModel(IEXIFModel mdl)
        {

            Make = mdl.Make;
            FNumber = mdl.FNumber;
            ExposureTime = mdl.ExposureTime;
            ISOValue = mdl.ISOValue;
            Flash = mdl.Flash;
            ExposureProgram = mdl.ExposureTime.ToString(CultureInfo.InvariantCulture);
            ExposureProgramResource = ExposureProgram;


        }

        /// <summary>
        /// Empty ctor
        /// </summary>
        public EXIFViewModel()
        {
            
        }

        /// <summary>
        /// Name of camera
        /// </summary>
        public string Make { get; }

        /// <summary>
        /// Aperture number
        /// </summary>
        public decimal FNumber { get; }

        /// <summary>
        /// Exposure time
        /// </summary>
        public decimal ExposureTime { get; }

        /// <summary>
        /// ISO value
        /// </summary>
        public decimal ISOValue { get; }

        /// <summary>
        /// Flash yes/no
        /// </summary>
        public bool Flash { get; }

        /// <summary>
        /// The Exposure Program as string
        /// </summary>
        public string ExposureProgram { get; }

        /// <summary>
        /// The Exposure Program as image resource
        /// </summary>
        public string ExposureProgramResource { get; } //TODO ask what the hell that is

        /// <summary>
        /// Gets or sets a optional camera view model
        /// </summary>
        public ICameraViewModel Camera { get; set; }

        /// <summary>
        /// Returns a ISO rating if a camera is set.
        /// </summary>
        public ISORatings ISORating {
            get
            {
                if (ISOValue == 0 || Camera == null)
                {
                    return ISORatings.NotDefined;
                }
                if (ISOValue > Camera.ISOLimitAcceptable)
                {
                    return ISORatings.Noisey;
                }
                if (ISOValue > Camera.ISOLimitGood)
                {
                    return ISORatings.Acceptable;
                }
                return ISORatings.Good;
            } }

        /// <summary>
        /// Returns a image resource of a ISO rating if a camera is set.
        /// </summary>
        public string ISORatingResource { get; }
    }
}
