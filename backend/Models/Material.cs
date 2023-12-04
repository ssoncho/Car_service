namespace CarServiceWebConsole.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MaterialPosition> MaterialPositions { get; set; }
        public List<MaterialPrice> MaterialPrices { get; set; }
    }
}
