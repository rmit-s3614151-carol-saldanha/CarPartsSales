namespace OAuthExample.Models
{
    public class OrderHistory
    {

        public int ReceiptID { get; set; }
        public CustomerOrder CustomerOrder { get; set; }
        public string ProductName { get; set; }
        public string StoreName { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
