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
        public StockList Parse(string path)
        {
            var text = File.ReadAllText(path);
            var stocks = JsonConvert.DeserializeObject<Stock[]>(text);
            return new StockList(stocks);
        }
    }
}
