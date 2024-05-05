using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseMgmtSystem.Entity
{
    public class Article
    {
        public string Name { get; set; }
        public int SKU { get; set; }
        public int Quantity { get; set; }
        public int StoragePlace { get; set; }
        public string Supplier { get; set; }

        public Article(string name, int sku, int quantity, int storagePlace, string supplier)
        {
            Name = name;
            SKU = sku;
            Quantity = quantity;
            StoragePlace = storagePlace;
            Supplier = supplier;
        }
    }

}
