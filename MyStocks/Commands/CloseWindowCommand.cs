using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyStocks.Commands
{
    public class CloseWindowCommand : DelegateCommand<Window>
    {
        public CloseWindowCommand() : base(ExecuteClose)
        {
        }

        // 执行关闭窗体的方法
        // 执行关闭窗体的方法
        private static void ExecuteClose(Window window)
        {
            // 检查 window 是否为空，避免出现空引用异常
            window?.Close();
        }
    }
}
