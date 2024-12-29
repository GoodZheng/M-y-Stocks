using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyStocks.Commands
{
    public class SubmitStockCodeCommand: DelegateCommand<string>
    {
        public SubmitStockCodeCommand(Action<string> executeMethod, Func<string, bool> canExecuteMethod)
            : base(executeMethod, canExecuteMethod)
        {

        }
    }
}
