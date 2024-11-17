using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Company
    {
        public List<Customer> ListOfCustomers { get; private set; }
        public string Name;
        public event Action<int> CustomerCountUpdated;

        public Company()
        {
            ListOfCustomers = new List<Customer>();
            Name = "Not Assigned";
        }
        public string ValName
        {
            get { return Name; }
            set { Name = value; }
        }
        public void AddCustomer(Customer customer)
        {
            ListOfCustomers.Add(customer);
            CustomerCountUpdated?.Invoke(ListOfCustomers.Count);
        }
        public void RemoveCustomer(string customerId)
        {
            var customer = ListOfCustomers.FirstOrDefault(c => c.ValCustomerID == customerId);
            if (customer != null)
            {
                ListOfCustomers.Remove(customer);
                CustomerCountUpdated?.Invoke(ListOfCustomers.Count);
            }
        }
        public void CompanyInfo()
        {
            Console.WriteLine($"Company Name: {Name}");
            Console.WriteLine($"Number of Customers: {ListOfCustomers.Count}");

            // Đếm số lượng khách hàng theo loại
            var customerCounts = ListOfCustomers.GroupBy(c => c.ValCustomerType)
                .ToDictionary(group => group.Key, group => group.Count());

            Console.WriteLine("======================================");
            Console.WriteLine($"Loyal Customers: {customerCounts.GetValueOrDefault(CustomerTypeO.TrungThanh, 0)}");
            Console.WriteLine($"Potential Customers: {customerCounts.GetValueOrDefault(CustomerTypeO.TiemNang, 0)}");
            Console.WriteLine($"Customers Needing Attention: {customerCounts.GetValueOrDefault(CustomerTypeO.CanQuanTam, 0)}");
            Console.WriteLine($"Other Customers: {customerCounts.GetValueOrDefault(CustomerTypeO.KhachHangKhac, 0)}");
        }
        public Dictionary<CustomerTypeO, string> GetCustomerTypeDescriptions()
        {
            return new Dictionary<CustomerTypeO, string>
        {
            { CustomerTypeO.TrungThanh, "Loyal customers." },
            { CustomerTypeO.TiemNang, "Potential customers." },
            { CustomerTypeO.CanQuanTam, "Customers needing attention." },
            { CustomerTypeO.KhachHangKhac, "Other customers." }
        };
        }
    }
}

