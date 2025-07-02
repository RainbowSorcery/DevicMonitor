using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevicMonitor.Common;

namespace DevicMonitor.Model
{
    class LoginModel : NotifyBase
    {
		private string _username;

		public string Username
		{
			get { return _username; }
			set { 
				_username = value;
				DoNotify();
			}
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set {
				_password = value;
				DoNotify();
			}
		}

		private string _capatcha	;

		public string Capatcha
        {
			get { return _capatcha; }
			set { _capatcha = value; DoNotify(); }
		}
			

	}
}
