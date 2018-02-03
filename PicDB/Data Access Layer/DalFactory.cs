using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIF.SWE2.Interfaces;
using PicDB.Data_Access_Layer;

namespace PicDB
{
    /// <summary>
    /// Factory for DataAccessLayer
    /// </summary>
    public static class DalFactory
    {
        /// <summary>
        /// Returns an instance of the requested Dal type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDataAccessLayer Create(string type = "real")
        {
            if (type.ToLower() == "mock")
            {
                return new MockDal();
            }
            return new Dal();
        }
    }
}
