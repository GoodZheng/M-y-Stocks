using Microsoft.IdentityModel.Logging;
using MyStocks.Converters;
using MyStocks.ViewModels;
using NLog;
using peano.mystocks.dac.library;
using peano.mystocks.entity.library;
using peano.mystocks.log.library;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyStocks.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private static readonly NLog.Logger logger = LogHelper.lo
        public MainWindow()
        {
            TopmostToContentConverter s = new TopmostToContentConverter();
            


            InitializeComponent();

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.DragMove();
        }
    }
}