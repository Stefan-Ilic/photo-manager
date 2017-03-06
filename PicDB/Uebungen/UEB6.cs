using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB;

namespace Uebungen
{
    public class UEB6 : IUEB6
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

        public IPictureModel GetEmptyPictureModel()
        {
            throw new NotImplementedException();
        }

        public IPhotographerModel GetEmptyPhotographerModel()
        {
            throw new NotImplementedException();
        }
    }
}
