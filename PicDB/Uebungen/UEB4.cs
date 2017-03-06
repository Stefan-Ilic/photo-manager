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
    public class UEB4 : IUEB4
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

        public IEXIFModel GetEmptyEXIFModel()
        {
            throw new NotImplementedException();
        }

        public IEXIFViewModel GetEXIFViewModel(IEXIFModel mdl)
        {
            throw new NotImplementedException();
        }

        public IIPTCModel GetEmptyIPTCModel()
        {
            throw new NotImplementedException();
        }

        public IIPTCViewModel GetIPTCViewModel(IIPTCModel mdl)
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
