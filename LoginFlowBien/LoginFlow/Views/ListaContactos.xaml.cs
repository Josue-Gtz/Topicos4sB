using System.Collections.ObjectModel;
using LoginFlow.Datos;
using LoginFlow.Model;
using LoginFlow.ViewModel;
namespace LoginFlow.Views;

public partial class ListaContactos : ContentPage
{
    private ContactoDatabase db = new ContactoDatabase();

    public ListaContactos()
	{
		InitializeComponent();
        BindingContext = this;


    }
    public ObservableCollection<Contacto> Contactos => ContactoMostrador.Contactos;

   /* private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto contacto)
        {
            await Navigation.PushAsync(new DetallesContacto(contacto));
        }
    }
   */
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        contactosView.ItemsSource = await db.ObtenerContactosAsync();
    }

    

    private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto seleccionado)
        {
            await Navigation.PushAsync(new CrearContacto(seleccionado));
        }
        
    }

    private async void OnEliminarContacto(object sender, EventArgs e)
    {
        if (((SwipeItem)sender).BindingContext is Contacto contacto)
        {
            bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {contacto.Nombre}?", "Sí", "No");
            if (confirm)
            {

                await db.EliminarContactoAsync(contacto);
                contactosView.ItemsSource = await db.ObtenerContactosAsync();
            }
        }
    }

    
}