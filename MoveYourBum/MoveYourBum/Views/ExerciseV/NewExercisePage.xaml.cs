using MoveYourBum.ViewModels.ExerciseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ExerciseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExercisePage : ContentPage
    {
        public NewExercisePage()
        {
            InitializeComponent();
            BindingContext = new NewExerciseViewModel();
        }
    }
}