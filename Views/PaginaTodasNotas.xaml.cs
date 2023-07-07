namespace Notas.Views;
public partial class PaginaTodasNotas : ContentPage
{
    public PaginaTodasNotas()
    {
        InitializeComponent();
        BindingContext = new Models.TodasNotas();
    }
    protected override void OnAppearing()
    {
        ((Models.TodasNotas)BindingContext).CarregaNotas();
    }
    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PaginaNotas));
    }
    private async void notesCollection_SelectionChanged(object sender,
SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Obtem o model da nota
            var note = (Models.Nota)e.CurrentSelection[0];
            // Deve navegar para "PaginaNotas?ItemId=path\on\device\XYZ.notas.txt"
            await Shell.Current.GoToAsync($"{nameof(PaginaNotas)}?{nameof(PaginaNotas.ItemId)}={ note.Filename}");
            // Deseleciona a UI
            notesCollection.SelectedItem = null;
        }
    }
}