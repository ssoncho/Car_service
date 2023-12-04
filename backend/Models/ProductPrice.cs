namespace CarServiceWebConsole.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
