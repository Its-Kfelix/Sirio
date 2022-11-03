using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace Order.Services
{
    public class OrderService
        //public class OrderService : IOrderService
    {

        public string systemconnection;

        public OrderService()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();
            systemconnection = root.GetConnectionString("Myconnection");

            //IConfigurationBuilder val = (IConfigurationBuilder)new ConfigurationBuilder();
            //JsonConfigurationExtensions.AddJsonFile(val, Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            //IConfigurationRoot val2 = val.Build();
            //systemconnection = ConfigurationExtensions.GetConnectionString((IConfiguration)(object)val2, "SystemConnection");
        }

        #region Databases
        //public enum DataBaseObject
        //{
        //    MainDB,
        //    TrialDB
        //}

        //public string GetDataBaseConnection(DataBaseObject databaseobject)
        //{

        //    string connection_string = systemconnection;//ConfigurationManager.ConnectionStrings["SystemConnection"].ToString();
        //    switch (databaseobject)
        //    {
        //        case DataBaseObject.TrialDB:
        //            connection_string = "";//ConfigurationManager.ConnectionStrings["BrokerConnection"].ToString();
        //            break;

        //        default:
        //            connection_string = systemconnection;//ConfigurationManager.ConnectionStrings["SystemConnection"].ToString();
        //            break;
        //    }
        //    return connection_string;
        //}
        #endregion

        //List<MyOrder> myOrders = new List<MyOrder>()
        //{
        //    new MyOrder{ Id= 0, Item="Laptop"},
        //    new MyOrder{ Id= 1, Item="Iphone"},
        //    new MyOrder{ Id= 2, Item="Desktop"},
        //    new MyOrder{ Id= 3, Item="Laptop"}
        //};

        public DataTable AddOrder(String Item, String BuyerName, String SellerName, String Description, int Amount, DateTime Date)
        {
            DataTable datatable = new DataTable();
            //int i = 0;
            try
            {
                using (SqlConnection connect = new SqlConnection(systemconnection))
                {
                    using(SqlCommand val = new SqlCommand("AddOrder", connect))
                    {
                        //val.CommandType = CommandType.StoredProcedure;
                        //val.Parameters.AddWithValue("@Id", Id);
                        //val.Parameters.AddWithValue("@Item", Item);
                        //val.Parameters.AddWithValue("@BuyerName", BuyerName);
                        //val.Parameters.AddWithValue("@SellerName", SellerName);
                        //val.Parameters.AddWithValue("@Description", Amout);
                        //val.Parameters.AddWithValue("@Date", Date);
                        //i = val.ExecuteNonQuery();

                        using (SqlDataAdapter val2 = new SqlDataAdapter(val))
                        {
                            val.CommandType = CommandType.StoredProcedure;
                            //val.Parameters.AddWithValue("@Id", Id);
                            val.Parameters.AddWithValue("@Item", Item);
                            val.Parameters.AddWithValue("@BuyerName", BuyerName);
                            val.Parameters.AddWithValue("@SellerName", SellerName);
                            val.Parameters.AddWithValue("@Description", Description);
                            val.Parameters.AddWithValue("@Amount", Amount);
                            val.Parameters.AddWithValue("@Date", Date);
                            val2.Fill(datatable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return datatable;
        }
        public DataTable GetAllOrders()
        {

            DataTable datatable = new DataTable();
            try {
                using (SqlConnection connect = new SqlConnection(systemconnection))
                {
                    using (SqlCommand val2 = new SqlCommand("GetAllOrders", connect))
                    {
                        using (SqlDataAdapter val3 = new SqlDataAdapter(val2))
                        {
                            val2.CommandType = CommandType.StoredProcedure;
                            val2.Parameters.AddWithValue("@module", "order");
                            val3.Fill(datatable);
                        }
                    }

                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return datatable;
        }

        public DataTable GetOrderById(int Id)
        {

            DataTable datatable = new DataTable();
            try
            {
                using (SqlConnection val = new SqlConnection(systemconnection))
                {
                    using (SqlCommand val2 = new SqlCommand("GetOrderById", val))
                    {
                        using (SqlDataAdapter val3 = new SqlDataAdapter(val2))
                        {
                            val2.CommandType = CommandType.StoredProcedure;
                            //val2.Parameters.AddWithValue("@module", "order");
                            val2.Parameters.AddWithValue("@Id", Id);
                            val3.Fill(datatable);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return datatable;
        }

        public DataTable UpdateOrder(int Id, String Item, String BuyerName, String SellerName, String Description, int Amout, DateTime Date)
        {
            DataTable datatable = new DataTable();
            try
            {
                using (SqlConnection val = new SqlConnection(systemconnection))
                {
                    using (SqlCommand val2 = new SqlCommand("UpdateOrder", val))
                    {
                        using (SqlDataAdapter val3 = new SqlDataAdapter(val2))
                        {
                            val2.CommandType = CommandType.StoredProcedure;
                            val2.Parameters.AddWithValue("@Id", Id);
                            val2.Parameters.AddWithValue("@Item", Item);
                            val2.Parameters.AddWithValue("@BuyerName", BuyerName);
                            val2.Parameters.AddWithValue("@SellerName", SellerName);
                            val2.Parameters.AddWithValue("@Description", Amout);
                            val2.Parameters.AddWithValue("@Date", Date);
                            val3.Fill(datatable);
                        }
                    }
                    
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return datatable;
        }

        //public async Task<List<MyOrder>> UpdateOrder(MyOrder updatedOrder)
        //{
        //    MyOrder myOrder = myOrders.FirstOrDefault(x => x.Id == updatedOrder.Id);
        //    myOrder.Item = updatedOrder.Item;
        //    myOrder.SellerName= updatedOrder.SellerName;
        //    myOrder.BuyerName = updatedOrder.BuyerName;
        //    myOrder.Amount = updatedOrder.Amount;
        //    myOrder.Description = updatedOrder.Description;
        //    myOrder.Date = updatedOrder.Date;

        //    myOrders.Select(x => x == myOrder);

        //    return myOrders;
        //}

        public DataTable DeleteOrder(int Id)
        {
            DataTable datatable = new DataTable();

            try
            {
                using (SqlConnection val = new SqlConnection(systemconnection))
                {
                    using (SqlCommand val2 = new SqlCommand("DeleteOrder", val))
                    {
                        using (SqlDataAdapter val3 = new SqlDataAdapter(val2))
                        {
                            val2.CommandType = CommandType.StoredProcedure;
                            val2.Parameters.AddWithValue("@Id", Id);
                            val3.Fill(datatable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return datatable;

        }
        //public async Task<List<MyOrder>> DeleteOrder(int id)
        //{
        //    MyOrder myOrder = myOrders.FirstOrDefault(x => x.Id == id);

        //    myOrders.Remove(myOrder);

        //    return myOrders;

        //}

        //public Task<List<MyOrder>> GetAllOrders()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<MyOrder>> IOrderService.GetOrderById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<MyOrder>> AddOrder(MyOrder newOrder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
