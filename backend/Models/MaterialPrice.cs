namespace CarServiceWebConsole.Models
{
    public class MaterialPrice
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
