using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BCrypt.Net;
using DevicMonitor.Common;
using DevicMonitor.DataAccess;
using DevicMonitor.Model;

namespace DevicMonitor.ViewModel
{
    class LoginViewModel : NotifyBase

    {
        public CommandBase CloseWindowCommand {  get; set; } = new CommandBase();

        public CommandBase LoginCommand { get; set; } = new CommandBase();

        public LoginModel LoginModel { get; set; } = new LoginModel();


        UserDataAccess userDataAccess = new UserDataAccess();



        private string _errorMsg;   

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; DoNotify();  }
        }


        public LoginViewModel()
        {
            this.LoginModel.Username = "lyra";
            this.LoginModel.Password = "admin123456";
            this.LoginModel.Capatcha= "3n3d";

            this.CloseWindowCommand.DoExecute = new Action<Object>((obj) =>
            {
                (obj as Window).Close();
            });

            this.CloseWindowCommand.canDoExecute = new Func<object, bool>((obj) =>
            {

                return true;
            });

            this.LoginCommand.canDoExecute = new Func<object, bool>((obj) =>
            {
                return true;
            });

            this.LoginCommand.DoExecute = new Action<Object>(CheckDoLogin);

        }


        private void CheckDoLogin(Object o)
        {

            string username = this.LoginModel.Username;
            string password = this.LoginModel.Password;
            string capatcha = this.LoginModel.Capatcha;

            if (string.IsNullOrEmpty(username))
            {
                this.ErrorMsg = "用户名不能为空";
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                this.ErrorMsg = "密码不能为空";
                return; 
            }


            if (string.IsNullOrEmpty(capatcha))
            {
                this.ErrorMsg = "验证码不能为空";
                return;
            }

            if (capatcha.ToUpper() != "3N3D")
            {
                this.ErrorMsg = "验证码错误";
                return;
            }

            UserModel loginUserModel = userDataAccess.Users
                .FirstOrDefault(b => b.Username == username);


            if (loginUserModel == null)
            {
                this.ErrorMsg = "用户不存在";
                return;
            }

            bool checkResult = BCrypt.Net.BCrypt.Verify(password, loginUserModel.Password);

            if (!checkResult)
            {
                this.ErrorMsg = "密码错误";
                return;
            }
            

            this.ErrorMsg = "";
            GlobalValues.CurrentUser = loginUserModel;

            // 登录成功，关闭窗口
            if (o is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
            else
            {
                this.ErrorMsg = "登录成功";
            }

        }


    }
}
