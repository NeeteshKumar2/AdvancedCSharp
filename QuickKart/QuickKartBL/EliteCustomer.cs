using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartBL
{
    public class EliteCustomer : Customer
    {
        public int NoOfCoupons { get; set; }
        public EliteCustomer(string customerId, string customerName, string address, string emailId, string contactNumber, int noOfCoupons)
            : base(customerId, customerName, address, emailId, contactNumber)
        {
            NoOfCoupons = noOfCoupons;
        }
    }
}
