using Plugin.SimpleAudioPlayer;
using RM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;

        public DetailsPage()
        {
            InitializeComponent();
        }
        public DetailsPage(Results character) : this()
        {
            Image.Source = character.image;
            lblName.Text = character.name;
            lblCreated.Text = character.created;
            lblStatus.Text = character.status;
            lblSpecies.Text = character.species;
            lblGender.Text = character.gender;
            lblOrigin.Text = character.origin.name;
            lblLocation.Text = character.location.name;
        }
    }
}