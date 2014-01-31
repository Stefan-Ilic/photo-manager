using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;

namespace MyCRM.Uebungen
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
    }
}
