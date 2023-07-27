using MoveYourBum.ViewModels.ScheduleExerciseSetVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleExerciseSetV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleExerciseSetPage : ContentPage
    {
        private ScheduleExerciseSetViewModel _viewModel;
        public ScheduleExerciseSetPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ScheduleExerciseSetViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}