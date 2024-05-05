using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseMgmtSystem.Controllers;
using WarehouseMgmtSystem.Entity;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace WarehouseMgmtSystem.UserControls
{
    public partial class UcOrderManagement : UserControl
    {
        OrderHandler orderHandler = new OrderHandler();
        BindingList<OrderRow> orderRows = new BindingList<OrderRow>();
        int noOfOrdersCreated = 1;
        public UcOrderManagement()
        {
            InitializeComponent();
        }

        //Genererar en order vid tryck på knappen och lägger till i gridden
        private void btnGenerateOrder_Click(object sender, EventArgs e)
        {
            var order = orderHandler.GenerateOrder(noOfOrdersCreated);
            for (int i = 1; i < order.Articles.Count + 1; i++)
            {
                var article = order.Articles[i-1];
                orderRows.Add(new OrderRow(order.OrderNumber, i, article.Name, article.SKU, article.Quantity, article.StoragePlace));
            }
            
            noOfOrdersCreated++;
            dataGridView1.DataSource = orderRows;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GeneratePDF();
            var selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as OrderRow;
            var orderRowsToBook = GetAllOrderRows().Where(c => c.OrderNumber == selectedRow.OrderNumber).ToList();
            //Bokar ut artiklar, dvs ändrar kvantiteten i lagersaldot
            orderHandler.BookOrderArticles(orderRowsToBook);
        }
        
        private void GeneratePDF()
        {
            var doc = new PdfDocument();
            var page = doc.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            var font = new XFont("Times New Roman", 12, XFontStyle.Regular);
            int y = 40;

            var orderRows = GetAllOrderRows();                     
            var selectedRow = dataGridView1.SelectedRows[0].DataBoundItem as OrderRow;

            var properties = typeof(OrderRow).GetProperties();
            //Sätter headers i PDF med hjälp av klass-attributen
            for (int i = 0; i < properties.Length; i++)
            {
                string columnHeader = properties[i].Name;
                graphics.DrawString(columnHeader, font, XBrushes.Black, 40 + (i * 80), y);
            }
            //Ökar y-led dvs lodrätt för att "hoppa ner en rad"
            y += 20;
            //Skapar upp orderrader i PDF
            foreach (var row in orderRows.Where(c => c.OrderNumber == selectedRow.OrderNumber))
            {
                graphics.DrawString(row.OrderNumber.ToString(), font, XBrushes.Black, 40, y);
                graphics.DrawString(row.RowNumber.ToString(), font, XBrushes.Black, 40 + 80, y);
                graphics.DrawString(row.ArticleName, font, XBrushes.Black, 40 + 160, y);
                graphics.DrawString(row.SKU.ToString(), font, XBrushes.Black, 40 + 240, y);
                graphics.DrawString(row.Quantity.ToString(), font, XBrushes.Black, 40 + 320, y);
                graphics.DrawString(row.StoragePlace.ToString(), font, XBrushes.Black, 40 + 400, y);
                
                y += 20;               
            }
            doc.Save("Order.pdf");
            Process.Start("Order.pdf");
        }

        //Hämtar alla rader från gridden och konverterar dem till OrderRow så dem går att arbeta med
        private List<OrderRow> GetAllOrderRows()
        {
            var orderRows = new List<OrderRow>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (row.DataBoundItem != null && row.DataBoundItem is OrderRow orderRow)
                    orderRows.Add(orderRow);

            return orderRows;
        }

        //Printknappen endast enabled om en rad (eller flera, men ej möjligt) är vald
        private void dataGridView1_SelectionChanged(object sender, EventArgs e) => btnPrint.Enabled = dataGridView1.SelectedRows.Count > 0;
    }
}
