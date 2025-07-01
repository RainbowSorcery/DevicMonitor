using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DevicMonitor.Common
{
    class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return canDoExecute?.Invoke(parameter) == true;
        }

        public void Execute(object? parameter)
        {
            DoExecute?.Invoke(parameter);
        }


        public Action<Object> DoExecute { get; set; }

         public Func<Object, bool> canDoExecute { get; set; }
    }
}
