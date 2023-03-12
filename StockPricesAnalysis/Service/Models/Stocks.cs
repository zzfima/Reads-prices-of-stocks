namespace Service.Models
{
    /// <summary>
    /// Stocks entity
    /// </summary>
    public sealed class Stocks
    {
        private IList<Stock> _stocks;
        public Stocks()
        {
            _stocks = new List<Stock>();
        }

        public Stock? this[string name] => _stocks.FirstOrDefault(s => s.Name.Equals(name));
    }
}
