namespace LoginFlow.Views;
using LoginFlow.Model;

public partial class LoginPage : ContentPage
{
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
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {
            Preferences.Set("UsuarioActual", Username.Text.Trim());
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///home");
        }
        else
        {
            Preferences.Remove("UsuarioActual");
            await DisplayAlert("Login failed", "Username or password if invalid", "Try again");
        }
    }

    
    bool IsCredentialCorrect(string username, string password)
    {
        return (username == "admin" && password == "1234") ||
                   (usuarios.ContainsKey(username) && usuarios[username] == password);
    }

    Dictionary<string, string> usuarios = new();
    private async void TapGestureRecognizerPwd_Tapped(object sender, TappedEventArgs e)
    {
        string usuario = await DisplayPromptAsync("Recuperar contraseña", "Ingresa tu usuario:");
        if (string.IsNullOrWhiteSpace(usuario)) return;

        if (usuarios.ContainsKey(usuario))
        {
            string pwd = usuarios[usuario];
            await DisplayAlert("Recuperado", $"Tu contraseña es: {pwd}", "Ok");
        }
        else
        {
            await DisplayAlert("Error", "Usuario no encontrado", "Ok");
        }
    }
    private async void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {
        string newUsuario = await DisplayPromptAsync("Registro", "Ingresa un nombre de usuario:");
        if (string.IsNullOrWhiteSpace(newUsuario)) return;

        string newPassword = await DisplayPromptAsync("Registro", "Ingresa una contraseña:", "Registrar", "Cancelar", "", -1, Keyboard.Text);
        if (string.IsNullOrWhiteSpace(newPassword)) return;

        if (usuarios.ContainsKey(newUsuario))
        {
            await DisplayAlert("Error", "El usuario ya está registrado", "OK");
        }
        else
        {
            usuarios[newUsuario] = newPassword;
            await DisplayAlert("Registro exitoso", $"Usuario {newUsuario} registrado", "OK");
        }
    }
}