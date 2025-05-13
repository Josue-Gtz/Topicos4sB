using Practica_5.Model;

namespace Practica_5;

public partial class Pantalla_Detalle_del_Contacto : ContentPage
{
    public Pantalla_Detalle_del_Contacto(Contacto contacto)
    {
        InitializeComponent();
        BindingContext = contacto;
    }
}