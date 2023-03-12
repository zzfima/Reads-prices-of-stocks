namespace Service.Models
{
    /// <summary>
    /// Stocks entity
    /// </summary>
    public sealed class StockList
    {
        public Stock[] Stocks { get; }

        public StockList(Stock[] stocks)
        {
            Stocks = stocks;
        }

        public Stock? this[string name] => Stocks.FirstOrDefault(s => s.name.Equals(name));
    }
}
