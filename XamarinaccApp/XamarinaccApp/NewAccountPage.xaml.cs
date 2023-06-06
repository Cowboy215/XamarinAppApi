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
    public partial class NewAccountPage : ContentPage
    {

        public Account account { get; set; }
        private const string Url = "https://xamarinappapi.azurewebsites.net/api/accounts";

        public string UserName { get; set; }
        public string Password { get; set; }    

        public NewAccountPage()
        {
            InitializeComponent();
            BindingContext= this;
        }

        private async void ToolbarSaveItem_Clicked(object sender, EventArgs e)
        {
            account = new Account
            {
                UserName = this.UserName,
                Password = this.Password
            };

            var serializeItem = JsonConvert.SerializeObject(account);
            StringContent body = new StringContent(serializeItem, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PostAsync(Url,body);
            string data = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode) 
            {
                var answer = await DisplayAlert("Guardando", "Tu quieres continuar", "Si", "No");
                if (answer) 
                {
                    
                }
                else 
                {
                
                }
            }
        }


    }
}