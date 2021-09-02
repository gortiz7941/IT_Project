 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IT_Project.ClassLibrary;
using IT_Project.Entity;
using IT_Project.ViewModels;

namespace IT_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (MainWindowViewModel)this.Resources["viewModel"];
            Messanger.Instance.MessageRecieved += Instance_MessageRecieved;
        }

        private void Instance_MessageRecieved(object carrier, MessangerEventArguments e)
        {

            switch (e.MessageName)
            {
                case Messages.LOGIN_SUCCESS:
                    _viewModel.CurrentUser = (User)e.MessagePackage;
                    _viewModel.LoginMenuHeader = "Logout " + _viewModel.CurrentUser.FirstName;
                    PopulateHomeDataGrid();
                    break;

                case Messages.LOGOUT:
                    _viewModel.CurrentUser.IsLoggedIn = false;
                    _viewModel.LoginMenuHeader = "Login";

                    break;

                case Messages.CLOSE_USER_CONTROL:
                    CloseView();
                    break;
                case Messages.SEND_TICKET:
                    Messanger.Instance.SendMessage( Messages.REQUEST_RECEIVED, _viewModel.Ticket);
                    break;

                case Messages.RESET_TICKET:
                    ReloadDataGrid();
                    break;
            }
        }

        private MainWindowViewModel _viewModel = null;

        private const string LOGIN_VIEW = "IT_Project.UserControls.LoginControl";
        private const string REPORT_VIEW = "IT_Project.UserControls.ReportControl";
        private const string REQUEST_VIEW = "IT_Project.UserControls.RequestControl";

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            switch (item.Tag.ToString())
            {
                case "login":
                    if (_viewModel.CurrentUser.IsLoggedIn)
                    {
                        CloseView();
                        _viewModel.CurrentUser = new User();
                        _viewModel.LoginMenuHeader = "Login";
                        ClearDataGrid();
                    }
                    else
                    {
                        LoadView(LOGIN_VIEW.ToString());
                    }
                    break;

                case "genReport":
                    LoadView(REPORT_VIEW.ToString());
                    break;

                case "exit":
                    this.Close();
                    break;
            }

        }

        private void PopulateHomeDataGrid() 
        {
            serviceRequestsDataGrid.ItemsSource = _viewModel.LoadTechnicianData();
        }

        private void ClearDataGrid()
        {
            serviceRequestsDataGrid.ItemsSource = null;
            
        }

        private void LoadView(string viewName)
        {
            Type ucType = null;
            UserControl uc = null;
            ucType = Type.GetType(viewName);
            if (ucType == null)
            {
                MessageBox.Show("The view: " + viewName + " does not exits.");
            }
            else
            {
                CloseView();

                uc = (UserControl)Activator.CreateInstance(ucType);
                if (uc != null)
                {
                    ShowView(uc);
                }
            }

        }

        private void ShowView(UserControl uc)
        {
            contentArea.Children.Add(uc);
        }
        private void CloseView()
        {
            contentArea.Children.Clear();
        }

        private void openServiceTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
             
             
             
             */
            try
            {
                if (!string.IsNullOrEmpty(_viewModel.Ticket.technician_name))
                {
                    LoadView(REQUEST_VIEW.ToString());
                    //TicketPopup.IsOpen = true;
                }
                else {
                    MessageBoxButton mBtn = MessageBoxButton.OK;
                    string mBoxMessage = "Please Make a Selection.";
                    string mBoxTitle = "Selection Error";
                    MessageBox.Show(mBoxMessage, mBoxTitle, mBtn);
                }
            }
            catch(NullReferenceException err)
            {

                Console.WriteLine(err);
            }  
        }

        private void GetCells(object sender, SelectedCellsChangedEventArgs e)
        {
            _viewModel.Ticket = serviceRequestsDataGrid.SelectedItem as Database.Service_Request;
        }

        /*private void CancelBtn_Click (object sender, RoutedEventArgs e)
        {
            TicketPopup.IsOpen = false;
            ReloadDataGrid();
            _viewModel.Ticket = new Database.Service_Request();

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddMessageToTicket(addMessage.Text);
            addMessage.Clear();
            TicketPopup.IsOpen = false;
            ReloadDataGrid();
            _viewModel.Ticket = new Database.Service_Request();
        }*/
        private void ReloadDataGrid()
        {
            ClearDataGrid();
            PopulateHomeDataGrid();
            _viewModel.Ticket = new Database.Service_Request();
        }
    }
}
