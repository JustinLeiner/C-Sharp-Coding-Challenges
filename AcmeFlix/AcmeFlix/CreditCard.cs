using System;
namespace AcmeFlix
{
    public class CreditCard
    {
        public bool Default { get; set; }

        public string CardHolderName { get; set; } = string.Empty;

        public long CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        static void Main(string[] args)
        {
            List<CreditCard> ccItems = new List<CreditCard>
        {
            new CreditCard { ExpirationDate = DateTime.Now.AddDays(1)},
            new CreditCard { ExpirationDate = DateTime.Now.AddMonths(1)}
        };

            // Orders ccItems (Payment Methods)
            var cc = ccItems.OrderByDescending(p => p.ExpirationDate).FirstOrDefault();


            // Sets corresponding default values
            foreach(CreditCard element in ccItems)
            {
                if(ccItems.IndexOf(element) != 0)
                {
                    element.Default = false;
                }
                else
                {
                    // set lowest expiration to true
                    element.Default = true;
                }
            }
        }

        // Need to determine where in the project i need to put this code:
        // 1. [DONE] Have Troy explain his code
        // 2. [DONE] should I Compare CC dates and determine which one is default
        // 3. Where should I check for duplicate CC's
        // 4. [DONE]Help with IRepository

        public bool Equals(CreditCard other)
        {
            if (other == null)
                return false;

            if (this.CardHolderName == other.CardHolderName && this.CardNumber == other.CardNumber && this.ExpirationDate == other.ExpirationDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            CreditCard CCObj = obj as CreditCard;
            if(CCObj == null)
                return false;
            else
                return Equals(CCObj);  
        }

        public override int GetHashCode()
        {

            return this.CardHolderName.Concat(CardNumber.ToString()).Concat(ExpirationDate.ToString()).GetHashCode();
        }
    }
}

