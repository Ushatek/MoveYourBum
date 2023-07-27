using MoveYourBum.ViewModels;
using Xamarin.Forms;

namespace MoveYourBum.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
        }
    }
}