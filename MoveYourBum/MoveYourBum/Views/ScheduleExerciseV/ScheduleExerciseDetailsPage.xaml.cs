using MoveYourBum.ViewModels.ScheduleExerciseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveYourBum.Views.ScheduleExerciseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleExerciseDetailsPage : ContentPage
    {
        public ScheduleExerciseDetailsPage()
        {
            InitializeComponent();
            BindingContext = new ScheduleExerciseDetailsViewModel();
        }
    }
}