using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class Order
    {
        int orderID;
        string client;
        string brandName;
        string genericName;
        string formulation;
        DateTime dateOrdered;
        double amount;
        int quantity;

        public Order(int orderID, string client, string brandName, string genericName, string formulation, DateTime dateOrdered, double amount, int quantity)
        {
            this.orderID = orderID;
            this.client = client;
            this.brandName = brandName;
            this.genericName = genericName;
            this.formulation = formulation;
            this.dateOrdered = dateOrdered;
            this.amount = amount;
            this.quantity = quantity;
        }
        public Order() { }

        public int OrderID { get => orderID; set => orderID = value; }
        public string Client { get => client; set => client = value; }
        public string BrandName { get => brandName; set => brandName = value; }
        public string GenericName { get => genericName; set => genericName = value; }
        public string Formulation { get => formulation; set => formulation = value; }
        public DateTime DateOrdered { get => dateOrdered; set => dateOrdered = value; }
        public double Amount { get => amount; set => amount = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
