using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtSystem.Entity;

namespace WarehouseMgmtSystem.Controllers
{
    public class OrderHandler
    {
        ArticleHandler articleHandler = new ArticleHandler();
        public Order GenerateOrder(int noOfOrdersCreated) => new Order(noOfOrdersCreated, articleHandler.GenerateArticlesFromFile(), DateTime.Now, DateTime.Now.AddDays(3));

        public void BookOrderArticles(List<OrderRow> orderRowsToBook) => articleHandler.CheckOutArticles(orderRowsToBook);
    }
}
