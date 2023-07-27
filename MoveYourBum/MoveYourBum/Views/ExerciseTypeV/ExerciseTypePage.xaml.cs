using MoveYourBum.ViewModels.ExerciseTypeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ExerciseTypeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseTypePage : ContentPage
    {
        private ExerciseTypeViewModel _viewModel;
        public ExerciseTypePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ExerciseTypeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
}