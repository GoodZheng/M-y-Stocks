using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MyStocks.Views
{
    public partial class SettingsWindow : Window
    {
        private readonly MainWindow _mainWindow;
        public ObservableCollection<string> StockCodes { get; set; }

        public SettingsWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            StockCodes = new ObservableCollection<string>();
            StockList.ItemsSource = StockCodes;
            LoadSettings();
        }

        private void LoadSettings()
        {
            TopMostCheck.IsChecked = _mainWindow.Topmost;
            OpacitySlider.Value = _mainWindow.Opacity;
            AutoStartCheck.IsChecked = IsAutoStartEnabled();
            // TODO: 加载保存的股票代码
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Topmost = TopMostCheck.IsChecked ?? false;
            _mainWindow.Opacity = OpacitySlider.Value;
            SetAutoStart(AutoStartCheck.IsChecked ?? false);
            // TODO: 保存股票代码
            Close();
        }

        private void AddStock_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StockCodeInput.Text))
            {
                StockCodes.Add(StockCodeInput.Text);
                StockCodeInput.Clear();
            }
        }

        private void RemoveStock_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is string stockCode)
            {
                StockCodes.Remove(stockCode);
            }
        }

        private bool IsAutoStartEnabled()
        {
            using var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            return key?.GetValue("MyStocks") != null;
        }

        private void SetAutoStart(bool enable)
        {
            using var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (enable)
            {
                string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                key?.SetValue("MyStocks", appPath);
            }
            else
            {
                key?.DeleteValue("MyStocks", false);
            }
        }
    }
}