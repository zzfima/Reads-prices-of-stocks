using Service.Models;

namespace Service.Interfaces
{
    /// <summary>
    /// Read price from different sources
    /// </summary>
    public interface IStockReader
    {
        Task StartReadAsync(string path, TimeSpan readFrequency);
    }
}
