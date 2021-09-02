using IT_Project.ClassLibrary;
using IT_Project.ViewModels;
using IT_Project.Database;
using System;
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

namespace IT_Project.UserControls
{
    /// <summary>
    /// Interaction logic for RequestView.xaml
    /// </summary>
    public partial class RequestControl : UserControl
    {
        public RequestControl()
        {
            InitializeComponent();
            _viewModel = (RequestViewModel)this.Resources["viewModel"];

        }

        

        private RequestViewModel _viewModel = null;
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveRequestChanges(addMessage.Text);
            addMessage.Clear();
            _viewModel.Close();



        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CancelTicket();
            _viewModel.Close();
        }

        public void LoadUpOnStart(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadOnStartUp();
        }

        private void CloseTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CloseTicket();
            _viewModel.Close();

            
        }
    }
}
