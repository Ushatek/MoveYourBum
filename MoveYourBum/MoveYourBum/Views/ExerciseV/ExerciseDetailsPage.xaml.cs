using MoveYourBum.ViewModels.ExerciseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ExerciseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailsPage : ContentPage
    {
        public ExerciseDetailsPage()
        {
            InitializeComponent();
            BindingContext = new ExerciseDetailsViewModel();
        }
    }
}