namespace Notas;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Views.PaginaNotas), typeof(Views.PaginaNotas));
    }
}
