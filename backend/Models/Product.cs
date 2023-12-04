namespace CarServiceWebConsole.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductPosition> ProductPositions { get; set; }
        public List<ProductPrice> ProductPrices { get; set; }
    }
}
