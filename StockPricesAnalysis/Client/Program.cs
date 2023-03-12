using Service.Factories;
using Service.Interfaces;
using Service.StockPriceReaders;

//Example read different sources
/*
IStockSourceParser stockSourceParser = StockSourceParserFactory.GetStockSourceParser(StockReaderType.Csv);
IStockReader stockReader = new StocksReader(stockSourceParser);
Task.Run(() => stockReader.StartReadAsync("CsvSource.csv", new TimeSpan(0, 0, 1)));
*/

/*
IStockSourceParser stockSourceParser = StockSourceParserFactory.GetStockSourceParser(StockReaderType.Csv);
IStockReader stockReader = new StocksReader(stockSourceParser);
Task.Run(() => stockReader.StartReadAsync("CsvSource.csv", new TimeSpan(0, 0, 1)));
*/

IStockSourceParser stockSourceParser = StockSourceParserFactory.GetStockSourceParser(StockReaderType.Json);
IStockReader stockReader = new StocksReader(stockSourceParser);
Task.Run(() => stockReader.StartReadAsync("JsonSource.json", new TimeSpan(0, 0, 20)));

Thread.Sleep(30000);

Task.Run(() => stockReader.StopReadAsync());

Console.ReadLine();