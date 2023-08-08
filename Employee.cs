using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Employee
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        //ad.soyad@bilgeadam.com
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                _email = $"{Firstname.ToLower()}.{Lastname.ToLower()}@bilgeadam.com";
            }
        }

        public override string ToString()
        {
            return $"Ad-Soyad : {Firstname} {Lastname}\nEmail : {Email}";
        }
    }
}
