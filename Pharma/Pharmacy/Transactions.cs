using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class Transactions
    {
        int transactionID;
        List<Sale> sales;
        Customer customer;
        DateTime datePurchased;
        public Transactions() 
        {
            //Empty Transaction
        }
        public Transactions(int transactionID,List<Sale> sales, Customer customer, DateTime datePurchased)
        {
            this.TransactionID = transactionID;
            this.Sales = sales;
            this.Customer = customer;
            this.DatePurchased = datePurchased;
        }

        public DateTime DatePurchased { get => datePurchased; set => datePurchased = value; }
        public int TransactionID { get => transactionID; set => transactionID = value; }
        internal List<Sale> Sales { get => sales; set => sales = value; }
        internal Customer Customer { get => customer; set => customer = value; }
        public void addSale(Sale sale) 
        {
             this.sales.Add(sale);
        }
    }
}
