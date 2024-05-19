namespace Fiorella.Services.Interface
{
    public interface ISettingService
    {
        Task<Dictionary<string, string>> GetAllAsync();
    }
}
