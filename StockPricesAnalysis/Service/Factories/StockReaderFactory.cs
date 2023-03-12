using Service.Interfaces;
using Service.StockPriceReaders;

namespace Service.Factories
{
    /// <summary>
    /// Creates Stock Reader
    /// </summary>
    public static class StockReaderFactory
    {
        public static IStockReader GetStockReader(StockReaderType stockReaderType)
        {
            IStockReader? stockReader = null;

            switch (stockReaderType)
            {
                case StockReaderType.Csv:
                    stockReader = new CsvStockReader();
                    break;
                case StockReaderType.Json:
                    stockReader = new JsonStockReader();
                    break;
            }

            if (stockReader == null)
                throw new NotImplementedException(message: $"stock Reader for {stockReaderType} type not implemented");

            return stockReader;
        }
    }
}