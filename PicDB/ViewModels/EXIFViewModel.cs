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
using PicDB.Properties;
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
            ExposureProgram = GetExposureProgram(mdl.ExposureProgram);
            ExposureProgramResource = GetExposureProgramResource(mdl.ExposureProgram);
        }

        private static string GetExposureProgram(ExposurePrograms exp)
        {
            switch (exp)
            {
                case ExposurePrograms.ActionProgram:
                    return "Action Program";
                case ExposurePrograms.LandscapeMode:
                    return "Landscape Mode";
                case ExposurePrograms.PortraitMode:
                    return "Portrait Mode";
                case ExposurePrograms.AperturePriority:
                    return "Aperture Priority";
                case ExposurePrograms.CreativeProgram:
                    return "Creative Program";
                case ExposurePrograms.Manual:
                    return "Manual";
                case ExposurePrograms.Normal:
                    return "Normal";
                case ExposurePrograms.ShutterPriority:
                    return "Shutter Priority";
                case ExposurePrograms.NotDefined:
                    return "Not Defined";
                default:
                    throw new NotSupportedException();
            }
        }

        private static string GetExposureProgramResource(ExposurePrograms exp)
        {
            string pic;
            switch (exp)
            {
                case ExposurePrograms.ActionProgram:
                    pic = "ActionProgram";
                    break;
                case ExposurePrograms.LandscapeMode:
                    pic = "LandscapeMode";
                    break;
                case ExposurePrograms.PortraitMode:
                    pic = "PortraitMode";
                    break;
                case ExposurePrograms.AperturePriority:
                    pic = "AperturePriority";
                    break;
                case ExposurePrograms.CreativeProgram:
                    pic = "CreativeProgram";
                    break;
                case ExposurePrograms.Manual:
                    pic = "Manual";
                    break;
                case ExposurePrograms.Normal:
                    pic = "Normal";
                    break;
                case ExposurePrograms.ShutterPriority:
                    pic = "ShutterPriority";
                    break;
                case ExposurePrograms.NotDefined:
                    pic = "NotDefined";
                    break;
                default:
                    throw new NotSupportedException();
            }

            return "/PicDB;component/Resources/" + pic + ".png";
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
        /// Pic for flash in view
        /// </summary>
        public string FlashPic => Flash ? "/PicDB;component/Resources/FlashOn.png" : "/PicDB;component/Resources/FlashOff.png";

        /// <summary>
        /// Text for flash in view
        /// </summary>
        public string FlashText => Flash ? "On" : "Off";

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
        public ISORatings ISORating
        {
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
            }
        }

        /// <summary>
        /// Returns a image resource of a ISO rating if a camera is set.
        /// </summary>
        public string ISORatingResource { get; }
    }
}
