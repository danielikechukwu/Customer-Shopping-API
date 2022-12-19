namespace ConstumerShoppingAPI.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomeAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public List<Customer_Product> customer_product { get; set; }    

    }
}
