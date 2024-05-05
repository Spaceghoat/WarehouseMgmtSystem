using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseMgmtSystem.Entity;

namespace WarehouseMgmtSystem.UserControls
{
    public partial class UcInventoryManagement : UserControl
    {
        ArticleHandler articleHandler = new ArticleHandler();
        BindingList<Article> articleBindingList;
        public UcInventoryManagement()
        {
            InitializeComponent();
            InitGridView(articleHandler.GetAllArticles());
        }

        private void InitGridView(List<Article> articles)
        {
            articleBindingList = new BindingList<Article>(articles);
            dataGridView1.DataSource = articleBindingList;
            dataGridView1.AutoGenerateColumns = true;
            //Endast kvantitet och lagersaldo möjligt att ändra i grid
            dataGridView1.Columns[0].ReadOnly = dataGridView1.Columns[1].ReadOnly = dataGridView1.Columns[4].ReadOnly = true;
        }

        //Sparar alla ändringar från gridden till fil
        private void btnSave_Click(object sender, EventArgs e) => articleHandler.UpdateArticles(articleBindingList.ToList());

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxSearch.Text, out var sku))
                dataGridView1.DataSource = articleBindingList.Where(c => c.SKU == sku).ToList();
            else
                dataGridView1.DataSource = articleBindingList.Where(c => c.Name == txtBoxSearch.Text).ToList(); 
        }

        //När en cell uppdateras och man ställer sig i en annan cell -> skapar ny artikel som uppdaterar vald vald artikel i listan
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];

            var updatedArticle = new Article(
                row.Cells["Name"].Value.ToString(),
                Convert.ToInt32(row.Cells["SKU"].Value),
                Convert.ToInt32(row.Cells["Quantity"].Value),
                Convert.ToInt32(row.Cells["StoragePlace"].Value),
                row.Cells["Supplier"].Value.ToString()
            );
            UpdateArticleInBindingList(updatedArticle, e.RowIndex);
        }

        private void UpdateArticleInBindingList(Article updatedArticle, int rowIndex)
        {
            int index = articleBindingList.IndexOf(articleBindingList[rowIndex]);

            if (index != -1)
                articleBindingList[index] = updatedArticle;
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e) => btnSearch.Enabled = txtBoxSearch.Text.Length > 2;

        private void txtBoxSearch_Enter(object sender, EventArgs e) => txtBoxSearch.Clear();

        private void txtBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch.PerformClick();
        }
    }
}
