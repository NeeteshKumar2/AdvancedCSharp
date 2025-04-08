using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartBL
{
    public class RegularCustomer : Customer
    {
        public int DiscountPercentage { get; set; }

        public RegularCustomer(string customerId, string customerName, string address, string emailId, string contactNumber, int discountPercentage)
            : base(customerId, customerName, address, emailId, contactNumber)
        {
            DiscountPercentage = discountPercentage;
        }

        public string GetDeliveryCharges()
        {
            string deliveryDetails = base.GetDeliveryDetails();
            deliveryDetails += "\n\nDelivery Charges:\n" + CalculateDeliveryCharges();
            return deliveryDetails;
        }
        public double CalculateDeliveryCharges()
        {
            double deliveryCharges = 0;
            if (DiscountPercentage >= 0 && DiscountPercentage < 10)
            {
                deliveryCharges = DiscountPercentage * 5;
            }
            else
            {
                deliveryCharges = DiscountPercentage * 10;
            }
            return deliveryCharges;
        }
    }
}
