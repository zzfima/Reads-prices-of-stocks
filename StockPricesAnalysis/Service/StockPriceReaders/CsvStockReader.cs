using Service.Interfaces;
using Service.Models;

namespace Service.StockPriceReaders
{
    public class CsvStockReader : IStockReader
    {
        public async Task StartReadAsync(string path, TimeSpan readFrequency)
        {
            throw new NotImplementedException();
        }
    }
}
