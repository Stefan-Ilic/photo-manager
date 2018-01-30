using System;
using System.Collections.Generic;
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
        public string ExposureProgramResource { get; }

        /// <summary>
        /// Gets or sets a optional camera view model
        /// </summary>
        public ICameraViewModel Camera { get; set; }

        /// <summary>
        /// Returns a ISO rating if a camera is set.
        /// </summary>
        public ISORatings ISORating { get; }

        /// <summary>
        /// Returns a image resource of a ISO rating if a camera is set.
        /// </summary>
        public string ISORatingResource { get; }
    }
}
