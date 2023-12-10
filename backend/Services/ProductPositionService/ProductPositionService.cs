using CarServiceWebConsole.Data;

namespace CarServiceWebConsole.Services.ProductPositionService
{
    public class ProductPositionService : IProductPositionService
    {
        private readonly DataContext _context;

        public ProductPositionService(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductPosition> CreateProductPositionAsync(ProductPosition productPosition)
        {
            _context.ProductPositions.Add(productPosition);
            await _context.SaveChangesAsync();
            return productPosition;
        }
    }
}
