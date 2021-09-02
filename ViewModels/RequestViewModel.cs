using IT_Project.ClassLibrary;
using IT_Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Project.ViewModels
{
    class RequestViewModel : ViewModelBase
    {
        public RequestViewModel() : base()
        {
            Messanger.Instance.MessageRecieved += Instance_MessageRecieved;
        }

        private Service_Request _CurrentRequest;
        private const string CLOSE_TICKET = "Closed";
        public Service_Request CurrentRequest
        {
            get { return _CurrentRequest; }
            set
            {
                _CurrentRequest = value;
                RaisePropertyChanged("CurrentRequest");
            }
        }

        private void Instance_MessageRecieved(object carrier, MessangerEventArguments e)
        {
            if (e.MessageName == Messages.REQUEST_RECEIVED)
            {
                CurrentRequest = (Service_Request)e.MessagePackage;
            }
        }

        public void SaveRequestChanges(string msg)
        {
            CurrentRequest.message = string.Format("{0} \nMessage added {1: dd/MM/yyyy} \n{2}", CurrentRequest.message, DateTime.Now, msg);

            using (var context = new Database.IT_DatabaseEntities())
            {
                var dbTicket = context.Service_Request.First(t => t.Id.Equals(CurrentRequest.Id));
                context.Database.Log = Console.Write;
                Console.WriteLine(dbTicket.ToString());
                dbTicket.message = CurrentRequest.message;

                context.SaveChanges();

            }
            Messanger.Instance.SendMessage(Messages.RESET_TICKET);
        }

        public void CloseTicket()
        {
            if (CurrentRequest.ticket_status != CLOSE_TICKET) {
                using (var context = new Database.IT_DatabaseEntities())
                {
                    var dbTicket = context.Service_Request.First(t => t.Id.Equals(CurrentRequest.Id));
                    context.Database.Log = Console.Write;
                    Console.WriteLine(dbTicket.ToString());
                    dbTicket.ticket_status = CLOSE_TICKET;

                    context.SaveChanges();
                }
            }
            
            Messanger.Instance.SendMessage(Messages.RESET_TICKET);
        }

        public void CancelTicket()
        {
            Messanger.Instance.SendMessage(Messages.RESET_TICKET);
        }

        public void LoadOnStartUp()
        {
            Messanger.Instance.SendMessage(Messages.SEND_TICKET);
        }
    }

}
