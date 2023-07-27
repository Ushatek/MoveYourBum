using MoveYourBum.ViewModels.DayVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.DayV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayEditPage : ContentPage
    {
        public DayEditPage()
        {
            InitializeComponent();
            BindingContext = new DayEditViewModel();
        }
    }
}