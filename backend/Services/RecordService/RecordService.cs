using CarServiceWebConsole.Data;

namespace CarServiceWebConsole.Services.RecordService
{
    public class RecordService : IRecordService
    {
        private readonly DataContext _context;

        public RecordService(DataContext context)
        {
            _context = context;
        }

        public async Task<Record> CreateRecordAsync(Record record)
        {
            _context.Records.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }
    }
}
