using MoveYourBum.ViewModels.ExercisePhotoVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ExercisePhotoV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePhotoEditPage : ContentPage
    {
        public ExercisePhotoEditPage()
        {
            InitializeComponent();
            BindingContext = new ExercisePhotoEditViewModel();
        }
    }
}