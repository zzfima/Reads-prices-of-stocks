using Service.Interfaces;
using Service.StockPriceParsers;

namespace Service.Factories
{
    public static  class StockSourceParserFactory
    {

        public static IStockSourceParser GetStockSourceParser(StockReaderType stockReaderType)
        {
            IStockSourceParser? stockSourceParser = null;

            switch (stockReaderType)
            {
                case StockReaderType.Csv:
                    stockSourceParser = new CsvStocksParser();
                    break;
                case StockReaderType.Json:
                    stockSourceParser = new JsonStocksParser();
                    break;
            }

            if (stockSourceParser == null)
                throw new NotImplementedException(message: $"stock parser for {stockReaderType} type not implemented");

            return stockSourceParser;
        }
    }
}
