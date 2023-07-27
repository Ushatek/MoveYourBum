using MoveYourBum.ViewModels.DayVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.DayV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDayPage : ContentPage
    {
        public NewDayPage()
        {
            InitializeComponent();
            BindingContext = new NewDayViewModel();
        }
    }
}