using System.Collections.ObjectModel;

namespace Practica_5;

public partial class Pantalla_de_Lista_de_Contactos : ContentPage
{
    public Pantalla_de_Lista_de_Contactos()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public ObservableCollection<Contacto> Contactos => ContactoService.Contactos;

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto contactoSeleccionado)
        {
            await Navigation.PushAsync(new Pantalla_Detalle_del_Contacto(contactoSeleccionado));
            ((CollectionView)sender).SelectedItem = null; // Desseleccionar
        }
    }


}