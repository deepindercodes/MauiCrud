using MauiCrud.Models;

namespace MauiCrud.Views;

[QueryProperty(nameof(id), "Id")]
public partial class EditArticlePage : ContentPage
{
    private Article objarticle;

    public EditArticlePage()
	{
		InitializeComponent();
	}

    public string id
    {
        set
        {
            ArticleRepository objrepo = new ArticleRepository();

            objarticle = objrepo.GetArticles().FirstOrDefault(u => u.id == Convert.ToString(value));


            ctrlEditArticle.ArticleTitle = objarticle.articletitle;
            ctrlEditArticle.ArticleAuthor = objarticle.articleauthor;
            ctrlEditArticle.ArticleBody = objarticle.articlebody;
            

            //Showcasing image if present
            if (objarticle.articleimage != null)
            {
                ctrlEditArticle.ArticleImage = objarticle.articleimage;
            }
        }
    }

    private void ctrlEditArticle_onSave(object sender, EventArgs e) 
    { 
        ArticleRepository objrepo = new ArticleRepository();

        objarticle.articletitle = ctrlEditArticle.ArticleTitle;
        objarticle.articleauthor = ctrlEditArticle.ArticleAuthor;
        objarticle.articlebody = ctrlEditArticle.ArticleBody;

        objrepo.EditArticle(objarticle);

        Shell.Current.GoToAsync($"//Articles");
    }

    private void ctrlEditArticle_onCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//Articles");
    }

    private void ctrlEditArticle_onError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}