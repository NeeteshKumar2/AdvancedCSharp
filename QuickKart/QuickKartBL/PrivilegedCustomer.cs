using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartBL
{
    public class PrivilegedCustomer : Customer
    {
        public string CardType { get; set; }

        public PrivilegedCustomer(string customerId, string customerName, string address, string emailId, string contactNumber, string cardType)
            : base(customerId, customerName, address, emailId, contactNumber)
        {
            CardType = cardType;
        }

        public string GetDeliveryDetailsWithCharges()
        {
            string deliveryDetails = base.GetDeliveryDetails();
            deliveryDetails += "\n\nDelivery Charge:\n" + CalculateDeliveryCharges();
            return deliveryDetails;
        }
        public double CalculateDeliveryCharges()
        {
            double deliveryCharges = 0;
            switch (CardType)
            {
                case "Silver":
                    deliveryCharges = 100;
                    break;
                case "Gold":
                    deliveryCharges = 50;
                    break;
                case "Platinum":
                    deliveryCharges = 25;
                    break;
                default:
                    deliveryCharges = 0;
                    break;
            }
            return deliveryCharges;
        }
    }
}
