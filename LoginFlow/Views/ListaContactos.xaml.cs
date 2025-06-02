using System.Collections.ObjectModel;
using LoginFlow.Model;
using LoginFlow.ViewModel;
namespace LoginFlow.Views;

public partial class ListaContactos : ContentPage
{
    
    public ListaContactos()
	{
		InitializeComponent();
        BindingContext = this;


    }
    public ObservableCollection<Contacto> Contactos => ContactoMostrador.Contactos;

    private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto contacto)
        {
            await Navigation.PushAsync(new DetallesContacto(contacto));
        }
    }
}