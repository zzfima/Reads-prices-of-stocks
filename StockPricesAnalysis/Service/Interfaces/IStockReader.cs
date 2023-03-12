using Service.Models;

namespace Service.Interfaces
{
    /// <summary>
    /// Read price from different sources
    /// </summary>
    public interface IStockReader
    {
        //Start read stock prices asyncronously
        Task StartReadAsync(string path, TimeSpan readFrequency);
        
        //stop reading stock prices
        Task StopReadAsync();

        //
        float GetLowestPrice(string stockName);

        void GetAllLowestPrices();
    }
}
