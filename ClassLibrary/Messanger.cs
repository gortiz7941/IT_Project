using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Project.ClassLibrary
{
    public class Messanger
    {

        private static Messanger _Instance;

        public static Messanger Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Messanger();
                }

                return _Instance;
            }
            set { _Instance = value; }
        }


        public delegate void MessageRecievedHandler(object carrier, MessangerEventArguments e);

        public event MessageRecievedHandler MessageRecieved;

        public void SendMessage(string messageName)
        {
            SendMessage(messageName, null);
        }

        public void SendMessage(string messageName, object messagePackage)
        {
            MessangerEventArguments arg;
            arg = new MessangerEventArguments(messageName, messagePackage);
            RaiseMessageRecieved(arg);
        }

        protected void RaiseMessageRecieved(MessangerEventArguments e)
        {
            if (MessageRecieved != null)
            {
                MessageRecieved(this, e);
            }
        }
    }
}
