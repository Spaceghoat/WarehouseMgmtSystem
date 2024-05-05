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
using WarehouseMgmtSystem.UserControls;

namespace WarehouseMgmtSystem
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
            OnInitialStartup();
        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e) => e.ItemHeight = 40;

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left + 5, e.Bounds.Top + 5);
                e.DrawFocusRectangle();
            }
        }

        //Lägger till korrekt user control till panelen beroende på vilken knapp i listan till vänster man trycker på
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                panel1.Controls.Clear();
                if (listBox1.SelectedIndex == 0)
                    panel1.Controls.Add(new UcGoodsRecieval());
                else if (listBox1.SelectedIndex == 1)
                    panel1.Controls.Add(new UcInventoryManagement());
                else if (listBox1.SelectedIndex == 2)
                    panel1.Controls.Add(new UcOrderManagement());                   
            }
        }

        //Om inte filen finns i "mina dokument" skapas den upp. Dvs första gången man startar applikationen på sin dator/om man raderat filen
        private void OnInitialStartup()
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ArticlesWMS.txt");
            if (!File.Exists(filePath))
                CreateAndPopulateFile(filePath);
        }

        //Lägger till ett antal artiklar till filen vid första uppstart
        private void CreateAndPopulateFile(string filePath)
        {
            try
            {
                List<Article> articles = new List<Article>
                {
                    new Article("Net soffbord vit", 1001, 10, 101, "Brafab"),
                    new Article("Clip bord 70x70", 1002, 25, 102, "Brafab"),
                    new Article("Playstation 5", 1003, 15, 303, "Sony"),
                    new Article("Arcanite Reaper", 1004, 20, 704, "Smith Argus")
                };

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var article in articles)
                        writer.WriteLine($"{article.Name},{article.SKU},{article.Quantity},{article.StoragePlace},{article.Supplier}");
                }

                Console.WriteLine("Artikelfilen skapad");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fel uppstod vid uppskapande av artikelfil: " + ex.Message);
            }
        }
    }
}
