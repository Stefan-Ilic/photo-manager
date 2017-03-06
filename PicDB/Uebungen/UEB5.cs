using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;

namespace Uebungen
{
    public class UEB5 : IUEB5
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            throw new NotImplementedException();
        }

        public void TestSetup(string picturePath)
        {
            throw new NotImplementedException();
        }

        public IPhotographerModel GetEmptyPhotographerModel()
        {
            throw new NotImplementedException();
        }

        public IPhotographerViewModel GetPhotographerViewModel(IPhotographerModel mdl)
        {
            throw new NotImplementedException();
        }

        public ICameraModel GetEmptyCameraModel()
        {
            throw new NotImplementedException();
        }

        public ICameraViewModel GetCameraViewModel(ICameraModel mdl)
        {
            throw new NotImplementedException();
        }
    }
}
