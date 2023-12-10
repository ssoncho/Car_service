namespace CarServiceWebConsole.Services.MaterialPositionService
{
    public interface IMaterialPositionService
    {
        Task<MaterialPosition> CreateMaterialPositionAsync(MaterialPosition materialPosition);
    }
}
