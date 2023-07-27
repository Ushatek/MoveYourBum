using MoveYourBum.ViewModels.ScheduleExerciseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleExerciseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleExerciseEditPage : ContentPage
    {
        public ScheduleExerciseEditPage()
        {
            InitializeComponent();
            BindingContext = new ScheduleExerciseEditViewModel();
        }
    }
}