using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaVisual.Interfaces
{
    internal interface IClientServices
    {
        int CreateClient(string name, string surname, string address, string phoneNumber);
        Client FindClientByPhoneNumber(string phoneNumber);
    }
}
