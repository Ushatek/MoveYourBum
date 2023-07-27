using MoveYourBum.ViewModels.ScheduleExerciseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleExerciseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewScheduleExercisePage : ContentPage
    {
        public NewScheduleExercisePage()
        {
            InitializeComponent();
            BindingContext = new NewScheduleExerciseViewModel();
        }
    }
}