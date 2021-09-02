using IT_Project.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Project.Entity;
using System.Collections;

namespace IT_Project.ViewModels
{
    class ReportViewModel : ViewModelBase
    {
        public ReportViewModel() : base()
        {
        }


        public List<Database.Service_Request> LoadReportData()
        {
            var reportRequests = new List<Database.Service_Request>();
            using(var context = new Database.IT_DatabaseEntities())
            {
                reportRequests = context.Service_Request.Where(sr => sr.ticket_status.Equals("Open")).ToList();
            }
            return reportRequests;
        }
    }
}
