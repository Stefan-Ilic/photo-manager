﻿using System;
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
    public class UEB1 : IUEB1
    {
        public IApplication GetApplication()
        {
            return new App();
        }

        public void HelloWorld()
        {
            // I'm fine
        }

        public IDataAccessLayer GetAnyDataAccessLayer()
        {
            throw new NotImplementedException();
        }

        public IBusinessLayer GetBusinessLayer()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.Models.IEXIFModel GetEmptyEXIFModel()
        {
            return new EXIFModel();
        }

        public BIF.SWE2.Interfaces.ViewModels.IEXIFViewModel GetEmptyEXIFViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.Models.IIPTCModel GetEmptyIPTCModel()
        {
            return new IPTCModel();
        }

        public BIF.SWE2.Interfaces.ViewModels.IIPTCViewModel GetEmptyIPTCViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.ViewModels.IMainWindowViewModel GetEmptyMainWindowViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.ViewModels.IPhotographerListViewModel GetEmptyPhotographerListViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.Models.IPhotographerModel GetEmptyPhotographerModel()
        {
            return new PhotographerModel();
        }

        public BIF.SWE2.Interfaces.ViewModels.IPhotographerViewModel GetEmptyPhotographerViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.ViewModels.IPictureListViewModel GetEmptyPictureListViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.Models.IPictureModel GetEmptyPictureModel()
        {
            return new PictureModel();
        }

        public BIF.SWE2.Interfaces.ViewModels.IPictureViewModel GetEmptyPictureViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.ViewModels.ISearchViewModel GetEmptySearchViewModel()
        {
            throw new NotImplementedException();
        }

        public void TestSetup(string picturePath)
        {

        }

        public ICameraModel GetEmptyCameraModel()
        {
            return new CameraModel();
        }

        public ICameraListViewModel GetEmptyCameraListViewModel()
        {
            throw new NotImplementedException();
        }

        public ICameraViewModel GetEmptyCameraViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
