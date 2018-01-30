using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB;

namespace Uebungen
{
    /// <summary>
    /// Used for Test Setup
    /// </summary>
    /// <returns></returns>
    public class UEB6 : IUEB6
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public void TestSetup(string picturePath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IPictureModel GetEmptyPictureModel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public IPhotographerModel GetEmptyPhotographerModel()
        {
            throw new NotImplementedException();
        }
    }
}
