using MoveYourBum.ViewModels.ScheduleVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleEditPage : ContentPage
    {
        public ScheduleEditPage()
        {
            InitializeComponent();
            BindingContext = new ScheduleEditViewModel();
        }
    }
}