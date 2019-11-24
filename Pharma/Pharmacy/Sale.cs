using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class Sale
    {
        int saleID;
        int itemID;
        double balance;
        int quantity;
        int transactionID;
        DateTime datePurchased;
        double sellingPrice;

        public Sale() 
        {
            //empty Sale
        }
        public Sale(int saleID, int itemID, double balance, int quantity, int transactionID, DateTime datePurchased, double sellingPrice)
        {
            this.SaleID = saleID;
            this.ItemID = itemID;
            this.Balance = balance;
            this.Quantity = quantity;
            this.TransactionID = transactionID;
            this.DatePurchased = datePurchased;
            this.SellingPrice = sellingPrice;
        } 

        public int ItemID { get => itemID; set => itemID = value; }
        public double Balance { get => balance; set => balance = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int TransactionID { get => transactionID; set => transactionID = value; }
        public DateTime DatePurchased { get => datePurchased; set => datePurchased = value; }
        public double SellingPrice { get => sellingPrice; set => sellingPrice = value; }
        public int SaleID { get => saleID; set => saleID = value; }
    }
}
