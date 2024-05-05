using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtSystem.Entity
{
    public class OrderRow
    {
        public int OrderNumber { get; set; }
        public int RowNumber { get; set; }
        public string ArticleName { get; set; }
        public int SKU { get; set; }
        public int Quantity { get; set; }
        public int StoragePlace { get; set; }

        public OrderRow(int orderNumber, int rowNumber, string articleName, int sku, int quantity, int storagePlace)
        {
            OrderNumber = orderNumber;
            RowNumber = rowNumber;
            ArticleName = articleName;
            SKU = sku;
            Quantity = quantity;
            StoragePlace = storagePlace;
        }
    }
}
