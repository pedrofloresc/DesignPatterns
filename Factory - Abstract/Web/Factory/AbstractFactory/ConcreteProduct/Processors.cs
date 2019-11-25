using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Factory.AbstractFactory
{
    public class I7 : IProcessor
    {
        public string GetProcessor()
        {
            return Enumerations.Processors.I7.ToString();
        }
    }

    public class I5 : IProcessor
    {
        public string GetProcessor()
        {
            return Enumerations.Processors.I5.ToString();
        }
    }

    public class I3 : IProcessor
    {
        public string GetProcessor()
        {
            return Enumerations.Processors.I3.ToString();
        }
    }
}