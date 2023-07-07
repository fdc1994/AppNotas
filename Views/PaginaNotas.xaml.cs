namespace Notas.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class PaginaNotas : ContentPage
{
    public PaginaNotas()
    {
        InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notas.txt";
        CarregaNota(randomFileName);
    }

    public string ItemId
    {
        set { CarregaNota(value); }
    }

    private void CarregaNota(string fileName)
    {
        Models.Nota notaModel = new Models.Nota();
        notaModel.Filename = fileName;
        if (File.Exists(fileName))
        {
            notaModel.Date = File.GetCreationTime(fileName);
            notaModel.Text = File.ReadAllText(fileName);
 }
        BindingContext = notaModel;
    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Nota nota)
            File.WriteAllText(nota.Filename, TextEditor.Text);
        await Shell.Current.GoToAsync("..");
    }
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Nota nota)
        {
            // Apaga o ficheiro
            if (File.Exists(nota.Filename))
                File.Delete(nota.Filename);
        }
        await Shell.Current.GoToAsync("..");
    }
}

