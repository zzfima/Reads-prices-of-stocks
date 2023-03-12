using Service.Models;

namespace Service.Interfaces
{
    public interface IStockSourceParser
    {
        LowestStocks Parse(string path);
    }
}
