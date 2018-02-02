using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.Models;
using PicDB.ViewModels;

namespace Uebungen
{
    /// <summary>
    /// Used for Test Setup
    /// </summary>
    /// <returns></returns>
    public class UEB2 : IUEB2
    {
        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public void HelloWorld()
        {
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IBusinessLayer GetBusinessLayer()
        {
            return new BusinessLayer("mock");
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IMainWindowViewModel GetMainWindowViewModel()
        {
            return new MainWindowViewModel();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.Models.IPictureModel GetPictureModel(string filename)
        {
            return new PictureModel(filename, true);
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IPictureViewModel GetPictureViewModel(BIF.SWE2.Interfaces.Models.IPictureModel mdl)
        {
            return new PictureViewModel(mdl);
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public void TestSetup(string picturePath)
        {
            
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public ICameraModel GetCameraModel(string producer, string make)
        {
            return new CameraModel(producer, make);
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public ICameraViewModel GetCameraViewModel(ICameraModel mdl)
        {
            return new CameraViewModel(mdl);
        }
    }
}
