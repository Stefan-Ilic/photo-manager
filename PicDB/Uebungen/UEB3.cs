using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;

namespace Uebungen
{
    public class UEB3 : IUEB3
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

        public IDataAccessLayer GetDataAccessLayer()
        {
            throw new NotImplementedException();
        }

        public ISearchViewModel GetSearchViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
