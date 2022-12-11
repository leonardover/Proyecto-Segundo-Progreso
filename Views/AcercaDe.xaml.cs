namespace Proyecto_2P.Views;

public partial class AcercaDe : ContentPage
{
    public AcercaDe()
    {
        InitializeComponent();
    }

    private async void MasInfo_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Cl_Acercade about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}