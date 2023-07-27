using MoveYourBum.ViewModels.ScheduleExerciseSetVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleExerciseSetV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleExerciseSetEditPage : ContentPage
    {
        public ScheduleExerciseSetEditPage()
        {
            InitializeComponent();
            BindingContext = new ScheduleExerciseSetEditViewModel();
        }
    }
}