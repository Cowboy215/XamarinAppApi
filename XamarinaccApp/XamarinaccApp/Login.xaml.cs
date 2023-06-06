using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinaccApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String sUsuario = txtUsuario.Text;
            String sPassword = txtPassword.Text;

            if ((sUsuario == "root") && (sPassword == "toor")) 
            {
                Navigation.PushAsync(new MainPage());
            }
            else 
            {
                //lblResultado.Text = "El Usuario o Contraseña son incorrectos!!";
                DisplayAlert("Error", "El Usuario o Contraseña son incorrectos!!", "Ok");
            }
        }
    }
}