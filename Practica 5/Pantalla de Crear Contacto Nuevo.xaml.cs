using System.Collections.ObjectModel;

namespace Practica_5;
public static class ContactoService
{
    public static ObservableCollection<Contacto> Contactos { get; } = new ObservableCollection<Contacto>();
}
public partial class Pantalla_de_Crear_Contacto_Nuevo : ContentPage
{
	
    Entry nombreEntry, telefonoEntry, correoEntry, direccionEntry;

    public Pantalla_de_Crear_Contacto_Nuevo()
    {
        InitializeComponent();

        nombreEntry = (Entry)((FlexLayout)this.Content).Children[0];
        telefonoEntry = (Entry)((FlexLayout)this.Content).Children[1];
        correoEntry = (Entry)((FlexLayout)this.Content).Children[2];
        direccionEntry = (Entry)((FlexLayout)this.Content).Children[3];

        Button guardarButton = (Button)((FlexLayout)this.Content).Children[4];
        guardarButton.Clicked += GuardarButton_Clicked;
    }

    private async void GuardarButton_Clicked(object sender, EventArgs e)
    {
        var nuevoContacto = new Contacto
        {
            Nombre = nombreEntry.Text,
            Telefono = telefonoEntry.Text,
            Correo = correoEntry.Text,
            Direccion = direccionEntry.Text
        };

        ContactoService.Contactos.Add(nuevoContacto);

        // Opcional: limpiar campos
        nombreEntry.Text = telefonoEntry.Text = correoEntry.Text = direccionEntry.Text = "";

        // Navegar hacia atrás a la lista
        await Navigation.PopAsync();
    }
}