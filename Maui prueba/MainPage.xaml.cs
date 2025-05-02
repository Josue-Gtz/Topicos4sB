namespace Maui_prueba
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        
        //Navigation.PushAsync(new Page(), true);

        private void Pagina2clk(object sender, EventArgs e)
        {
            Navigation.PushAsync(new pagina_cabrona(), true);
        }
    }

}
