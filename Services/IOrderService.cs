//using Order.Models;
//using System.Data;
//using static Order.Services.OrderService;

//namespace Order.Services
//{
//    public interface IOrderService
//    {
//        //Task<List<MyOrder>> GetAllOrders();
//        Task<DataTable>GetAllOrders(DataBaseObject database = DataBaseObject.HostDB);
//        Task<DataTable> GetOrderById(int id, DataBaseObject database = DataBaseObject.HostDB);
//        Task<DataTable> AddOrder(int Id, String Item, String BuyerName, String SellerName, String Description, int Amout, DateTime Date, DataBaseObject database = DataBaseObject.HostDB);
//        Task<DataTable> UpdateOrder(int Id, String Item, String BuyerName, String SellerName, String Description, int Amout, DateTime Date, DataBaseObject database = DataBaseObject.HostDB);
//        Task<DataTable> DeleteOrder(int Id, DataBaseObject database = DataBaseObject.HostDB);

//    }
//}
