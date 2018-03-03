using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using Prism.Mvvm;

namespace PicDB.ViewModels
{
    /// <summary>
    /// Viewmodel for a picture
    /// </summary>
    public class PictureViewModel : BindableBase, IPictureViewModel
    {
        /// <summary>
        /// ctor that accepts with model
        /// </summary>
        /// <param name="mdl"></param>
        public PictureViewModel(IPictureModel mdl)
        {
            ID = mdl.ID;
            FileName = mdl.FileName;
            IPTC = new IPTCViewModel(mdl.IPTC);
            EXIF = new EXIFViewModel(mdl.EXIF);
            Camera = new CameraViewModel(mdl.Camera);
            DisplayName = $"{IPTC.Headline}|{FileName} (by {Photographer}|{IPTC.ByLine})";
        }

        /// <summary>
        /// Empty ctor
        /// </summary>
        public PictureViewModel()
        {

        }

        /// <summary>
        /// Database primary key
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Full file path, used to load the image
        /// </summary>
        public string FilePath => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Pictures\", FileName);

        /// <summary>
        /// The line below the Picture. Format: {IPTC.Headline|FileName} (by {Photographer|IPTC.ByLine}).
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// The IPTC ViewModel
        /// </summary>
        public IIPTCViewModel IPTC { get; } = new IPTCViewModel();

        /// <summary>
        /// The EXIF ViewModel
        /// </summary>
        public IEXIFViewModel EXIF { get; } = new EXIFViewModel();

        /// <summary>
        /// The Photographer ViewModel
        /// </summary>
        public IPhotographerViewModel Photographer { get; } = new PhotographerViewModel();

        /// <summary>
        /// The Camera ViewModel
        /// </summary>
        public ICameraViewModel Camera { get; } = new CameraViewModel();
    }
}
