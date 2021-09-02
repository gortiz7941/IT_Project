using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Project.ClassLibrary;
using IT_Project.Database;
using System.Data.Common;
using System.Collections.ObjectModel;


namespace IT_Project.Entity
{
    public class User : ViewModelBase
    {
        public User(int Id, string username,string password, string firstname, string lastname, bool isLoggedIn)
        {
            this.ID = Id;
            this.UserName = username;
            this.Password = password;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.IsLoggedIn = isLoggedIn;

        }

        public User()
        {
        }
        #region Private fields & mutators and accessors
        private int _ID;
        private string _UserName, _Password, _FirstName,
            _LastName;
        private bool _IsLoggedIn;

        public int ID { 
            get { return _ID; }
            set 
            {
                _ID = value;
                RaisePropertyChanged("ID");
            }
        }
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public bool IsLoggedIn
        {
            get { return _IsLoggedIn; }
            set
            {
                _IsLoggedIn = value;
                RaisePropertyChanged("IsLoggedIn");

            }
        }

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value.ToString();
                RaisePropertyChanged("Password");
            }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        #endregion

    }
}
