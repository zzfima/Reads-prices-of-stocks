namespace Service.Models
{
    /// <summary>
    /// Stocks entity
    /// </summary>
    public sealed class StockList
    {
        public IList<Stock> Stocks { get; }

        public StockList(IList<Stock> stocks)
        {
            Stocks = stocks;
        }

        public float GetLowestPrice(string stockName) => Stocks.Where(s1 => s1.Name == stockName).Min(s2 => s2.Price);
    }
}
