
using System.Globalization;
using LoginFlow.Utils;
namespace LoginFlow.Views;


public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        temaSwitch.IsToggled = CofiguracionApp.ObtenerTema();


    }

    private async void LogoutButton_Clicked(object sender, EventArgs e)
	{
		if (await DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No"))
		{
            Preferences.Remove("UsuarioActual");
            SecureStorage.RemoveAll();
			await Shell.Current.GoToAsync("///login");
		}
	}
    private void OnTemaToggled(object sender, ToggledEventArgs e)
    {
        CofiguracionApp.GuardarTema(e.Value);

        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;

        lblEstado.IsVisible = true;
    }
    private void ActualizarTextos()
    {
        return;

        //this.Title = Traductor.Get("Configuracion");
        //lblEstado.Text = Traductor.Get("CamposRequeridos"); // ejemplo de recarga
        // Aquí podrías actualizar otros elementos visibles de la página si se desea
    }
}