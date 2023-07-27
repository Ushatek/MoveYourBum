using MoveYourBum.ViewModels.ExercisePhotoVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ExercisePhotoV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExercisePhotoPage : ContentPage
    {
        public NewExercisePhotoPage()
        {
            InitializeComponent();
            BindingContext = new NewExercisePhotoViewModel();
        }
    }
}