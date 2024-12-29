using System;
using System.Collections.Generic;
using System.Text;

namespace peano.mystocks.entity.library
{
    public class MainWindowConfig
    {
        //// 把这个类设置为单例模式
        //private static readonly MainWindowConfig instance = new MainWindowConfig();
        //public static MainWindowConfig Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}
        //private MainWindowConfig(){}

        public float Opacity { get; set; } = 1;

        public bool IsTopmost { get; set; } =false;

        public List<string> StockCodes { get; set; } = new List<string>();
    }
}
