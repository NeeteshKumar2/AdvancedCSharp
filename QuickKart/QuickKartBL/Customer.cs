using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartBL
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }

        public Customer(string customerId, string customerName, string address, string emailId, string contactNumber)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Address = address;
            EmailId = emailId;
            ContactNumber = contactNumber;
        }

        public string GetDeliveryDetails()
        {
            return "Delivery address:\n" + Address;
        }
    }
}
