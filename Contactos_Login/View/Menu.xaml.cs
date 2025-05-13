namespace Contactos_Login.View;
using Contactos_Login.View;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}
    private void IrListaContactos(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Pantalla_de_Lista_de_Contactos(), true);
    }
    private void IrCrearContacto(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Pantalla_de_Crear_Contacto_Nuevo(), true);
    }
    private void IrConfiguracion(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Pantalla_Configuraci�n(), true);
    }
}