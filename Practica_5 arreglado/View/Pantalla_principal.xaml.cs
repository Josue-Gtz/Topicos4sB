namespace Practica_5_arreglado.View;

public partial class Pantalla_principal : ContentPage
{
	public Pantalla_principal()
	{
		InitializeComponent();
	}
    private async void IrListaContactos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pantalla_listacontactos());
    }

    private async void IrCrearContacto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pantalla_crearcontacto());
    }
    private async void IrConfiguracion(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pantalla_configuracion());
    }
}