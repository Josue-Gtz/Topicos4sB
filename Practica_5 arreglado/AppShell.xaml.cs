using Practica_5_arreglado.View;

namespace Practica_5_arreglado
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("home", typeof(Pantalla_principal));

        }
    }
}
