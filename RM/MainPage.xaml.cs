using Newtonsoft.Json;
using Plugin.SimpleAudioPlayer;
using RM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RM
{
    public partial class MainPage : ContentPage
    {
        public string response;
        ObservableCollection<Results> charachters;
        ActivityIndicator activityIndicator = new ActivityIndicator { Color = Color.FromHex("#24e12e") };
        ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
        public MainPage()
        {
            InitializeComponent();
            SetMusic();
            GetAll();
        }

        public async void GetAll()
        {
            loader.IsVisible = true;
            var httpClient = new HttpClient();
            response = await httpClient.GetStringAsync("https://rickandmortyapi.com/api/character");
            Character result = JsonConvert.DeserializeObject<Character>(response);

            charachters = new ObservableCollection<Results>(result.results);

            LV.ItemsSource = charachters;
            loader.IsVisible = false;
        }
        public void SetMusic() 
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("RM.Resources.rmSong.mp3");

            player.Load(audioStream);
            player.Play();
            player.Loop=true;
        }
        private async void LV_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ab = e.Item as Results;

            await Navigation.PushAsync(new DetailsPage(e.Item as Results));
        }
        private async void FilterButton_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Chose Filter", "Cancel", null, "Status", "Gender", "Clear");
            if (!String.IsNullOrEmpty(action))
            {
                if (action == "Status")
                {
                    string status = await DisplayActionSheet("Chose Status", "Cancel", null, "Alive", "Dead", "unknown");

                    if (!String.IsNullOrEmpty(status))
                    {
                        var a = charachters.Where(x => x.status == status).ToList();
                        LV.ItemsSource = a;
                    }

                }

                else if (action == "Gender")
                {
                    string gender = await DisplayActionSheet("Chose Gender", "Cancel", null, "Female", "Male", "unknown");
                    if (!String.IsNullOrEmpty(gender))
                    {
                        var a = charachters.Where(x => x.gender == gender).ToList();
                        LV.ItemsSource = a;
                    }
                }
                else if (action == "Clear")
                {
                    LV.ItemsSource = charachters;
                }
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var value = ((TappedEventArgs)e).Parameter;
            await Navigation.PushAsync(new DetailsPage(value as Results));
        }
        private void MusicButton_Clicked(object sender, EventArgs e)
        {
            if(player.IsPlaying)
            {
                player.Stop();
            }
            else { player.Play(); }
        }
    }
}
