using Newtonsoft.Json;
using Service.Interfaces;
using Service.Models;
using System.Xml.Linq;

namespace Service.StockPriceReaders
{
    public class JsonStockReader : IStockReader
    {
        private Stocks _stocks;

        public JsonStockReader()
        {
            _stocks = new Stocks();
        }

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
            var stocks = JsonConvert.DeserializeObject<Stocks>(text);
        }
    }
}