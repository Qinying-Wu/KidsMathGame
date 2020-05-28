using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlashCardMath.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardMath.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GamePageVM ViewModel { get; set; }
        public GamePage()
        {
            InitializeComponent();
            ViewModel = new GamePageVM();
            BindingContext = ViewModel;
        }
    }
}