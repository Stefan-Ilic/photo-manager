using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using PicDB.Helper;

namespace PicDB.Models
{
    /// <summary>
    /// Model class or IPTC information
    /// </summary>
    public class IPTCModel : IIPTCModel
    {
        /// <summary>
        /// Empty ctor
        /// </summary>
        public IPTCModel()
        {
            
        }

        /// <summary>
        /// A list of keywords
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Name of the photographer
        /// </summary>
        public string ByLine { get; set; }

        /// <summary>
        /// copyright noties. 
        /// </summary>
        public string CopyrightNotice { get; set; }

        /// <summary>
        /// Summary/Headline of the picture
        /// </summary>
        public string Headline { get; set; }

        /// <summary>
        /// Caption/Abstract, a description of the picture
        /// </summary>
        public string Caption { get; set; }
    }
}
