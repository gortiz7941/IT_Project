//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IT_Project.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service_Request
    {
        public int Id { get; set; }
        public System.DateTime date_created { get; set; }
        public Nullable<System.DateTime> date_completed { get; set; }
        public string technician_name { get; set; }
        public string description { get; set; }
        public string message { get; set; }
        public string ticket_status { get; set; }

        public Service_Request() { }
        public Service_Request(int id, DateTime create, DateTime completed,
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

        public Service_Request(int id, DateTime date_created, string technician_name, string description, string message, string ticket_status)
        {
            Id = id;
            this.date_created = date_created;
            this.technician_name = technician_name;
            this.description = description;
            this.message = message;
            this.ticket_status = ticket_status;
        }

        public override string ToString()
        {
            return this.Id + " " + this.date_created + " " + this.date_completed + " " + this.technician_name + " " + this.description + " " + this.message;
        }
    }
}
