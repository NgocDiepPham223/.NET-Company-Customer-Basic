using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    public static class CustomerExtensions
    {
        public static string ConvertToString(this Customer customer)
        {
            return $"Customer Info: {customer.CustomerInfo()}";
        }
    }
}
