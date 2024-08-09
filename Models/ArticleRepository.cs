using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiCrud.Models
{
    public class ArticleRepository
    {
        private string jsonFilePath = FileSystem.AppDataDirectory + "/data.json";
        public List<Article> GetArticles()
        {

            if (File.Exists(jsonFilePath))
            {
                Articles obj_jsonData = new Articles();

                string jsonData = File.ReadAllText(jsonFilePath);

                obj_jsonData = JsonSerializer.Deserialize<Articles>(jsonData);

                return obj_jsonData.articles.Where(u => u.status == "E").ToList();
            }
            else
            {
                return new List<Article>();
            }
        }

        public void AddArticle(Article article)
        {
            string articletitle = article.articletitle;
            string articleauthor = article.articleauthor;
            string articlebody = article.articlebody;
            string articleimage = article.articleimage;

            Articles obj_jsonData = new Articles();

            List<Article> objArticles = new List<Article>();


            Int32 pk = 1;

            if (File.Exists(jsonFilePath))
            {
                string jsonDataText = File.ReadAllText(jsonFilePath);

                obj_jsonData = JsonSerializer.Deserialize<Articles>(jsonDataText);

                pk = Convert.ToInt32(obj_jsonData.pk);

                pk = pk + 1;

                objArticles = obj_jsonData.articles;
            }

            Article objArticle = new Article();

            objArticle.id = pk.ToString();
            objArticle.articletitle = articletitle;
            objArticle.articleauthor = articleauthor;
            objArticle.articlebody = articlebody;
            objArticle.articleimage = articleimage;
            objArticle.createdonutc = DateTime.UtcNow.ToString();
            objArticle.status = "E";

            obj_jsonData.pk = pk.ToString();

            objArticles.Add(objArticle);
            obj_jsonData.articles = objArticles;

            string jsonData = JsonSerializer.Serialize(obj_jsonData);

            File.WriteAllText(jsonFilePath, jsonData);
        }

        public void EditArticle(Article article)
        {
            string articletitle = article.articletitle;
            string articleauthor = article.articleauthor;
            string articlebody = article.articlebody;
            string articleimage = article.articleimage;

            Articles obj_jsonData = new Articles();

            List<Article> objArticles = new List<Article>();

            string jsonData = File.ReadAllText(jsonFilePath);

            obj_jsonData = JsonSerializer.Deserialize<Articles>(jsonData);

            Article objArticle = obj_jsonData.articles.Where(u => u.id == article.id.ToString()).FirstOrDefault();

            objArticle.articletitle = articletitle;
            objArticle.articleauthor = articleauthor;
            objArticle.articlebody = articlebody;
            objArticle.articleimage = articleimage;
            objArticle.modifiedonutc = DateTime.UtcNow.ToString();

            jsonData = JsonSerializer.Serialize(obj_jsonData);

            File.WriteAllText(jsonFilePath, jsonData);

        }

        public void DeleteArticle(string id)
        {
            Articles obj_jsonData = new Articles();

            List<Article> objArticles = new List<Article>();

            string jsonData = File.ReadAllText(jsonFilePath);

            obj_jsonData = JsonSerializer.Deserialize<Articles>(jsonData);

            Article objArticle = obj_jsonData.articles.Where(u => u.id == id.ToString()).FirstOrDefault();

            obj_jsonData.articles.Remove(objArticle);

            jsonData = JsonSerializer.Serialize(obj_jsonData);

            File.WriteAllText(jsonFilePath, jsonData);
        }
    }
}
