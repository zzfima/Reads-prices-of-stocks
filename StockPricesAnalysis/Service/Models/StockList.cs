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

        public Stock? this[string name] => Stocks.FirstOrDefault(s => s.Name.Equals(name));
    }
}
