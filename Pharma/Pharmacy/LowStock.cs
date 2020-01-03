using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class LowStock
    {
        string brandName;
        int quantity;
        string genericName;
        string formulation;
    

        public LowStock() 
        {
            this.brandName = "";
            this.quantity = -1;
            this.genericName = "";
            this.formulation = "";

        }
        public LowStock(string brandName, int quantity, string genericName, string formulation)
        {
            this.brandName = brandName;
            this.quantity = quantity;
            this.genericName = genericName;
            this.formulation = formulation;
 
        }

        public string BrandName { get => brandName; set => brandName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string GenericName { get => genericName; set => genericName = value; }
        public string Formulation { get => formulation; set => formulation = value; }

    }
}
