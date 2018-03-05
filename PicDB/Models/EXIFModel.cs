using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Helper;

namespace PicDB.Models
{
    /// <summary>
    /// Model class for EXIF information
    /// </summary>
    public class EXIFModel : IEXIFModel
    {
        /// <summary>
        /// Empty ctor
        /// </summary>
        public EXIFModel()
        {
            
        }

        /// <summary>
        /// Takes filename and calls MetaDataExtractor
        /// </summary>
        /// <param name="fileName"></param>
        public EXIFModel(string fileName)
        {
            var extractor = new MetaDataExtractor<EXIFModel>(fileName);
            Make = extractor.Make;
            FNumber = extractor.FNumber;
            ExposureTime = extractor.ExposureTime;
            ISOValue = extractor.ISOValue;
            Flash = extractor.Flash;
            ExposureProgram = extractor.ExposureProgram;
        }

        /// <summary>
        /// Name of camera
        /// </summary>
        public string Make { get; set; }

        /// <summary>
        /// Aperture number
        /// </summary>
        public decimal FNumber { get; set; }

        /// <summary>
        /// Exposure time
        /// </summary>
        public decimal ExposureTime { get; set; }

        /// <summary>
        /// ISO value
        /// </summary>
        public decimal ISOValue { get; set; }

        /// <summary>
        /// Flash yes/no
        /// </summary>
        public bool Flash { get; set; }

        /// <summary>
        /// The exposure program
        /// </summary>
        public ExposurePrograms ExposureProgram { get; set; }
    }
}
