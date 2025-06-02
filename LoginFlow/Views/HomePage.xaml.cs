namespace LoginFlow.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

        lblNombre.Text = Preferences.Get("UsuarioActual", "??");

    }
    private async void IrListaContactos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaContactos());
    }

    private async void IrCrearContacto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearContacto());
    }
    /*
      <Label
                                x:Name="lblNombre" 
                                Text=""
                                FontSize="16"
                                />

    */
}