using IT_Project.ViewModels;
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
    /// Interaction logic for ReportControl.xaml
    /// </summary>
    public partial class ReportControl : UserControl
    {
        public ReportControl()
        {
            InitializeComponent();
            _viewModel = (ReportViewModel)this.Resources["viewModel"];
        }

        private ReportViewModel _viewModel = null;

        public void PopulateReportDataGrid()
        {
            
            reportDataGrid.ItemsSource = _viewModel.LoadReportData();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Close();

        }

        private void LoadOnStartUp(object sender, RoutedEventArgs e)
        {
            PopulateReportDataGrid();
            

        }
    }
}
