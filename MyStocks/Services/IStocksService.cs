using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStocks.Services
{
    public interface IStocksService
    {
        // 验证股票代码是否合法
        Task<bool> CheckStockCodeExistsAsync(string stockCode);
    }
}
