﻿using System;
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
    /// A viewmodel for IPTC information
    /// </summary>
    public class IPTCViewModel : BindableBase, IIPTCViewModel
    {
        /// <summary>
        /// ctor with model
        /// </summary>
        /// <param name="mdl"></param>
        public IPTCViewModel(IIPTCModel mdl)
        {
            if (mdl == null)
            {
                return;
            }

            ByLine = mdl.ByLine;
            Caption = mdl.Caption;
            CopyrightNotice = mdl.CopyrightNotice;
            Headline = mdl.Headline;
            Keywords = mdl.Keywords;
        }

        /// <summary>
        /// Empty ctor
        /// </summary>
        public IPTCViewModel()
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
        /// A list of common copyright noties. e.g. All rights reserved, CC-BY, CC-BY-SA, CC-BY-ND, CC-BY-NC, CC-BY-NC-SA, CC-BY-NC-ND
        /// </summary>
        public IEnumerable<string> CopyrightNotices { get; } = new List<string>(){ "All rights reserved", "CC-BY", "CC-BY-SA", "CC-BY-ND", "CC-BY-NC", "CC-BY-NC-SA", "CC-BY-NC-ND" };

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
