using MyStocks.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MyStocks
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<StockItem> Stocks { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Stocks = new ObservableCollection<StockItem>();
            StockListView.ItemsSource = Stocks;

            // 添加示例数据
            Stocks.Add(new StockItem { StockCode = "600519", StockName = "贵州茅台", CurrentPrice = "1899.99", ChangePercent = "+2.31%", PriceColor = new SolidColorBrush(Colors.Red) });
            Stocks.Add(new StockItem { StockCode = "000001", StockName = "平安银行", CurrentPrice = "12.34", ChangePercent = "-1.23%", PriceColor = new SolidColorBrush(Colors.Green) });
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            // TODO: 打开设置窗口
            var settingsWindow = new SettingsWindow(this);
            settingsWindow.Owner = this;
            settingsWindow.ShowDialog();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class StockItem
    {
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public string CurrentPrice { get; set; }
        public string ChangePercent { get; set; }
        public Brush PriceColor { get; set; }
    }
}