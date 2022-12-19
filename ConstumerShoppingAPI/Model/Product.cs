namespace ConstumerShoppingAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Customer_Product> customer_product { get; set; }

    }
}
