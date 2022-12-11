namespace Proyecto_2P;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.Comentario), typeof(Views.Comentario));
    }
}
