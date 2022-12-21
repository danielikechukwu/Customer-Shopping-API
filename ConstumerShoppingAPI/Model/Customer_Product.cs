namespace ConstumerShoppingAPI.Model
{
    public class Customer_Product
    {
        public int? ProductId { get; set; }  
        public Product? Product { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
