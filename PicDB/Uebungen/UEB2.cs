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
    public class UEB2 : IUEB2
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.ViewModels.IMainWindowViewModel GetMainWindowViewModel()
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.Models.IPictureModel GetPictureModel(string filename)
        {
            throw new NotImplementedException();
        }

        public BIF.SWE2.Interfaces.ViewModels.IPictureViewModel GetPictureViewModel(BIF.SWE2.Interfaces.Models.IPictureModel mdl)
        {
            throw new NotImplementedException();
        }

        public void TestSetup(string picturePath)
        {
            throw new NotImplementedException();
        }

        public ICameraModel GetCameraModel(string producer, string make)
        {
            throw new NotImplementedException();
        }

        public ICameraViewModel GetCameraViewModel(ICameraModel mdl)
        {
            throw new NotImplementedException();
        }
    }
}
