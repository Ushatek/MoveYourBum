using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.ExerciseTypeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ExerciseTypeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExerciseTypePage : ContentPage
    {
        public ExerciseTypeForView Item { get; set; }
        public NewExerciseTypePage()
        {
            InitializeComponent();
            BindingContext = new NewExerciseTypeViewModel();
        }
    }
}