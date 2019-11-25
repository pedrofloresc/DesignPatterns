using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Factory.AbstractFactory
{
    public class EmployeeSystemFactory
    {
        public IComputerFactory Create(Employee e)
        {
            IComputerFactory retunValue = null;

            if(e.EmployeeTypeId == 1)
            {
                if (e.JobDescription == "Manager")
                {
                    retunValue = new MACLaptopFactory();
                }
                else
                    retunValue = new MACFactory();
            }
            else if(e.EmployeeTypeId == 2)
            {
                if (e.JobDescription == "Manager")
                {
                    retunValue = new DellLaptopFactory();
                }
                else
                    retunValue = new DellFactory();
            }

            return retunValue;
        }
    }
}