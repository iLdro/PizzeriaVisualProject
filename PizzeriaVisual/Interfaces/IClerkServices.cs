using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaVisual.Interfaces
{
    internal interface IClerkServices
    {
        int CreateClerk(string name, string surname, string address, string phoneNumber);
       
    }
}
