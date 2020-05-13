using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFirstXamarinApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetCats();
        }

        private async void GetCats()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://api.thecatapi.com/v1/images/search");
            var cats = JsonConvert.DeserializeObject<List<Cats>>(response);
            CatListView.ItemsSource = cats;
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            var viewModel = BindingContext;
            BindingContext = null;
            await Navigation.PushAsync(new MainPage());
            BindingContext = viewModel;
        }
    }
}
