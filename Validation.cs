using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Employee
{
    internal class Validation
    {
        public static bool Validate(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Firstname))
            {
                Message.ErrorMessage("İsim");
                return false;
            }
            if (string.IsNullOrEmpty(employee.Lastname))
            {
                Message.ErrorMessage("Soyad");
                return false;
            }
            return true;
        }
    }
}
