using MauiCrud.Views;

namespace MauiCrud
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Defining routes
            Routing.RegisterRoute("Articles", typeof(ArticlesPage));
            Routing.RegisterRoute("AddArticle", typeof(AddArticlePage));
            Routing.RegisterRoute("EditArticle", typeof(EditArticlePage));
            Routing.RegisterRoute("ViewArticle", typeof(ViewArticlePage));
        }
    }
}
