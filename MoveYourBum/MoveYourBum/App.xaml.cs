using MoveYourBum.Service.Reference;
using MoveYourBum.Services;
using Xamarin.Forms;

namespace MoveYourBum
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<DayDataStore>();
            DependencyService.Register<DayScheduleDataStore>();
            DependencyService.Register<ExerciseDataStore>();
            DependencyService.Register<ExercisePhotoDataStore>();
            DependencyService.Register<ExerciseTypeDataStore>();
            DependencyService.Register<ScheduleDataStore>();
            DependencyService.Register<ScheduleExerciseDataStore>();
            DependencyService.Register<ScheduleExerciseSetDataStore>();
            DependencyService.Register<LiftedValueDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
