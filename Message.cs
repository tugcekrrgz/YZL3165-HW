using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Employee
{
    public class Message
    {
        public static void Greeting()
        {
            Console.WriteLine("Uygulamaya Hoşgeldiniz!");
        }

        public static void ErrorMessage(string fieldName)
        {
            Console.WriteLine($"{fieldName} boş geçilemez!");
        }
    }
}
