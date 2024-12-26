using peano.mystocks.entity.library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows;
using peano.mystocks.log.library;
using MyStocks.Commands;

namespace MyStocks.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<Stock> stocks;
        private MainWindowConfig mainWindowConfigs;

        private readonly DispatcherTimer timer;

        public CloseWindowCommand CloseWindowCommand { get; }


        // 绑定到 View 的数据源
        public ObservableCollection<Stock> Stocks
        {
            get => stocks;
            set => SetProperty(ref stocks, value);  // 使用 SetProperty 来通知属性变化
        }

        public MainWindowConfig MainWindowConfigs
        {
            get => mainWindowConfigs;
            set => SetProperty(ref mainWindowConfigs, value);
        }

        public MainViewModel()
        {
            // 初始化数据
            stocks = GeAllStocks();

            mainWindowConfigs = GetMainWindowConfigs();

            CloseWindowCommand = new CloseWindowCommand();




            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // 设置为每秒钟更新一次
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private MainWindowConfig GetMainWindowConfigs()
        {
            return new MainWindowConfig
            {
                Opacity = 1.0f
            }; 
        }

        private ObservableCollection<Stock> GeAllStocks()
        {
            ObservableCollection<Stock> stocks = new ObservableCollection<Stock>();
            stocks.Add(new Stock
            {
                Code = "000001",
                Name = "平安银行",
                CurrentPrice = 15.68m,
                HighPrice = 16.00m,
                LowPrice = 15.50m,
                OpenPrice = 15.60m,
            });
            stocks.Add(new Stock
            {
                Code = "000002",
                Name = "万科A",
                CurrentPrice = 28.90m,
                HighPrice = 29.00m,
                LowPrice = 28.80m,
                OpenPrice = 28.85m,
            });
            return stocks;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            foreach (var stock in Stocks)
            {
                stock.UpdateTime = DateTime.Now;
            }
            Stocks = new ObservableCollection<Stock>(Stocks);
        }

    }
}
