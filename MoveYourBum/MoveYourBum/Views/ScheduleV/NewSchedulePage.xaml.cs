using MoveYourBum.ViewModels.ScheduleVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewSchedulePage : ContentPage
    {
        public NewSchedulePage()
        {
            InitializeComponent();
            BindingContext = new NewScheduleViewModel();
        }
    }
}