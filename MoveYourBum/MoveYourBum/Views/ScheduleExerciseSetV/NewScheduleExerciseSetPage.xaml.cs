using MoveYourBum.ViewModels.ScheduleExerciseSetVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleExerciseSetV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewScheduleExerciseSetPage : ContentPage
    {
        public NewScheduleExerciseSetPage()
        {
            InitializeComponent();
            BindingContext = new NewScheduleExerciseSetViewModel();
        }
    }
}