using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;

namespace PicDB.Models
{
    /// <summary>
    /// Model class for a picture
    /// </summary>
    public class PictureModel : IPictureModel
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="filename"></param>
        public PictureModel(string filename)
        {
            FileName = filename;
            Camera = new CameraModel();
        }

        /// <summary>
        /// Empty ctor
        /// </summary>
        public PictureModel()
        {
            
        }

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Filename of the picture, without path.
        /// </summary>
       public  string FileName { get; set; }

        /// <summary>
        /// IPTC information
        /// </summary>
       public IIPTCModel IPTC { get; set; }

        /// <summary>
        /// EXIF information
        /// </summary>
        public IEXIFModel EXIF { get; set; }

        /// <summary>
        /// The camera (optional)
        /// </summary>
        public ICameraModel Camera { get; set; }
    }
}
