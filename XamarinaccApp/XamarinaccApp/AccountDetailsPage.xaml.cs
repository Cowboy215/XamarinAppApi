using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinaccApp.Models;

namespace XamarinaccApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountDetailsPage : ContentPage
    {
        public Account myaccount { get; set; }
        private const string Url = "https://xamarinappapi.azurewebsites.net/api/accounts";
        public AccountDetailsPage(int myeditid, string myeditpassword, string myeditusername)
        {
            InitializeComponent();

            MyUserName.Text = myeditusername;
            MyPassword.Text = myeditpassword;
            Application.Current.Properties["id"] = myeditid;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var id = Application.Current.Properties["id"];
            int i = int.Parse(id.ToString());
            myaccount = new Account
            {
                Id = i,
                UserName= MyUserName.Text,
                Password= MyPassword.Text

            };

            var serializeItem = JsonConvert.SerializeObject(myaccount);
            StringContent body = new StringContent(serializeItem, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PutAsync($"{Url}/{i}", body);
            string data = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                var answer = await DisplayAlert("Actualizando", "Tu quieres continuar", "Si", "No");
                if (answer)
                {

                }
                else
                {

                }
            }

        }

        private async void Button_BorrarClicked(object sender, EventArgs e)
        {
            var id = Application.Current.Properties["id"];
            int i = int.Parse(id.ToString());
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync($"{Url}/{i}");

            if(response.IsSuccessStatusCode) 
            {
                var answer = await DisplayAlert("Eliminando", "Seguro que lo quieres borrar??", "Si", "No");
                if(answer) 
                {
                    
                }
                else 
                {
                    
                }
            }
        }
    }
}