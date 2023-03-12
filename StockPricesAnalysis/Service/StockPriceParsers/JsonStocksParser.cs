using Newtonsoft.Json;
using Service.Interfaces;
using Service.Models;

namespace Service.StockPriceParsers
{
    /// <summary>
    /// Parse Json source into StockList
    /// </summary>
    public class JsonStocksParser : IStockSourceParser
    {
        public LowestStocks Parse(string path)
        {
            var text = File.ReadAllText(path);
            var stocks = JsonConvert.DeserializeObject<Stock[]>(text);
            return new LowestStocks(stocks.ToList<Stock>());
        }
    }
}
