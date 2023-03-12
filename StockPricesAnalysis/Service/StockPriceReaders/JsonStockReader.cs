using Newtonsoft.Json;
using Service.Interfaces;
using Service.Models;
using System.Threading;

namespace Service.StockPriceReaders
{
    public class JsonStockReader : IStockReader, IDisposable
    {
        private StockList? _stocks;
        private CancellationTokenSource _source;
        private CancellationToken _token;
        private bool _disposed;

        public JsonStockReader()
        {
            _source = new CancellationTokenSource();
            _token = _source.Token;
            _stocks = null;
        }

        public async Task StartReadAsync(string path, TimeSpan readFrequency)
        {
            while (!_token.IsCancellationRequested)
            {
                await UpdateStockPrices(path);
                await Task.Delay(readFrequency, _token);
            }
        }

        public void StopRead()
        {
            _source.Cancel();
        }

        private async Task UpdateStockPrices(string path)
        {
            var text = await File.ReadAllTextAsync(path);
            var stocks = JsonConvert.DeserializeObject<Stock[]>(text);
            _stocks = new StockList(stocks);
        }

        #region Dispose
        ~JsonStockReader() => Dispose(false);

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
                    StopRead();
                    _source.Dispose();
                }

                //dispose unmanaged resources

                _disposed = true;
            }
        }

        #endregion
    }
}