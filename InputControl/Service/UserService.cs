using System;

namespace InputControl.Service
{
    public class UserService : IUserService
    {
        private readonly string _login;

        public UserService()
        {
            string[] cmdLineArgs = Environment.GetCommandLineArgs();
            if (cmdLineArgs.Length > 1)
                _login = cmdLineArgs[1];
            else
                _login = Environment.UserName;
        }

        public string Login {
            get { return _login; }
        }
    }
}