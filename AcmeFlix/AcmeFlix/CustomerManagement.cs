using System;
using System.Linq;
namespace AcmeFlix
{
    public class CustomerManagement
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<CreditCard> PaymentMethods { get; set; } = new List<CreditCard>();


        /*
        internal void VerifyCreditCardExpirations()
        {
            PaymentMethods.

        }
        */
    }



    
}

