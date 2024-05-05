using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseMgmtSystem.Entity;

namespace WarehouseMgmtSystem
{
    public class ArticleHandler
    {
        readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ArticlesWMS.txt");

        //Lägger till artikel till fil. Alternativt adderas kvaniteten om inskrivet artikelnamn finns på vald lagerplats
        public void AddArticle(Article newArticle)
        {
            var existingRow = ArticleExistsGetRow(newArticle);

            if (!string.IsNullOrEmpty(existingRow))
                UpdateArticle(existingRow, newArticle);
            else
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{newArticle.Name}, {newArticle.SKU}, {newArticle.Quantity}, {newArticle.StoragePlace}, {newArticle.Supplier}");
                }

            MessageBox.Show("Artikel tillagd till fil");
        }

        //Om artikeln redan finns på vald lagerplats så returneras den raden
        public string ArticleExistsGetRow(Article newArticle)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string row;
                while ((row = reader.ReadLine()) != null)
                {
                    string[] parts = row.Split(',');

                    if (parts[0].Trim() == newArticle.Name && parts[3].Trim() == newArticle.StoragePlace.ToString())
                        return row;
                }
            }
            return string.Empty;
        }

        public void UpdateArticle(string row, Article articleToUpdate)
        {
            var lines = File.ReadAllLines(filePath).ToList();
            var rowIndex = lines.IndexOf(row);
            string[] parts = row.Split(',');

            lines[rowIndex] = $"{articleToUpdate.Name},{articleToUpdate.SKU},{articleToUpdate.Quantity + int.Parse(parts[2])},{articleToUpdate.StoragePlace},{articleToUpdate.Supplier}";
            File.WriteAllLines(filePath, lines);
        }
        
        public List<Article> GetAllArticles()
        {
            var articles = new List<Article>();
            var lines = File.ReadAllLines(filePath).ToList();
            foreach (var row in lines)
            {
                string[] parts = row.Split(',');
                articles.Add(new Article(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), parts[4]));
            }
            return articles;
        }

        public void UpdateArticles(List<Article> articlesForUpdate)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var article in articlesForUpdate)
                    writer.WriteLine($"{article.Name}, {article.SKU}, {article.Quantity}, {article.StoragePlace}, {article.Supplier}");
            }
        }

        //Hämtar artiklar och lägger till x antal på en order vid ordergenerering
        public List<Article> GenerateArticlesFromFile()
        {
            var articles = GetAllArticles();
            var rnd = new Random();
            var numberOfArticles = rnd.Next(1, 4);

            var randomArticles = articles.OrderBy(a => Guid.NewGuid()).Take(numberOfArticles).ToList();
            var result = new List<Article>();

            foreach (var article in randomArticles)
            {
                var rndQty = rnd.Next(1, 4);
                result.Add(new Article(article.Name, article.SKU, rndQty, article.StoragePlace, article.Supplier));
            }
            return result;
        }

        //Bokar ut x antal artiklar i filen utifrån de antal som skrivits ut till plocklista
        public void CheckOutArticles(List<OrderRow> orderRowsToBook)
        {
            var lines = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');

                if (orderRowsToBook.Any(c => c.SKU.ToString() == parts[1].Trim() && c.StoragePlace.ToString() == parts[3].Trim()))
                {
                    var orderRow = orderRowsToBook.First(c => c.SKU.ToString() == parts[1].Trim() && c.StoragePlace.ToString() == parts[3].Trim());
                    parts[2] = (int.Parse(parts[2]) - orderRow.Quantity).ToString();
                    lines[i] = string.Join(",", parts);
                }
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
