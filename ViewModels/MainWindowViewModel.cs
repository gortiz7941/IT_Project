using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using IT_Project.ClassLibrary;
using IT_Project.Entity;

namespace IT_Project.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _LoginMenuHeader = "Login";
        private User _CurrentUser = new User();
        private Database.Service_Request _Ticket = new Database.Service_Request();

        public string LoginMenuHeader
        {
            get { return _LoginMenuHeader; }
            set
            {
                _LoginMenuHeader = value;
                RaisePropertyChanged("LoginMenuHeader");
            }
        }
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set
            {
                _CurrentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        public Database.Service_Request Ticket
        {
            get { return _Ticket; }
            set { _Ticket = value;
                RaisePropertyChanged("Ticket");
            }
        }

        public List<Database.Service_Request> LoadTechnicianData()
        {
            var serviceRequests = new List<Database.Service_Request>();

            string technicianName = CurrentUser.FirstName + " " + CurrentUser.LastName;

            using (var context = new Database.IT_DatabaseEntities())
            {
                serviceRequests = context.Service_Request.Where(sr => sr.technician_name.Equals(technicianName)).ToList();
            }
            return serviceRequests;

        }

        public void OpenTicket()
        {

            
            Console.WriteLine("Message sent:  "+ Ticket.ToString());

        }
        public void AddMessageToTicket(string msg) 
        {
            Ticket.message = string.Format("{0} \nMessage added {1: dd/MM/yyyy} \n{2}", Ticket.message, DateTime.Now, msg);
            
            using (var context = new Database.IT_DatabaseEntities())
            {
                var dbTicket = context.Service_Request.First(t => t.Id.Equals(Ticket.Id));
                context.Database.Log = Console.Write;
                Console.WriteLine(dbTicket.ToString());
                dbTicket.message = Ticket.message;

                context.SaveChanges();
            

            }
        }
    } 
}
