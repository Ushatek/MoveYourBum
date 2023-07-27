using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.ViewModels.ScheduleVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleDetailsPage : ContentPage
    {
        public ScheduleDetailsPage()
        {
            InitializeComponent();
            BindingContext = new ScheduleDetailsViewModel();
        }

        
    }
}