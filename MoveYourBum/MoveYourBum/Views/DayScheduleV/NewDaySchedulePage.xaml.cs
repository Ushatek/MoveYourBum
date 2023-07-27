using MoveYourBum.ViewModels.DaySchedule;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.DayScheduleV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDaySchedulePage : ContentPage
    {
        public NewDaySchedulePage()
        {
            InitializeComponent();
            BindingContext = new NewDayScheduleViewModel();
        }
    }
}