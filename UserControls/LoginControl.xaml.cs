using IT_Project.ViewModels;
using IT_Project.ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;

namespace IT_Project.UserControls
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();

            _viewModel = (LoginViewModel)this.Resources["viewModel"];
        }
        private LoginViewModel _viewModel = null;


        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentUser.Password = pword.Password;
            _viewModel.Login();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Close();
        }
    }
}
