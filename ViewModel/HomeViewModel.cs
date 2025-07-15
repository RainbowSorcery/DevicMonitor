using DevicMonitor.Common;
using DevicMonitor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevicMonitor.ViewModel
{
    class HomeViewModel : NotifyBase
    {
        public CommandBase CloseWindowCommand {  get; set; } = new CommandBase();

        public CommandBase MaxWindowCommand { get; set; } = new CommandBase();

        public CommandBase MinWindowCommand { get; set; } = new CommandBase();

        public UserModel UserInfo { get; set; };

        public CommandBase NavCommand { get; set; };


        private string _search;

        public string Search
        {
            get { return _search; }
            set { _search = value; this.DoNotify(); }
        }

        private FrameworkElement _navEelement;

        public FrameworkElement NavElemnt
        {
            get { return _navEelement; }
            set { _navEelement = value; this.DoNotify(); }
        }



        public HomeViewModel()
        {
            this.UserInfo = GlobalValues.CurrentUser;


            this.CloseWindowCommand.canDoExecute = new Func<Object, bool>((obj) =>
            {
                return true; // 可以执行关闭窗口的操作
            });

            this.CloseWindowCommand.DoExecute = new Action<Object>((obj) =>
            {
                (obj as Window).Close();
            });

            this.MaxWindowCommand.canDoExecute = new Func<Object, bool>((obj) =>
            {
                return true; // 可以执行最大化窗口的操作
            }); 

            this.MaxWindowCommand.DoExecute = new Action<Object>((obj) =>
            {
                var window = obj as Window;
                if (window != null)
                {
                    if (window.WindowState == WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Normal; // 如果当前是最大化状态，则恢复到正常状态
                    }
                    else
                    {
                        window.WindowState = WindowState.Maximized; // 否则，设置为最大化状态
                    }
                }
            });

            this.MinWindowCommand.canDoExecute = new Func<Object, bool>((obj) =>
            {
                return true; // 可以执行最小化窗口的操作
            });

            this.MinWindowCommand.DoExecute = new Action<Object>((obj) =>
            {
                var window = obj as Window;
                if (window != null)
                {
                    window.WindowState = WindowState.Minimized; // 设置窗口为最小化状态
                }
            }); 


            this.NavCommand = new CommandBase();

            this.NavCommand.canDoExecute = new Func<Object, bool>((obj) =>
            {
                return true; // 可以执行导航操作
            }); 

            this.NavCommand.DoExecute = new Action<Object>(DoNavChanged);


        }


        public void DoNavChanged(Object o)
        {



        }
    }
}
