using LogContactos.Views;

namespace LogContactos
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Menu), typeof(Menu));

            Routing.RegisterRoute(nameof(ListaContactos), typeof(ListaContactos));

            Routing.RegisterRoute(nameof(CrearContacto), typeof(CrearContacto));
        }

    }
}
