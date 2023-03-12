using Service.Factories;
using Service.Interfaces;
using Service.StockPriceReaders;

var stockSourceParser = StockSourceParserFactory.GetStockSourceParser(StockReaderType.Json);
IStockReader stockReader = new StocksReader(stockSourceParser);
Task.Run(() => stockReader.StartReadAsync("JsonSource.json", new TimeSpan(0, 0, 1)));

Thread.Sleep(10000);

Task.Run(() =>stockReader.StopReadAsync());

Console.ReadLine();