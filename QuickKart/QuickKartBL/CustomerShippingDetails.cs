using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartBL
{
    public class CustomerShippingDetails
    {
        public Customer Customer { get; set; }

        public CustomerShippingDetails(Customer customer)
        {
            this.Customer = customer;
        }
        public string PrintShippingDetails()
        {
            string detailsToPrint = string.Empty;
            detailsToPrint = Customer.GetDeliveryDetails();

            //if (this.Customer is RegularCustomer)
            //{
            //    RegularCustomer regularCustomer = (RegularCustomer)Customer;
            //    detailsToPrint = regularCustomer.GetDeliveryDetailsWithCharges();
            //}
            //else
            //{
            //    detailsToPrint = Customer.GetDeliveryDetails();
            //}

            return detailsToPrint;
        }
    }
}
