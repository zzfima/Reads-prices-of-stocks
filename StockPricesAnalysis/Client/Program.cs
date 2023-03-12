using Service.Factories;

var stockReader = StockReaderFactory.GetStockReader(StockReaderType.Json);
Task.Run(() => stockReader.StartReadAsync("JsonSource.json", new TimeSpan(0, 0, 5)));

Thread.Sleep(10000);

stockReader.StopRead();

Console.ReadLine(); 