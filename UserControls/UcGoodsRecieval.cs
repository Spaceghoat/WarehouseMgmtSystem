using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseMgmtSystem.Entity;

namespace WarehouseMgmtSystem.UserControls
{
    public partial class UcGoodsRecieval : UserControl
    {
        ArticleHandler articleHandler = new ArticleHandler();
        public UcGoodsRecieval()
        {
            InitializeComponent();
            
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            Article newArticle;
            if (!string.IsNullOrEmpty(txtBoxArticleName.Text) && int.TryParse(txtBoxSKU.Text, out int sku) && int.TryParse(txtBoxQty.Text, out int quantity) && int.TryParse(txtBoxStorage.Text, out int storagePlace) && !string.IsNullOrEmpty(txtBoxSupplier.Text))
            {
                newArticle = new Article(txtBoxArticleName.Text, sku, quantity, storagePlace, txtBoxSupplier.Text);
                articleHandler.AddArticle(newArticle);
            }               
            else
                MessageBox.Show("Skriv in korrekta värden i alla fält");
        }
    }
}
