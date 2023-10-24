using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PizzeriaVisual.Interfaces
{
    internal interface IDeliveryServices
    {
        Delivery CreateDelivery(string name, string surname, string phoneNumber);

        Delivery FindDeliveryByPhoneNumber(string phoneNumber);
    }
}
