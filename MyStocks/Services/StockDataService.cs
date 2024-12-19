using System.Net.Http;
using System.Text.Json;
using MyStocks.Models;

namespace MyStocks.Services
{
    public class StockDataService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://api.finance.ifeng.com/akdaily/?code={0}&type=last";

        public StockDataService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<StockModel> GetStockDataAsync(string code)
        {
            try
            {
                string url = string.Format(BaseUrl, FormatStockCode(code));
                var response = await _httpClient.GetStringAsync(url);
                // TODO: 解析返回的JSON数据
                return new StockModel(); // 临时返回空对象
            }
            catch (Exception ex)
            {
                // TODO: 处理异常
                return null;
            }
        }

        private string FormatStockCode(string code)
        {
            if (code.StartsWith("6"))
                return $"sh{code}";
            return $"sz{code}";
        }
    }
}