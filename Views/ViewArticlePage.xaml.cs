using MauiCrud.Models;

namespace MauiCrud.Views;

[QueryProperty(nameof(id), "Id")]
public partial class ViewArticlePage : ContentPage
{
	private Article objarticle;
	public ViewArticlePage()
	{
		InitializeComponent();
	}


	public string id
	{
		set
		{
            ArticleRepository objrepo = new ArticleRepository();

			objarticle = objrepo.GetArticles().FirstOrDefault(u => u.id == Convert.ToString(value));


			lblArticleTitle.Text = $"Title: {objarticle.articletitle}";
			lblArticleAuthor.Text = $"Author: {objarticle.articleauthor}";
            lblArticleBody.Text = $"Body: {objarticle.articlebody}";
            lblArticleTimeStamp.Text = $"Created on (UTC): {objarticle.createdonutc}";
            if (objarticle.modifiedonutc != null)
			{
				lblArticleTimeStamp.Text = $"Modified on (UTC): {objarticle.modifiedonutc}";
			}

			//Showcasing image if present
			if (objarticle.articleimage != null)
			{
				frameimage.IsVisible = true;

                var imageBytes = Convert.FromBase64String(objarticle.articleimage);
                MemoryStream imageDecodeStream = new(imageBytes);
                imgArticleImage.Source = ImageSource.FromStream(() => imageDecodeStream);
            }
        }
	}
}