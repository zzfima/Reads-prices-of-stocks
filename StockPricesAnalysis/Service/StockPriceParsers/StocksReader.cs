using Service.Interfaces;
using Service.Models;

namespace Service.StockPriceReaders
{
    public class StocksReader : IStockReader, IDisposable
    {
        private StockList? _stocks;
        private CancellationTokenSource _source;
        private CancellationToken _token;
        private bool _disposed;

        private IStockSourceParser _stockSourceParser;

        public StocksReader(IStockSourceParser stockSourceParser)
        {
            _source = new CancellationTokenSource();
            _token = _source.Token;
            _stocks = null;
            _stockSourceParser = stockSourceParser;
        }

        #region Implement IStockReader
        public async Task StartReadAsync(string path, TimeSpan readFrequency)
        {
            while (!_token.IsCancellationRequested)
            {
                await UpdateStockPricesAsync(path);
                await Task.Delay(readFrequency, _token);
            }
        }

        public async Task StopReadAsync()
        {
            await Task.Run(() => _source.Cancel());
        }
        #endregion

        private async Task UpdateStockPricesAsync(string path)
        {
            _stocks = await Task.Run(() => _stockSourceParser.Parse(path));
        }

        #region Dispose
        ~StocksReader() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _source.Cancel();
                    _source.Dispose();
                }

                //dispose unmanaged resources

                _disposed = true;
            }
        }

        #endregion
    }
}