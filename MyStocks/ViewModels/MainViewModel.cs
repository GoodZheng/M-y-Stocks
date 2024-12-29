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
using peano.mystocks.config.library;
using MyStocks.Services;

namespace MyStocks.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<Stock> stocks;
        private MainWindowConfig mainWindowConfigs;
        private string currentTime;
        private string addingStockCode;
        private readonly DispatcherTimer timer;
        // 服务
        private readonly IConfigService _configService;
        private readonly IStocksService _stocksService;
        // 命令
        public CloseWindowCommand CloseWindowCommand { get; }
        public ToggleTopmostCommand ToggleTopmostCommand { get; }
        public ICommand SubmitStockCodeCommand { get; }

        // 属性
        public ObservableCollection<Stock> Stocks
        {
            get => stocks;
            set => SetProperty(ref stocks, value);  // 使用 SetProperty 来通知属性变化
        }
        public float Opacity
        {
            get => mainWindowConfigs.Opacity;
            set
            {
                if (mainWindowConfigs.Opacity != value)
                {
                    mainWindowConfigs.Opacity = value;
                    RaisePropertyChanged(nameof(Opacity));
                    try
                    {
                        _configService.Save(mainWindowConfigs);
                    }
                    catch (Exception ex)
                    {
                        LogService.Error($"保存配置文件失败, 错误信息: {ex.Message}; StackTrace: {ex.StackTrace}");
                    }
                }
            }
        }

        public bool IsTopmost
        {
            get => mainWindowConfigs.IsTopmost;
            set
            {
                if(mainWindowConfigs.IsTopmost != value)
                {
                    mainWindowConfigs.IsTopmost = value;
                    RaisePropertyChanged(nameof(IsTopmost));
                    try
                    {
                        _configService.Save(mainWindowConfigs);
                    }
                    catch (Exception ex)
                    {
                        LogService.Error($"保存配置文件失败, 错误信息: {ex.Message}; StackTrace: {ex.StackTrace}");
                    }
                }
            }
        }

        public string CurrentTime
        {
            get => currentTime;
            set => SetProperty(ref currentTime, value);
        }

        public int StockCount
        {
            get => mainWindowConfigs.StockCodes?.Count ?? 0;
        }

        public string AddingStockCode
        {
            get => addingStockCode;
            set
            {
                SetProperty(ref addingStockCode, value);
            }
        }

        public MainViewModel(IConfigService configService, IStocksService stocksService)
        {
            // 拿到服务
            _configService = configService;
            _stocksService = stocksService;

            // 初始化数据
            stocks = GeAllStocks();
            mainWindowConfigs = GetMainWindowConfigs();
            currentTime = DateTime.Now.ToString("HH:mm:ss");
            addingStockCode = "";
            // 初始化命令
            CloseWindowCommand = new CloseWindowCommand();
            ToggleTopmostCommand = new ToggleTopmostCommand();
            SubmitStockCodeCommand = new SubmitStockCodeCommand(OnSubmitStockCode, CanSubmitStockCode);

            // 定时任务
            timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1), // 设置为每秒钟更新一次
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private MainWindowConfig GetMainWindowConfigs()
        {
            try
            {
                return _configService.Load<MainWindowConfig>();
            }
            catch (Exception ex)
            {
                LogService.Error($"获取配置文件失败, 错误信息: {ex.Message}; StackTrace: {ex.StackTrace}");
                return new MainWindowConfig
                {
                    Opacity = 1.0f
                };
            }
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
                PreviousPrice = 14.44m
            });
            stocks.Add(new Stock
            {
                Code = "000002",
                Name = "万科A",
                CurrentPrice = 28.90m,
                HighPrice = 29.00m,
                LowPrice = 28.80m,
                OpenPrice = 28.85m,
                PreviousPrice = 24.99m
            });
            return stocks;
        }

        private async void OnSubmitStockCode(string addingStockCode)
        {
            try
            {
                // 在这里实现提交股票代码的逻辑
                if (!string.IsNullOrEmpty(addingStockCode))
                {
                    // 执行查询或其他操作
                    if (await _stocksService.CheckStockCodeExistsAsync(addingStockCode))
                    {
                        mainWindowConfigs.StockCodes.Add(addingStockCode);
                        _configService.Save(mainWindowConfigs);
                        LogService.Info($"添加股票代码 {addingStockCode} 成功");
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.Error($"添加股票代码失败, 错误信息: {ex.Message}; StackTrace: {ex.StackTrace}");
            }
        }
        private bool CanSubmitStockCode(string addingStockCode)
        {
            return !string.IsNullOrEmpty(addingStockCode);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            Stocks = new ObservableCollection<Stock>(Stocks);
        }

    }
}
