using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab03
{
    class InfoProcess
    {
        public static void AddCustomer(Company company)
        {
            Console.WriteLine("\nInput customer Info, Type 'done' when finished.");
            while (true)
            {
                Console.Write("Enter customer ID (or 'done' to finish): ");
                string id = Console.ReadLine();
                if (id.ToLower() == "done") break;

                if (company.ListOfCustomers.Any(c => c.ValCustomerID == id) || string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("Customer ID already exists or cannot be empty. Please enter a unique ID and try again.");
                    continue;
                }

                Console.Write("Input customer name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Customer name cannot be empty. Please try again.");
                    continue;
                }

                Console.Write("Input customer type (0: TrungThanh, 1: TiemNang, 2: CanQuanTam, 3: KhachHangKhac): ");
                if (!int.TryParse(Console.ReadLine(), out int typeInt) || typeInt < 0 || typeInt > 3)
                {
                    Console.WriteLine("Invalid customer type, please try again.");
                    continue;
                }
                CustomerTypeO type = (CustomerTypeO)typeInt;

                Console.Write("Input customer phone number: ");
                string phone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phone))
                {
                    Console.WriteLine("Customer name cannot be empty. Please try again.");
                    continue;
                }

                Console.Write("Input customer address: ");
                string address = Console.ReadLine();

                company.ListOfCustomers.Add(new Customer(id, name, type, phone, address));
                Console.WriteLine("Customer added successfully!");
            }
        }

        public static void RemoveCustomer(Company company)
        {
            Console.WriteLine("\nDo you want to remove some customer? If yes, press 1; if no, press 0: ");
            if (Console.ReadLine() == "1")
            {
                Console.Write("What CustomerID you want to remove: ");
                string idToRemove = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(idToRemove))
                {
                    Console.WriteLine("Customer ID cannot be empty.");
                    return;
                }

                var customerToRemove = company.ListOfCustomers.FirstOrDefault(c => c.ValCustomerID == idToRemove);
                if (customerToRemove != null)
                {
                    company.ListOfCustomers.Remove(customerToRemove);
                    Console.WriteLine($"Customer '{customerToRemove.ValCustomerName}' removed successfully!");
                    Console.WriteLine($"The number of customers now: {company.ListOfCustomers.Count}");
                }
                else
                {
                    Console.WriteLine("Customer not found!");
                }
            }
        }

        public static void SearchCustomer(Company company)
        {
            Console.WriteLine("\nDo you want to search for a customer? If yes, press 1; if no, press 0: ");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Search by (1) Name or (2) ID?");
                string searchOption = Console.ReadLine();

                if (searchOption == "1")
                {
                    Console.Write("Enter Customer Name to search: ");
                    string searchName = Console.ReadLine();
                    var customer = company.ListOfCustomers.FirstOrDefault(c => c.ValCustomerName == searchName);
                    Console.WriteLine(customer != null ? $"Found customer: {customer.CustomerInfo()}" : "Customer not found!");
                }
                else if (searchOption == "2")
                {
                    Console.Write("Enter Customer ID to search: ");
                    string searchID = Console.ReadLine();
                    var customer = company.ListOfCustomers.FirstOrDefault(c => c.ValCustomerID == searchID);
                    Console.WriteLine(customer != null ? $"Found customer: {customer.CustomerInfo()}" : "Customer not found!");
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
    }
}
