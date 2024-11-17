using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab03
{
    public enum CustomerTypeO { TrungThanh, TiemNang, CanQuanTam, KhachHangKhac };
    public class Customer
    {
        string CustomerID = "C001";
        string CustomerName = "Pham Ngo Ngoc Diep";
        string CustomerPhone = "0886450175";
        string CustomerAddress = "Tien Giang";
        CustomerTypeO CustomerType = CustomerTypeO.TrungThanh;
        public Customer() { }
        public Customer(string CustomerID,
            string CustomerName,
            CustomerTypeO CustomerType,
            string CustomerPhone,
            string CustomerAddress)
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
            this.CustomerPhone = CustomerPhone;
            this.CustomerAddress = CustomerAddress;
            this.CustomerType = CustomerType;
        }
        public string ValCustomerID
        {
            get { return CustomerID; }
            set { CustomerID = value; }
        }
        public string ValCustomerName
        {
            get { return CustomerName; }
            set { CustomerName = value; }
        }
        public string ValCustomerPhone
        {
            get { return CustomerPhone; }
            set { CustomerPhone = value; }
        }
        public string ValCustomerAddress
        {
            get { return CustomerAddress; }
            set { CustomerAddress = value; }
        }
        public CustomerTypeO ValCustomerType
        {
            get { return CustomerType; }
            set { CustomerType = value; }
        }

        public string CustomerInfo()
        {
            string CustomerTypeName = Enum.GetName(typeof(CustomerTypeO), CustomerType);
            return $"_______________________________________\n" +
                   $"Customer Information:\n" +
                   $"Customer ID: {CustomerID}\n" +
                   $"Customer Name: {CustomerName}\n" +
                   $"Customer Type: {CustomerTypeName}\n" +
                   $"Customer Phone: {CustomerPhone}\n" +
                   $"Customer Address: {CustomerAddress}\n";
        }
    }
}