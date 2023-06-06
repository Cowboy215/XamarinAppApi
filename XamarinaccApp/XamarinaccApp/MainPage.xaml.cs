using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinaccApp.Models;

namespace XamarinaccApp
{
    public partial class MainPage : ContentPage
    {

        private readonly HttpClient _client = new HttpClient();
        private const string Url = "https://xamarinappapi.azurewebsites.net/api/accounts";
        private ObservableCollection<Account> account;
        public MainPage()
        {
            InitializeComponent();
        }

        async override protected void OnAppearing() 
        {
            string responsecontent = await _client.GetStringAsync(Url);
            List<Account> mylist = JsonConvert.DeserializeObject<List<Account>>(responsecontent);
            account = new ObservableCollection<Account>(mylist);
            ItemlistView.ItemsSource = account;
            base.OnAppearing();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewAccountPage()));
        }

        private async void ItemlistView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myselecteditem = e.Item as Account;
            await Navigation.PushAsync(new AccountDetailsPage(myselecteditem.Id, myselecteditem.Password, myselecteditem.UserName));
            ((ListView)sender).SelectedItem = null;
        }
    }
}
