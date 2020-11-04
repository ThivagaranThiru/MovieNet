using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.Data.Service;
using MovieNet.Data;

namespace MovieNet.UI
{
    public class MainViewModel : ViewModelBase
    {
        private Façade facade;
        private string login;
        private string password;
        private Users user;
        private AddUserWindow addMovieWindow;
        public List<string> civiliteList { get; set; }
        public RelayCommand MyCommand { get; }
        public RelayCommand MyButtonAddUserCommand { get; }
        public RelayCommand MyAddUserCommand { get; }
        public RelayCommand MyDeleteUserCommand { get; }

        public MainViewModel()
        {
            facade = Façade.Instance();
            Login = "";
            Password = "";
            User = null;
            MyCommand = new RelayCommand(MyCommandExecute, MyCommandCanExecute);
            MyButtonAddUserCommand = new RelayCommand(MyButtonAddUserCommandExecute, MyButtonAddUserCommandCanExecute);
            MyAddUserCommand = new RelayCommand(MyAddUserCommandExecute, MyAddUserCommandCanExecute);
            MyDeleteUserCommand = new RelayCommand(MyDeleteUserCommandExecute, MyDeleteUserCommandCanExecute);
            civiliteList = new List<string>
            {
                "Mr.",
                "Mme."
            };
        }

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                RaisePropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public Users User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged("User");
            }
        }

        public void MyCommandExecute()
        {
            if (Login != "" && Password != "")
            {
                if (facade.Connexion(Login, Password) != null)
                {
                    HomePageWindow homePageWindow = new HomePageWindow();
                    VMLocator.HomePageVM.User = facade.Connexion(Login, Password);
                    homePageWindow.ShowDialog();
                }
                else
                {
                    Login = "";
                    Password = "";
                }
            }
        }

        public bool MyCommandCanExecute()
        {
            return true;
        }

        public void MyButtonAddUserCommandExecute()
        {
            if (Login != "" && Password != "")
            {
                if (facade.Connexion(Login, Password) != null)
                {
                    User = facade.Connexion(Login, Password);
                }else User = new Users();
            }
            else User = new Users();

            addMovieWindow = new AddUserWindow();
            addMovieWindow.ShowDialog();
        }

        public bool MyButtonAddUserCommandCanExecute()
        {
            return true;
        }

        public void MyAddUserCommandExecute()
        {
            if(User.Login != null && User.Password != null && User.Civilite != null && User.Nom != null && User.Prenom != null && User.DateNaissance != null)
            {
                if (Login != "" && Password != "")
                {
                    if (facade.Connexion(Login, Password) != null)
                    {
                        facade.UpdateUser(User);
                    }
                }
                else facade.AddUser(User);

                User = null;
                addMovieWindow.Close();
            }
        }

        public bool MyAddUserCommandCanExecute()
        {
            return true;
        }
        public void MyDeleteUserCommandExecute()
        {   
            if (Login != "" && Password != "")
            {
              if (facade.Connexion(Login, Password) != null)
              {
                  facade.DeleteUser(facade.Connexion(Login, Password));
                  Login = "";
                  Password = "";
              }
            }       
        }

        public bool MyDeleteUserCommandCanExecute()
        {
            return true;
        }
    }
}
