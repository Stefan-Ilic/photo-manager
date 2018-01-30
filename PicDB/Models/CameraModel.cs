using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;

namespace PicDB.Models
{
    /// <summary>
    /// Model Class for a Camera
    /// </summary>
    public class CameraModel : ICameraModel
    {
        /// <summary>
        /// ctor that takes producer and make
        /// </summary>
        /// <param name="producer"></param>
        /// <param name="make"></param>
        public CameraModel(string producer, string make)
        {
            Producer = producer;
            Make = make;
        }

        /// <summary>
        /// Empty ctor
        /// </summary>
        public CameraModel()
        {
            
        }

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; set; }

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
        /// Max ISO Value for good results. 0 means "not defined"
        /// </summary>
        public decimal ISOLimitGood { get; set; }

        /// <summary>
        /// Max ISO Value for acceptable results. 0 means "not defined"
        /// </summary>
        public decimal ISOLimitAcceptable { get; set; }
    }
}
