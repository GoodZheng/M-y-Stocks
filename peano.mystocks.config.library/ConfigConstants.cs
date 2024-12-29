using System;
using System.Collections.Generic;
using System.Text;

namespace peano.mystocks.config.library
{
    public static class ConfigConstants
    {
        // xml配置文件路径
        public const string ConfigFilePath = "MyStocks.xml";
        // xml配置文件根节点名
        public const string RootElementName = "MyStocks";
        // api 请求地址
        public const string HostSinaAPI = "http://hq.sinajs.cn/list={0}";
    }
}
