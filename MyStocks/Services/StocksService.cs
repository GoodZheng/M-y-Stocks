using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using peano.mystocks.config.library;

namespace MyStocks.Services
{
    class StocksService //: IStocksService
    {
        //private static readonly HttpClient httpClient = new HttpClient();
        //public async Task<bool> CheckStockCodeExistsAsync(string stockCode)
        //{
        //    string url = string.Format(ConfigConstants.HostSinaAPI,stockCode);
        //    try
        //    {
        //        HttpResponseMessage response = await httpClient.GetAsync(url);
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        ////验证股票代码是上交所 深交所 还是北交所
        //public async Task<string> CheckStockCodeTypeAsync(string stockCode)
        //{
        //    string urlsz = string.Format(ConfigConstants.HostSinaAPI, "sz" + stockCode);
        //    string urlsh = string.Format(ConfigConstants.HostSinaAPI, "sh" + stockCode);
        //    string urlbj = string.Format(ConfigConstants.HostSinaAPI, "bj" + stockCode);
        //    try
        //    {
        //        HttpResponseMessage responsesz = await httpClient.GetAsync(urlsz);
        //        HttpResponseMessage responsesh = await httpClient.GetAsync(urlsh);
        //        HttpResponseMessage responsebj = await httpClient.GetAsync(urlbj);
        //        if (responsesz.IsSuccessStatusCode)
        //        {
        //            return "sz" + stockCode;
        //        }
        //        else if (responsesh.IsSuccessStatusCode)
        //        {
        //            return "sh" + stockCode;
        //        }
        //        else if (responsebj.IsSuccessStatusCode)
        //        {
        //            return "bj" + stockCode;
        //        }
        //        else
        //        {
        //            return "error";
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        private readonly HttpClient _httpClient;

        public StocksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendRequestAsync(string apiName, string token, object parameters, string fields)
        {
            // 创建请求体
            var requestBody = new
            {
                api_name = apiName,
                token = token,
                parameters = parameters,
                fields = fields
            };

            // 将请求体序列化为 JSON
            var jsonContent = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // 发送 POST 请求
            var response = await _httpClient.PostAsync("https://api.tushare.pro/", content);

            // 确保请求成功
            response.EnsureSuccessStatusCode();

            // 读取响应内容
            return await response.Content.ReadAsStringAsync();
        }

    }
}
