using System;
using Microsoft.Maui.Controls;

namespace glasluisaTS3B.Views
{
    public partial class LoginPage : ContentPage
    {
        // Datos de usuario y contraseña
        private string[] users = { "BustilosDannes", "CovenaCarlos", "LasluisaGinna", "NoronaLucia", "MolinaDavid" };
        private string[] passwords = { "Dannes123", "Carlos123", "Ginna123", "Lucia123", "David123" };

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

            // Validación de credenciales
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == username && passwords[i] == password)
                {
                    // Credenciales correctas
                    await DisplayAlert("Bienvenido", $"Bienvenido, {username}!", "OK");
                    // Navegar a la página principal
                    await Navigation.PushAsync(new vHome());
                    return;
                }
            }

            // Si no se encontraron credenciales válidas
            lblError.Text = "Usuario o contraseña incorrectos.";
            lblError.IsVisible = true;
        }
    }
}
