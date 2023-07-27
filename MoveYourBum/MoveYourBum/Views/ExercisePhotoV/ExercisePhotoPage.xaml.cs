using MoveYourBum.ViewModels.ExercisePhotoVM;
using MoveYourBum.ViewModels.ExerciseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ExercisePhotoV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePhotoPage : ContentPage
    {
        private ExercisePhotoViewModel _viewModel;
        public ExercisePhotoPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ExercisePhotoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}