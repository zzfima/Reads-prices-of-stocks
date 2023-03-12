namespace Service.Models
{
    /// <summary>
    /// Stocks entity
    /// </summary>
    public sealed class LowestStocks
    {
        private IDictionary<string, float> _stocks { get; }

        public LowestStocks(IList<Stock> stockList)
        {
            _stocks = new Dictionary<string, float>();
            UpdateStocks(stockList);
        }

        private void UpdateStocks(IList<Stock> stockList)
        {
            foreach (var stock in stockList)
            {
                if (!_stocks.ContainsKey(stock.Name))
                    _stocks[stock.Name] = stock.Price;
                else
                    _stocks[stock.Name] = _stocks[stock.Name] < stock.Price ? _stocks[stock.Name] : stock.Price;
            }
        }

        public float GetLowestPrice(string stockName) => _stocks.FirstOrDefault(s1 => s1.Key == stockName).Value;
        public IDictionary<string, float> GetAllLowestPrices() => _stocks;
    }
}
