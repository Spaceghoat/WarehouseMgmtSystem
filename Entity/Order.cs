using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtSystem.Entity
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public List<Article> Articles { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Order(int orderNumber, List<Article> articles, DateTime orderDate, DateTime deliveryDate)
        {
            OrderNumber = orderNumber;
            Articles = articles;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
        }
    }
}
