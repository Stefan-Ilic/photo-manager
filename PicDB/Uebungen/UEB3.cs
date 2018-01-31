using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.ViewModels;

namespace Uebungen
{
    /// <summary>
    /// Used for Test Setup
    /// </summary>
    /// <returns></returns>
    public class UEB3 : IUEB3
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
        public IDataAccessLayer GetDataAccessLayer()
        {
            return DalFactory.Create("mock");
        }

        /// <summary>
        /// Used for Test Setup
        /// </summary>
        /// <returns></returns>
        public ISearchViewModel GetSearchViewModel()
        {
            return new SearchViewModel();
        }
    }
}
