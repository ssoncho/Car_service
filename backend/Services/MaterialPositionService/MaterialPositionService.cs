using CarServiceWebConsole.Data;

namespace CarServiceWebConsole.Services.MaterialPositionService
{
    public class MaterialPositionService : IMaterialPositionService
    {
        private readonly DataContext _context;

        public MaterialPositionService(DataContext context)
        {
            _context = context;
        }

        public async Task<MaterialPosition> CreateMaterialPositionAsync(MaterialPosition materialPosition)
        {
            _context.MaterialPositions.Add(materialPosition);
            await _context.SaveChangesAsync();
            return materialPosition;
        }
    }
}
