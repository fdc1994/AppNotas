namespace Notas.Views;

public partial class PaginaSobre : ContentPage
{
	public PaginaSobre()
	{
		InitializeComponent();
	}
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Sobre sobre)
        {
            // Navega para a URL no browser do sistema.
            await Launcher.Default.OpenAsync(sobre.MoreInfoUrl);
        }
    }

}