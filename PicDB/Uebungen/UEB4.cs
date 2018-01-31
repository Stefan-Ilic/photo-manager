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
    public class UEB4 : IUEB4
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
        public void TestSetup(string picturePath)
        {
            
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IEXIFModel GetEmptyEXIFModel()
        {
            return new EXIFModel();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IEXIFViewModel GetEXIFViewModel(IEXIFModel mdl)
        {
            return new EXIFViewModel(mdl);
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IIPTCModel GetEmptyIPTCModel()
        {
            return new IPTCModel();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IIPTCViewModel GetIPTCViewModel(IIPTCModel mdl)
        {
            return new IPTCViewModel(mdl);
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
