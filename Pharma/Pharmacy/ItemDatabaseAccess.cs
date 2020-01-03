using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Pharmacy
{
    class ItemDatabaseAccess
    {

        SqlConnection conn;
        String connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true";
        public ItemDatabaseAccess()
        {
            conn = new SqlConnection(connectionString);
            conn.ConnectionString = this.connectionString;
            conn.Open();
        }
        public SqlConnection getConnection()
        {
            return this.conn;
        }
        public void Close()
        {
            conn.Close();
        }
        public List<Item> getAllItem()
        {
            List<Item> items = new List<Item>();
            SqlCommand command;
            command = new SqlCommand("Select * from Item", this.conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Item temp = new Item((int)reader["ItemID"], reader["BrandName"].ToString(), reader["GenericName"].ToString(), (DateTime)reader["ExpiryDate"], (DateTime)reader["DateArrived"], (byte)reader["Vatable"], (double)reader["PurchasedPrice"], (double)reader["SellingPrice"], reader["BatchNumber"].ToString(), reader["Storage"].ToString(), (int)reader["Quantity"], reader["Formulation"].ToString(), (int)reader["Threshhold"]);
                    items.Add(temp);
                }
            }
            return items;
        }


        public List<Item> getClosestExpiration(List<Item> items)
        {
            List<Item> temp = new List<Item>();
            DateTime smallest = items.Min(a => a.ExpiryDate);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ExpiryDate == smallest)
                    temp.Add(items[i]);
            }
            return temp;
        }

        public Item getOldestDateArrived(List<Item> items)
        {
            Item temp;
            DateTime smallest = items.Min(a => a.DateArrived);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].DateArrived == smallest)
                    return items[i];
            }
            return new Item();
        }
        public Item getItemByID(int id)
        {
            SqlCommand command = new SqlCommand("Select * from Item where ItemID= @brandname", this.conn); ;
            SqlParameter Parameter = new SqlParameter("@brandname", SqlDbType.Int);
            Parameter.Value = id;
            command.Parameters.Add(Parameter);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                Item temp = new Item((int)reader["ItemID"], reader["BrandName"].ToString(), reader["GenericName"].ToString(), (DateTime)reader["ExpiryDate"], (DateTime)reader["DateArrived"], (byte)reader["Vatable"], (double)reader["PurchasedPrice"], (double)reader["SellingPrice"], reader["BatchNumber"].ToString(), reader["Storage"].ToString(), (int)reader["Quantity"], reader["Formulation"].ToString(), (int)reader["Threshhold"]);
                return temp;

            }

        }
        public Item getStorageForFIFO(int brand)
        {
            Item temp = getOldestDateArrived(getClosestExpiration(getItemsByBrandName(brand)));
            return temp;
        }
        public List<Item> getItemsByBrandName(int id)
        {
            List<Item> items = new List<Item>();
            SqlCommand command = new SqlCommand("Select * from Item where ItemID= @brandname", this.conn); ;
            SqlParameter Parameter = new SqlParameter("@brandname", SqlDbType.Int);
            Parameter.Value = id;
            command.Parameters.Add(Parameter);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Item temp = new Item((int)reader["ItemID"], reader["BrandName"].ToString(), reader["GenericName"].ToString(), (DateTime)reader["ExpiryDate"], (DateTime)reader["DateArrived"], (byte)reader["Vatable"], (double)reader["PurchasedPrice"], (double)reader["SellingPrice"], reader["BatchNumber"].ToString(), reader["Storage"].ToString(), (int)reader["Quantity"], reader["Formulation"].ToString(), (int)reader["Threshhold"]);
                    items.Add(temp);
                }
            }
            return items;
        }
        public List<Item> getAllItemThreshHold()
        {
            List<Item> items = new List<Item>();
            SqlCommand command;
            command = new SqlCommand("Select * from Item where Quantity<= Threshhold", this.conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Item temp = new Item((int)reader["ItemID"], reader["BrandName"].ToString(), reader["GenericName"].ToString(), (DateTime)reader["ExpiryDate"], (DateTime)reader["DateArrived"], (byte)reader["Vatable"], (double)reader["PurchasedPrice"], (double)reader["SellingPrice"], reader["BatchNumber"].ToString(), reader["Storage"].ToString(), (int)reader["Quantity"], reader["Formulation"].ToString(), (int)reader["Threshhold"]);
                    items.Add(temp);
                }
            }
            return items;
        }



        public bool addItem(Item item)
        {
            SqlCommand command;
            command = new SqlCommand("Insert into Item values(@BrandName,@GenericName,@ExpiryDate,@DateArrived,@PurchasedPrice,@SellingPrice,@BatchNumber,@Storage,@Quantity,@Formulation,@Vatable,@Threshhold)", this.getConnection());
            SqlParameter BrandParam = new SqlParameter("@BrandName", SqlDbType.VarChar, 255);
            SqlParameter GenericParam = new SqlParameter("@GenericName", SqlDbType.VarChar, 255);
            SqlParameter ExpiryParam = new SqlParameter("@ExpiryDate", SqlDbType.DateTime);
            SqlParameter ArrivalParam = new SqlParameter("@DateArrived", SqlDbType.DateTime);
            SqlParameter PPParam = new SqlParameter("@PurchasedPrice", SqlDbType.Float);
            SqlParameter SPParam = new SqlParameter("@SellingPrice", SqlDbType.Float);
            SqlParameter BatchParam = new SqlParameter("@BatchNumber", SqlDbType.VarChar, 255);
            SqlParameter StorageParam = new SqlParameter("@Storage", SqlDbType.VarChar, 255);
            SqlParameter QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int);
            SqlParameter ThreshParam = new SqlParameter("@Threshhold", SqlDbType.Int);
            SqlParameter FormulationParam = new SqlParameter("@Formulation", SqlDbType.VarChar, 255);
            SqlParameter VatParam = new SqlParameter("@Vatable", SqlDbType.Bit);
            BrandParam.Value = item.BrandName;
            GenericParam.Value = item.GenericName;
            ExpiryParam.Value = item.ExpiryDate;
            ArrivalParam.Value = item.DateArrived;
            PPParam.Value = item.PurchasedPrice;
            SPParam.Value = item.SellingPrice;
            BatchParam.Value = item.BatchNumber;
            StorageParam.Value = item.Storage;
            QuantityParam.Value = item.Quantity;
            FormulationParam.Value = item.Formulation;
            VatParam.Value = item.Vatable;
            ThreshParam.Value = item.Threshhold;
            command.Parameters.Add(BrandParam);
            command.Parameters.Add(GenericParam);
            command.Parameters.Add(ExpiryParam);
            command.Parameters.Add(ArrivalParam);
            command.Parameters.Add(PPParam);
            command.Parameters.Add(SPParam);
            command.Parameters.Add(BatchParam);
            command.Parameters.Add(StorageParam);
            command.Parameters.Add(QuantityParam);
            command.Parameters.Add(FormulationParam);
            command.Parameters.Add(ThreshParam);
            command.Parameters.Add(VatParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool addItem(string BrandName, string GenericName, DateTime ExpiryDate, DateTime DateArrived, double PurchasedPrice, double SellingPrice, string BatchNumber, string Storage, int quantity, string Formulation, int Threshhold)
        {
            SqlCommand command;
            command = new SqlCommand("Insert into Item values(@BrandName,@GenericName,@ExpiryDate,@DateArrived,@PurchasedPrice,@SellingPrice,@BatchNumber,@Storage,@Quantity,@Formulation,@Threshhold)", this.getConnection());
            SqlParameter BrandParam = new SqlParameter("@BrandName", SqlDbType.VarChar, 255);
            SqlParameter GenericParam = new SqlParameter("@GenericName", SqlDbType.VarChar, 255);
            SqlParameter ExpiryParam = new SqlParameter("@ExpiryDate", SqlDbType.DateTime);
            SqlParameter ArrivalParam = new SqlParameter("@DateArrived", SqlDbType.DateTime);
            SqlParameter PPParam = new SqlParameter("@PurchasedPrice", SqlDbType.Float);
            SqlParameter SPParam = new SqlParameter("@SellingPrice", SqlDbType.Float);
            SqlParameter BatchParam = new SqlParameter("@BatchNumber", SqlDbType.VarChar, 255);
            SqlParameter StorageParam = new SqlParameter("@Storage", SqlDbType.VarChar, 255);
            SqlParameter QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int);
            SqlParameter FormulationParam = new SqlParameter("@Formulation", SqlDbType.VarChar, 255);
            SqlParameter ThreshholdParam = new SqlParameter("@Threshhold", SqlDbType.Int);
            BrandParam.Value = BrandName;
            GenericParam.Value = GenericName;
            ExpiryParam.Value = ExpiryDate;
            ArrivalParam.Value = DateArrived;
            PPParam.Value = PurchasedPrice;
            FormulationParam.Value = Formulation;
            SPParam.Value = SellingPrice;
            BatchParam.Value = BatchNumber;
            StorageParam.Value = Storage;
            QuantityParam.Value = quantity;
            ThreshholdParam.Value = Threshhold;
            command.Parameters.Add(BrandParam);
            command.Parameters.Add(GenericParam);
            command.Parameters.Add(ExpiryParam);
            command.Parameters.Add(ArrivalParam);
            command.Parameters.Add(PPParam);
            command.Parameters.Add(SPParam);
            command.Parameters.Add(BatchParam);
            command.Parameters.Add(ThreshholdParam);
            command.Parameters.Add(StorageParam);
            command.Parameters.Add(QuantityParam);
            command.Parameters.Add(FormulationParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool updateItem(Item item)
        {
            SqlCommand command = new SqlCommand("Update Item set BrandName=@brand,GenericName=@generic,ExpiryDate=@expire,DateArrived=@arrived,PurchasedPrice=@purchase,SellingPrice=@selling,BatchNumber=@batch,Storage=@storage,Quantity=@quantity,Formulation=@formulation,Vatable=@vatable,Threshhold=@threshhold where ItemID =@id", this.conn);
            SqlParameter BrandParam = new SqlParameter("@brand", SqlDbType.VarChar, 255);
            SqlParameter GenericParam = new SqlParameter("@generic", SqlDbType.VarChar, 255);
            SqlParameter ExpiryParam = new SqlParameter("@expire", SqlDbType.DateTime);
            SqlParameter ArrivalParam = new SqlParameter("@arrived", SqlDbType.DateTime);
            SqlParameter PPParam = new SqlParameter("@purchase", SqlDbType.Float);
            SqlParameter SPParam = new SqlParameter("@selling", SqlDbType.Float);
            SqlParameter BatchParam = new SqlParameter("@batch", SqlDbType.VarChar, 255);
            SqlParameter StorageParam = new SqlParameter("@storage", SqlDbType.VarChar, 255);
            SqlParameter QuantityParam = new SqlParameter("@quantity", SqlDbType.Int);
            SqlParameter FormulationParam = new SqlParameter("@formulation", SqlDbType.VarChar, 255);
            SqlParameter IdParam = new SqlParameter("@id", SqlDbType.Int);
            SqlParameter VatParam = new SqlParameter("@vatable", SqlDbType.Int);
            SqlParameter ThreshParam = new SqlParameter("@threshhold", SqlDbType.Int);
            BrandParam.Value = item.BrandName;
            GenericParam.Value = item.GenericName;
            ExpiryParam.Value = item.ExpiryDate;
            ArrivalParam.Value = item.DateArrived;
            PPParam.Value = item.PurchasedPrice;
            FormulationParam.Value = item.Formulation;
            SPParam.Value = item.SellingPrice;
            BatchParam.Value = item.BatchNumber;
            StorageParam.Value = item.Storage;
            QuantityParam.Value = item.Quantity;
            VatParam.Value = item.Vatable;
            ThreshParam.Value = item.Threshhold;
            IdParam.Value = item.ItemID;
            command.Parameters.Add(BrandParam);
            command.Parameters.Add(GenericParam);
            command.Parameters.Add(ExpiryParam);
            command.Parameters.Add(VatParam);
            command.Parameters.Add(ArrivalParam);
            command.Parameters.Add(PPParam);
            command.Parameters.Add(SPParam);
            command.Parameters.Add(BatchParam);
            command.Parameters.Add(ThreshParam);
            command.Parameters.Add(StorageParam);
            command.Parameters.Add(QuantityParam);
            command.Parameters.Add(FormulationParam);
            command.Parameters.Add(IdParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool updateItemByGenericName(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set GenericName=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByBrandName(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set BrandName=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByExpiryDate(int id, DateTime value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set ExpiryDate=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.DateTime);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByDateArrived(int id, DateTime value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set DateArrived=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.DateTime);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByPurchasedPrce(int id, double value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set PurchasedPrice=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.Float);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemBySellingPrce(int id, double value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set SellingPrice=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.Float);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByBatchNumber(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set BatchNumber=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByStorage(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set Storage=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByQuantity(int id, int value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Item set Quantity=@value where ItemID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.Int);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool deleteItem(int id)
        {
            SqlCommand command;
            command = new SqlCommand("Delete from Item where ItemID = @ID", this.conn);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = id;
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }



    }
}
