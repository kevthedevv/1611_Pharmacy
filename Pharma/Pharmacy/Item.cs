using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class Item
    {
        int itemID;
        string brandName;
        string genericName;
        DateTime expiryDate;
        DateTime dateArrived;
        double purchasedPrice;
        double sellingPrice;
        string batchNumber;
        string storage;
        string formulation;
        int quantity;

        public Item()
        {
            //Empty Item
        }

        public Item(int itemID, string brandName, string genericName, DateTime expiryDate, DateTime dateArrived, double purchasedPrice, double sellingPrice, string batchNumber, string storage, int quantity,string formulation)
        {
            this.ItemID = itemID;
            this.BrandName = brandName;
            this.GenericName = genericName;
            this.ExpiryDate = expiryDate;
            this.DateArrived = dateArrived;
            this.PurchasedPrice = purchasedPrice;
            this.SellingPrice = sellingPrice;
            this.BatchNumber = batchNumber;
            this.Storage = storage;
            this.Quantity = quantity;
            this.Formulation = formulation;
        }

        public int ItemID { get => itemID; set => itemID = value; }
        public string BrandName { get => brandName; set => brandName = value; }
        public string GenericName { get => genericName; set => genericName = value; }
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public DateTime DateArrived { get => dateArrived; set => dateArrived = value; }
        public double PurchasedPrice { get => purchasedPrice; set => purchasedPrice = value; }
        public double SellingPrice { get => sellingPrice; set => sellingPrice = value; }
        public string BatchNumber { get => batchNumber; set => batchNumber = value; }
        public string Storage { get => storage; set => storage = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Formulation { get => formulation; set => formulation = value; }
    }
}
