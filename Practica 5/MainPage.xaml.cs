namespace Practica_5
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
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
            Navigation.PushAsync(new Pantalla_Configuración(), true);
        }


    }

}
