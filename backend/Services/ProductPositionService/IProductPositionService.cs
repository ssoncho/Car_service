namespace CarServiceWebConsole.Services.ProductPositionService
{
    public interface IProductPositionService
    {
        Task<ProductPosition> CreateProductPositionAsync(ProductPosition productPosition);
    }
}
