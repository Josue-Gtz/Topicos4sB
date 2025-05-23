using LoginFlow.Model;
using LoginFlow.Datos;
namespace LoginFlow.Views;


public partial class LoginPage : ContentPage
{
    private string ResultadoError;

    public LoginPage()
    {
        InitializeComponent();

    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }
    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        var username = Username.Text?.Trim();
        var password = Password.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Debe ingresar usuario y contraseña", "OK");
            return;
        }

        if (await IsCredentialCorrect(username, password))
        {
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            Preferences.Remove("UsuarioActualId");
            Preferences.Remove("UsuarioActualNombre");
            await DisplayAlert("Login fallido", "Usuario o contraseña incorrectos", "OK");
        }
    }
    private readonly UsuarioDatabase _usrdb = new UsuarioDatabase();
    private async Task<bool> IsCredentialCorrect(string usuario, string contrasena)
    {
        var user = await _usrdb.ValidarUsuarioAsync(usuario, contrasena);
        if (user != null)
        {
            Preferences.Set("UsuarioActualId", user.Id);
            Preferences.Set("UsuarioActualNombre", user.NombreUsuario);
            return true;
        }
        return false;
    }

    private async void TapGestureRecognizerPwd_Tapped(object sender, TappedEventArgs e)
    {
        var username = (await DisplayPromptAsync("Recuperar contraseña", "Ingresa tu nombre de usuario:"))?.Trim();
        if (string.IsNullOrEmpty(username))
            return;

        var user = await _usrdb.ObtenerUsuarioPorNombreAsync(username);
        if (user != null)
        {
            await DisplayAlert("Recuperación", $"Tu contraseña es: {user.Contrasena}", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Usuario no encontrado", "OK");
        }
    }
    private async void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {



        var nuevoUsuario = (await DisplayPromptAsync("Registro", "Ingresa un nombre de usuario:"))?.Trim();
        if (string.IsNullOrEmpty(nuevoUsuario))
            return;

        var correo = (await DisplayPromptAsync("Registro", "Ingresa tu correo:"))?.Trim();
        if (string.IsNullOrEmpty(correo))
            return;

        var password = await DisplayPromptAsync(
            title: "Registro",
            message: "Ingresa una contraseña:",
            accept: "Registrar",
            cancel: "Cancelar",
            placeholder: "",
            maxLength: -1,
            keyboard: Keyboard.Text
        );
        if (string.IsNullOrEmpty(password))
            return;

        if (await _usrdb.UsuarioExisteAsync(nuevoUsuario))
        {
            await DisplayAlert("Error", "El usuario ya está registrado", "OK");
        }
        else
        {
            var user = new Usuario
            {
                NombreUsuario = nuevoUsuario,
                CorreoElectronico = correo,
                Contrasena = password,
                Activo = true
            };
            await _usrdb.GuardarUsuarioAsync(user);
            await DisplayAlert("Registro exitoso", $"Usuario '{nuevoUsuario}' registrado correctamente.", "OK");
        }
    }
}
