using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using peano.mystocks.config.library;

namespace MyStocks.Services
{
    class StocksService : IStocksService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public async Task<bool> CheckStockCodeExistsAsync(string stockCode)
        {
            string url = string.Format(ConfigConstants.HostSinaAPI,stockCode);
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                throw;
            }
        }
        //验证股票代码是上交所 深交所 还是北交所
        public async Task<string> CheckStockCodeTypeAsync(string stockCode)
        {
            string urlsz = string.Format(ConfigConstants.HostSinaAPI, "sz" + stockCode);
            string urlsh = string.Format(ConfigConstants.HostSinaAPI, "sh" + stockCode);
            string urlbj = string.Format(ConfigConstants.HostSinaAPI, "bj" + stockCode);
            try
            {
                HttpResponseMessage responsesz = await httpClient.GetAsync(urlsz);
                HttpResponseMessage responsesh = await httpClient.GetAsync(urlsh);
                HttpResponseMessage responsebj = await httpClient.GetAsync(urlbj);
                if (responsesz.IsSuccessStatusCode)
                {
                    return "sz" + stockCode;
                }
                else if (responsesh.IsSuccessStatusCode)
                {
                    return "sh" + stockCode;
                }
                else if (responsebj.IsSuccessStatusCode)
                {
                    return "bj" + stockCode;
                }
                else
                {
                    return "error";
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
