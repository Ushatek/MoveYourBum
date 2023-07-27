using MoveYourBum.ViewModels.ScheduleVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage
    {
        private ScheduleViewModel _viewModel;
        public SchedulePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ScheduleViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}