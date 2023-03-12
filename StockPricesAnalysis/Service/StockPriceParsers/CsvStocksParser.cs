using Microsoft.VisualBasic.FileIO;
using Service.Interfaces;
using Service.Models;

namespace Service.StockPriceParsers
{
    public class CsvStocksParser : IStockSourceParser
    {
        public StockList Parse(string path)
        {
            using (TextFieldParser textFieldParser = new TextFieldParser(path))
            {
                textFieldParser.Delimiters = new string[] { "," };

                // Skip first row with names
                textFieldParser.ReadLine();
                var stockList = new List<Stock>();

                while (!textFieldParser.EndOfData)
                {
                    string[] fields = textFieldParser.ReadFields();
                    var name = fields[0];
                    var date = DateTime.Parse(fields[1]);
                    var price = float.Parse(fields[2]);
                    var volume = float.Parse(fields[3]);

                    stockList.Add(new Stock() { Name = name, Price = price, Volume = volume, Date = date });
                }
                return new StockList(stockList);
            }
        }
    }
}