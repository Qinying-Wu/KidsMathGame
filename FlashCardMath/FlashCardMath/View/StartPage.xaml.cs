using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FlashCardMath.ViewModel;
using FlashCardMath.View;
using Xamarin.Essentials;

namespace FlashCardMath
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class StartPage : ContentPage
    {
        public StartPageVM ViewModel { get; set; }
        public StartPage()
        {
            InitializeComponent();
            ViewModel = new StartPageVM();
            this.BindingContext = ViewModel;

        }

        private void Game_Button_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new NavigationPage(new GamePage()));
        }
    }
}
