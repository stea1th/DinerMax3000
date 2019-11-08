using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerMax3000.Business
{
    public class Order
    {
        public List<MenuItem> items = new List<MenuItem>();

        public double Total
        {
            get
            {
                double calculatedTotal = 0;
                calculatedTotal = items.ConvertAll(item => item.Price).Sum();
                return calculatedTotal;
            }
        }
    }
}
