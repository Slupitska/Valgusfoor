using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Valgusfoor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Valgusfoor : ContentPage
    {
        private bool ButtonEnterClicked = false;
        private bool ButtonExitClicked = false;

        public Valgusfoor()
        {
            InitializeComponent();

            BackgroundColor = Color.LightPink;

            redFrame.BackgroundColor = Color.LightGray;
            yellowFrame.BackgroundColor = Color.LightGray;
            greenFrame.BackgroundColor = Color.LightGray;

            redFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonEnterClicked)
                    {
                        DisplayAlert("Error", "Switch on valgusfoor", "Ok");
                        return;
                    }
                    redFrame.BackgroundColor = Color.Red;
                    redLabel.Text = "Stop";
                    redLabel.FontSize = 15;
                    redLabel.TextColor = Color.Black;
                })
            });

            yellowFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonEnterClicked)
                    {
                        DisplayAlert("Error", "Switch on valgusfoor", "Ok");
                        return;
                    }
                    yellowFrame.BackgroundColor = Color.Yellow;
                    yellowLabel.Text = "Wait";
                    yellowLabel.FontSize = 15;
                    yellowLabel.TextColor = Color.Black;
                })
            });

            greenFrame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    if (!ButtonEnterClicked)
                    {
                        DisplayAlert("Error", "Switch on valgusfoor", "Ok");
                        return;
                    }
                    greenFrame.BackgroundColor = Color.Green;
                    greenLabel.Text = "Go";
                    greenLabel.FontSize = 15;
                    greenLabel.TextColor = Color.Black;
                })
            });

            ButtonEnter.Clicked += OnButtonEnterClicked;

            ButtonExit.Clicked += OnButtonExitClicked;

            ButtonBack.Clicked += OnButtonBackClicked;
        }

        private async void OnButtonBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnButtonEnterClicked(object sender, EventArgs e)
        {
            ButtonEnterClicked = true;

            redFrame.BackgroundColor = Color.Red;
            yellowFrame.BackgroundColor = Color.Yellow;
            greenFrame.BackgroundColor = Color.Green;
        }

        private void OnButtonExitClicked(object sender, EventArgs e)
        {
            ButtonExitClicked = true;

            Device.BeginInvokeOnMainThread(async () =>
            {
                bool answer = await DisplayAlert("Valgusfoor switch off", "Do you want switch off?", "Yes", "No");

                if (answer == true)
                {
                    ButtonEnterClicked = false;

                    ButtonEnter.BackgroundColor = Color.LightGray;

                    redFrame.BackgroundColor = Color.LightGray;
                    yellowFrame.BackgroundColor = Color.LightGray;
                    greenFrame.BackgroundColor = Color.LightGray;

                    redLabel.Text = "red";
                    redLabel.FontSize = 15;
                    yellowLabel.Text = "yellow";
                    yellowLabel.FontSize = 15;
                    greenLabel.Text = "green";
                    greenLabel.FontSize = 15;

                    lbl3.Text = "Switch on valgusfoor";
                }
                else
                {
                    ButtonExitClicked = false;
                    ButtonEnterClicked = true;

                }
            });
        }
    }
}