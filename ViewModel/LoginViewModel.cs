using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevicMonitor.Common;
using DevicMonitor.Model;

namespace DevicMonitor.ViewModel
{
    class LoginViewModel

    {
        public CommandBase CloseWindowCommand {  get; set; }

        public LoginModel LoginModel { get; set; }

        public LoginViewModel()
        {
            Console.WriteLine("准备初始化command");
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<Object>((obj) =>
            {
                (obj as Window).Close();

            });

            this.CloseWindowCommand.canDoExecute = new Func<object, bool>((obj) =>
            {

                return true;
            });

            this.LoginModel = new LoginModel();
        }


    }
}
