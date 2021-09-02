using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Project.ClassLibrary
{
    public class MessangerEventArguments
    {
        public MessangerEventArguments() : base()
        {
        }

        public MessangerEventArguments(string description, object package) : base()
        {
            MessageName = description;
            MessagePackage = package;

        }

        public string MessageName { get; set; }
        public object MessagePackage { get; set; }

    }
}
