using MoveYourBum.ViewModels.ScheduleExerciseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleExerciseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleExercisePage : ContentPage
    {
        private ScheduleExerciseViewModel _viewModel;
        public ScheduleExercisePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ScheduleExerciseViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}