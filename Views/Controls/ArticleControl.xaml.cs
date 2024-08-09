using static System.Net.Mime.MediaTypeNames;

namespace MauiCrud.Views.Controls;

public partial class ArticleControl : ContentView
{
    //Creating an event Handler for hamdling events
    public event EventHandler<string> onError;
    public event EventHandler<EventArgs> onSave;
    public event EventHandler<EventArgs> onCancel;

    public ArticleControl()
	{
		InitializeComponent();
	}

    public string ArticleTitle
    {
        get { return entryArticleTitle.Text; } 
        set { entryArticleTitle.Text = value; }
    }

    public string ArticleAuthor
    {
        get { return entryArticleAuthor.Text; }
        set { entryArticleAuthor.Text = value; }
    }

    public string ArticleBody
    {
        get { return entryArticleBody.Text; }
        set { entryArticleBody.Text = value; }
    }

    public string ArticleImage
    {
        get { return lblArticleImageBase64Data.Text; }
        set 
        { 
            

            if (value != null)
            {
                lblArticleImageBase64Data.Text = value;

                var imageBytes = Convert.FromBase64String(value);
                MemoryStream imageDecodeStream = new(imageBytes);
                imgArticleImage.Source = ImageSource.FromStream(() => imageDecodeStream);
            }
        }
    }

    private async void btnUploadArticleImage_Clicked(object sender, EventArgs e)
    {
        //PickAndShow(PickOptions.Default);

        var images = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Images",
            FileTypes = FilePickerFileType.Images
        });
        var imageSource = images.FullPath.ToString();
        imgArticleImage.Source = imageSource;
        lblArticleImageText.Text = imageSource;

        //getting base64data
        try
        {
            var stream = images.OpenReadAsync().Result;
            using var mstream = new MemoryStream();
            stream.CopyTo(mstream);
            var convertImage = Convert.ToBase64String(mstream.ToArray());
            lblArticleImageBase64Data.Text = convertImage;
        }
        catch (Exception ex) {
            
        }
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (validateArticleTitle.IsNotValid)
        {
            onError?.Invoke(sender, "Article title is required");
            return;
        }

        if (validateArticleAuthor.IsNotValid)
        {
            onError?.Invoke(sender, "Article Author is required");
            return;
        }

        if (validateArticleBody.IsNotValid)
        {
            onError?.Invoke(sender, "Article Body is required");
            return;
        }

        onSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        onCancel?.Invoke(sender, e);
    }
}