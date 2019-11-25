using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Managers
{
    public class PermanentEmployeeManager : IEmployeeManager
    {
         
        public decimal GetBonus()
        {
            return 10;
        }

        public decimal GetHourlyPay()
        {
            return 8;
        }
    }
}