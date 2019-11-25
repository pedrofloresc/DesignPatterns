using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Factory.AbstractFactory
{
    public class EmployeeSystemManager
    {
        IComputerFactory _IComputerFactory;

        public EmployeeSystemManager(IComputerFactory iComputerFactory)
        {
            _IComputerFactory = iComputerFactory;
        }

        public string GetSystemDetails()
        {
            IBrand iBrand = _IComputerFactory.Brand();
            IProcessor iProcessor = _IComputerFactory.Procesor();
            ISystemType iSystemType = _IComputerFactory.SystemType();

            string returnValue = string.Format("{0} {1} {2}", iBrand.GetBrand(), iProcessor.GetProcessor(), iSystemType.GetSystemType());
            return returnValue;
        }
    }
}