namespace APIDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int PriceProduct { get; set; }
        public int CategoryProductID { get; set; }
        public CategoryProduct? CategoryProduct { get; set; }
    }
}
