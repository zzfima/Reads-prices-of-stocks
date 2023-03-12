using Newtonsoft.Json;
using Service.Interfaces;
using Service.Models;

namespace Service.StockPriceReaders
{
    public class JsonStockReader : IStockReader
    {
        private StockList _stocks;

        public async Task StartReadAsync(string path, TimeSpan readFrequency)
        {
            while (true)
            {
                await UpdateStockPrices(path);
                await Task.Delay(readFrequency);
            }
        }

        private async Task UpdateStockPrices(string path)
        {
            var text = await File.ReadAllTextAsync(path);
            var stocks = JsonConvert.DeserializeObject<Stock[]>(text);
            _stocks = new StockList(stocks);
        }
    }
}