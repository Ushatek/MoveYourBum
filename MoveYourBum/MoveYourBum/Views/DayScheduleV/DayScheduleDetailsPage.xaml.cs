using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.ViewModels.DaySchedule;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.DayScheduleV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayScheduleDetailsPage : ContentPage
    {
        public DayScheduleDetailsPage()
        {
            InitializeComponent();
            BindingContext  = new DayScheduleDetailsViewModel();
        }

    }
}