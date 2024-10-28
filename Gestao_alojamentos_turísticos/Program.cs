using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismManagementSystem.Classes;

namespace TourismManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {   
            Customer customer = new Customer();

            customer.FullName = "Luís Costa";

            Console.WriteLine("Nome do Cliente: {0}",customer.FullName);
        }
    }
}