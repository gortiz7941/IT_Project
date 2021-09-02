using IT_Project.ClassLibrary;
using IT_Project.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IT_Project.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region LoginViewModel Constructor
        public LoginViewModel() : base()
        {
            CurrentUser = new User { UserName = Environment.UserName };
        }
        #endregion

        #region Login Error MessageBox
        MessageBoxButton mBtn = MessageBoxButton.OK;
        string mBoxMessage = "Invalid username or password.";
        string mBoxTitle = "Login Error";
        #endregion

        #region User Object 
        private User _CurrentUser;
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                _CurrentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }
        #endregion

        #region Login method 
        public void Login()
        {
            

            if (VerifyUserCredentials(CurrentUser.UserName, CurrentUser.Password))
            {

                Messanger.Instance.SendMessage(Messages.LOGIN_SUCCESS, CurrentUser);

                Close(false);
            }
            else 
            {
                _ = MessageBox.Show(mBoxMessage, mBoxTitle, mBtn);
            }

        }
        #endregion

        #region Verify User Credentials
        public bool VerifyUserCredentials(string username, string password)
        {
            bool ret = false;

            try
            {
                using (Database.IT_DatabaseEntities context = new Database.IT_DatabaseEntities())
                {
                    Database.User DbUser = context.Users.FirstOrDefault(u => u.Username == username);
                    if (DbUser != null && (DbUser.Password.Equals(password) && DbUser.Username.Equals(username)))
                    {
                        CurrentUser = new User(DbUser.ID, DbUser.Username, DbUser.Password, DbUser.Firstname, DbUser.Lastname, true);

                        ret = true;
                    }
                    return ret;
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("Exeption thrown: " + ex);
            }


            return ret;
        }
        #endregion



    }
}
