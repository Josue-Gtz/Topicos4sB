namespace LoginFlow.Views;
using LoginFlow.Model;


public partial class DetallesContacto : ContentPage
{
	public DetallesContacto(Contacto contacto)
	{
		InitializeComponent();
        BindingContext = contacto;


    }
    private async void SalirDetalles(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaContactos());
    }



}