using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Managers;

namespace Web.Factory
{
    public class EmployeeManagerFactory
    {
        public IEmployeeManager GetEmployeeManager(int employeeTypeID)
        {
            if (employeeTypeID == 1)
            {
                return new PermanentEmployeeManager();
            }
            else if (employeeTypeID == 2)
            {
                return new ContractEmployeeManager();
            }
            return null;
        }
    }
}