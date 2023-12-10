namespace CarServiceWebConsole.Services.RecordService
{
    public interface IRecordService
    {
        Task<Record> CreateRecordAsync(Record record);
    }
}
