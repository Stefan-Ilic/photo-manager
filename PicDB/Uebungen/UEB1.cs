using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using PicDB;

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
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.ViewModels.IEXIFViewModel GetEmptyEXIFViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.Models.IIPTCModel GetEmptyIPTCModel()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
