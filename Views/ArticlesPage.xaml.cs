using MauiCrud.Models;
using System.Collections.ObjectModel;

namespace MauiCrud.Views;

public partial class ArticlesPage : ContentPage
{
    public ArticlesPage()
    {
        InitializeComponent();
    }

    void LoadData()
    {
        ArticleRepository objrepo = new ArticleRepository();

        var articles = new ObservableCollection<Article>(objrepo.GetArticles());

        listArticles.ItemsSource = articles;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadData();
    }

    private async void listArticles_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listArticles.SelectedItem != null)
        {
            //navigate to view articles
            await Shell.Current.GoToAsync($"ViewArticle?Id={((Article)listArticles.SelectedItem).id}");
        }
    }

    private void listArticles_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listArticles.SelectedItem = null;
    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"AddArticle");
    }

    private async void MenuItem_Clicked_Edit(object sender, EventArgs e)
    {
        var menuitem = sender as MenuItem;
        if (menuitem != null)
        {
            var objarticle = menuitem.CommandParameter as Article;

            if (objarticle != null)
            {
                await Shell.Current.GoToAsync($"EditArticle?Id={objarticle.id}");
            }
        }
    }

    private async void MenuItem_Clicked_Delete(object sender, EventArgs e)
    {
        var menuitem = sender as MenuItem;
        if (menuitem != null)
        {
            var objarticle = menuitem.CommandParameter as Article;

            if (objarticle != null)
            {
                ArticleRepository objrepo = new ArticleRepository();

                objrepo.DeleteArticle(objarticle.id);

                LoadData();
            }
        }
    }
}