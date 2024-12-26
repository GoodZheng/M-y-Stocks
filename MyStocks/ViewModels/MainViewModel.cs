using peano.mystocks.entity.library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MyStocks.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<Stock> stocks;
        private readonly MainWindowConfig mainWindowConfig;

        private readonly DispatcherTimer timer;

        // 绑定到 View 的数据源
        public ObservableCollection<Stock> Stocks
        {
            get => stocks;
            set => SetProperty(ref stocks, value);  // 使用 SetProperty 来通知属性变化
        }

        public MainViewModel()
        {
            // 示例数据，通常你会从服务或数据库中获取
            Stocks = new ObservableCollection<Stock>();
            InitializeStocks();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // 设置为每秒钟更新一次
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void InitializeStocks()
        {
            Stocks.Add(new Stock
            {
                Code = "000001",
                Name = "平安银行",
                CurrentPrice = 15.68m,
                HighPrice = 16.00m,
                LowPrice = 15.50m,
                OpenPrice = 15.60m,
            });
            Stocks.Add(new Stock
            {
                Code = "000002",
                Name = "万科A",
                CurrentPrice = 28.90m,
                HighPrice = 29.00m,
                LowPrice = 28.80m,
                OpenPrice = 28.85m,
            });
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Stocks.Add(new Stock
            //{
            //    Code = "000001",
            //    Name = "平安银行",
            //    CurrentPrice = 15.68m,
            //    HighPrice = 16.00m,
            //    LowPrice = 15.50m,
            //    OpenPrice = 15.60m,
            //});
            foreach (var stock in Stocks)
            {
                stock.UpdateTime = DateTime.Now;
            }
            Stocks = new ObservableCollection<Stock>(Stocks);
        }

    }
}
