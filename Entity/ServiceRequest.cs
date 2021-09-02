using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Project.ClassLibrary;
using System.Collections.ObjectModel;
using IT_Project.Database;

namespace IT_Project.Entity
{
  
    public class ServiceRequest : ViewModelBase
    {
        private int _Id;
        private string _technician_name, _description, _message, _ticket_status;
        private DateTime _date_created, _date_completed;

        public ServiceRequest()
        {

        }

        public ServiceRequest(int id, DateTime create, DateTime completed,
        string techName, string dscrptn, string msg, string status)
        {
            this.Id = id;
            this.date_created = create;
            this.date_completed = completed;
            this.technician_name = techName;
            this.description = dscrptn;
            this.message = msg;
            this.ticket_status = status;
        }

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                RaisePropertyChanged("Id");
            }
        }


        public DateTime date_created
        {
            get { return _date_created; }
            set
            {
                _date_created = value.Date;
                RaisePropertyChanged("date_created");
            }
        }


        public DateTime date_completed
        {
            get { return _date_completed; }
            set
            {
                _date_completed = value.Date;
                RaisePropertyChanged("date_completed");
            }
        }


        public string technician_name
        {
            get { return _technician_name; }
            set
            {
                _technician_name = value;
                RaisePropertyChanged("technician_name");
            }
        }

        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("description");
            }

        }

        public string message 
        { 
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged("message");
            }
        }

        public string ticket_status
        {
            get { return _ticket_status; }
            set { _ticket_status = value;
                RaisePropertyChanged("ticket_status");
            }
        }

            
        
    }
}
