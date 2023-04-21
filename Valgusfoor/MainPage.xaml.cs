using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Valgusfoor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Button Valgusfoor = new Button
            {
                Text = "Valgusfoor",
                BackgroundColor = Color.LightGreen,

            };
            StackLayout st = new StackLayout
            {
                Children = { Valgusfoor },
            };
            st.BackgroundColor = Color.Orange;
            Content = st;
            Valgusfoor.Clicked += Valgusfoor_Clicked;
        }

        private async void Valgusfoor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Valgusfoor());
        }
    }
}