using LoginFlow.Model;
using LoginFlow.ViewModel;
namespace LoginFlow.Views;

public partial class CrearContacto : ContentPage
{
    public CrearContacto()
    {
        InitializeComponent();
    }
    private async void GuardarContacto(object sender, EventArgs e)
    {
        var contacto = new Contacto
        {
            Nombre = nombreEntry.Text,
            Telefono = telefonoEntry.Text,
            Correo = correoEntry.Text,
            Direccion = direccionEntry.Text
        };
        ContactoMostrador.Contactos.Add(contacto);
        nombreEntry.Text = telefonoEntry.Text = correoEntry.Text = direccionEntry.Text = "";
        await DisplayAlert("Guardado", $"Contacto {contacto.Nombre} guardado.", "OK");
        await Navigation.PopAsync();
    }
}