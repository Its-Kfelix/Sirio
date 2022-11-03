namespace Order.Models
{
   
    public class MyOrder
    {
      public int Id { get; set; } = 0;
      public string Item { get; set; } = ""; 
      public string BuyerName { get; set; } = "Felix";
      public string SellerName { get; set; } = "TechSeller";
      public string Description { get; set; } = "8/564 GB 3.0GHZ";
      public int Amount { get; set; } = 30000;
      public DateTime Date { get; set; } = new DateTime(2022,12,16);

    }
    
}

