using MyStocks.Services;
using MyStocks.ViewModels;
using MyStocks.Views;
using peano.mystocks.config.library;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MyStocks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Prism 框架提供的方法，用于创建应用程序的主窗口
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 负责注册依赖注入容器中的类型或服务
        /// </summary>
        /// <param name="containerRegistry">IContainerRegistry 是 Prism 提供的接口，用于注册应用程序中需要的依赖对象。</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // containerRegistry.Register<ISomeService, SomeService>();
            // containerRegistry.Register<MainViewModel>(); //瞬时：每次请求都会创建一个新的实例
            containerRegistry.Register<IConfigService, XmlConfigService>();
            //containerRegistry.Register<IStocksService,StocksService>();
            // 注册导航
            containerRegistry.RegisterForNavigation<MainWindow,MainViewModel>();
        }
    }

}
