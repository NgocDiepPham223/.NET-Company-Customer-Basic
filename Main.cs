using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab03;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.CustomerCountUpdated += count => Console.WriteLine($"Customer count updated: {count}");

            Console.WriteLine("Enter company name: ");
            company.Name = Console.ReadLine();

            InfoProcess.AddCustomer(company);

            Console.WriteLine("\nCompany information and customer list:");
            company.CompanyInfo();

            Console.WriteLine("\nList of customers: ");
            foreach (var customer in company.ListOfCustomers)
            {
                Console.WriteLine(customer.ConvertToString());
            }

            InfoProcess.SearchCustomer(company);
            InfoProcess.RemoveCustomer(company);

            Console.WriteLine("\nCustomer Types:");
            foreach (var type in company.GetCustomerTypeDescriptions())
            {
                Console.WriteLine($"{type.Key}: {type.Value}");
            }

            Console.ReadKey();
        }
    }
}