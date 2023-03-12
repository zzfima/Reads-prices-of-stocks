using Service.Models;

namespace Service.Interfaces
{
    public interface IStockSourceParser
    {
        StockList Parse(string path);
    }
}
