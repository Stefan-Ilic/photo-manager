using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.Models;

namespace Uebungen
{
    /// <summary>
    /// Used for Test Setup
    /// </summary>
    /// <returns></returns>
    public class UEB1 : IUEB1
    {
        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IApplication GetApplication()
        {
            return new App();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public void HelloWorld()
        {
            // I'm fine
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IDataAccessLayer GetAnyDataAccessLayer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IBusinessLayer GetBusinessLayer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.Models.IEXIFModel GetEmptyEXIFModel()
        {
            return new EXIFModel();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IEXIFViewModel GetEmptyEXIFViewModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.Models.IIPTCModel GetEmptyIPTCModel()
        {
            return new IPTCModel();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IIPTCViewModel GetEmptyIPTCViewModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IMainWindowViewModel GetEmptyMainWindowViewModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IPhotographerListViewModel GetEmptyPhotographerListViewModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.Models.IPhotographerModel GetEmptyPhotographerModel()
        {
            return new PhotographerModel();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IPhotographerViewModel GetEmptyPhotographerViewModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IPictureListViewModel GetEmptyPictureListViewModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.Models.IPictureModel GetEmptyPictureModel()
        {
            return new PictureModel();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.IPictureViewModel GetEmptyPictureViewModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public BIF.SWE2.Interfaces.ViewModels.ISearchViewModel GetEmptySearchViewModel()
        {
            throw new NotImplementedException();
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
        public ICameraModel GetEmptyCameraModel()
        {
            return new CameraModel();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public ICameraListViewModel GetEmptyCameraListViewModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public ICameraViewModel GetEmptyCameraViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
