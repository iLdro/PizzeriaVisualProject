using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PizzeriaVisual.Interfaces
{
    internal interface IDeliveryServices
    {
        int CreateDelivery(string name, string surname, string address, string phoneNumber);
    }
}
