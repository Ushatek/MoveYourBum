using MoveYourBum.ViewModels.DaySchedule;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.DayScheduleV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DaySchedulePage : ContentPage
    {
        private DayScheduleViewModel _viewModel;
        public DaySchedulePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DayScheduleViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}