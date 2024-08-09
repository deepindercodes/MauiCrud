using MauiCrud.Models;

namespace MauiCrud.Views;

public partial class AddArticlePage : ContentPage
{
	public AddArticlePage()
	{
		InitializeComponent();
	}

    private void ctrlAddArticle_onSave(object sender, EventArgs e)
    {
        ArticleRepository objrepo = new ArticleRepository();

        objrepo.AddArticle(new Models.Article {
            articletitle = ctrlAddArticle.ArticleTitle,
            articleauthor = ctrlAddArticle.ArticleAuthor,
            articlebody = ctrlAddArticle.ArticleBody,
            articleimage = ctrlAddArticle.ArticleImage,
        });


        Shell.Current.GoToAsync($"//Articles");
    }

    private void ctrlAddArticle_onCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//Articles");
    }

    private void ctrlAddArticle_onError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}