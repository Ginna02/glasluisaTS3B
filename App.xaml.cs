using Microsoft.Maui.Controls;
using glasluisaTS3B.Views;

namespace glasluisaTS3B
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Establecer la página de inicio como LoginPage
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
