using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaVisual.Interfaces
{
    internal interface ICommunicationServices
    {
        void SendMessage(string message, string queueName);
        void ProcessMessage(string queueName, bool consumeAll = false);
    }
}
