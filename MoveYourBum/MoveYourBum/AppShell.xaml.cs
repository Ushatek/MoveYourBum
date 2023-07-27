using MoveYourBum.Views.DayScheduleV;
using MoveYourBum.Views.DayV;
using MoveYourBum.Views.ExercisePhotoV;
using MoveYourBum.Views.ExerciseTypeV;
using MoveYourBum.Views.ExerciseV;
using MoveYourBum.Views.ScheduleExerciseSetV;
using MoveYourBum.Views.ScheduleExerciseV;
using MoveYourBum.Views.ScheduleV;
using System;
using Xamarin.Forms;

namespace MoveYourBum
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewExerciseTypePage), typeof(NewExerciseTypePage));
            Routing.RegisterRoute(nameof(ExerciseTypeEditPage), typeof(ExerciseTypeEditPage));

            Routing.RegisterRoute(nameof(ExercisePage), typeof(ExercisePage));
            Routing.RegisterRoute(nameof(NewExercisePage), typeof(NewExercisePage));
            Routing.RegisterRoute(nameof(ExerciseEditPage), typeof(ExerciseEditPage));
            Routing.RegisterRoute(nameof(ExerciseDetailsPage), typeof(ExerciseDetailsPage));

            Routing.RegisterRoute(nameof(ExercisePhotoPage), typeof(ExercisePhotoPage));
            Routing.RegisterRoute(nameof(NewExercisePhotoPage), typeof(NewExercisePhotoPage));
            Routing.RegisterRoute(nameof(ExercisePhotoEditPage), typeof(ExercisePhotoEditPage));

            Routing.RegisterRoute(nameof(NewSchedulePage), typeof(NewSchedulePage));
            Routing.RegisterRoute(nameof(ScheduleEditPage), typeof(ScheduleEditPage));
            Routing.RegisterRoute(nameof(ScheduleDetailsPage), typeof(ScheduleDetailsPage));

            Routing.RegisterRoute(nameof(ScheduleExercisePage), typeof(ScheduleExercisePage));
            Routing.RegisterRoute(nameof(NewScheduleExercisePage), typeof(NewScheduleExercisePage));
            Routing.RegisterRoute(nameof(ScheduleExerciseEditPage), typeof(ScheduleExerciseEditPage));
            Routing.RegisterRoute(nameof(ScheduleExerciseDetailsPage), typeof(ScheduleExerciseDetailsPage));

            Routing.RegisterRoute(nameof(NewDayPage), typeof(NewDayPage));
            Routing.RegisterRoute(nameof(DayEditPage), typeof(DayEditPage));
            Routing.RegisterRoute(nameof(DayDetailsPage), typeof(DayDetailsPage));

            Routing.RegisterRoute(nameof(NewDaySchedulePage), typeof(NewDaySchedulePage));
            Routing.RegisterRoute(nameof(DaySchedulePage), typeof(DaySchedulePage));
            Routing.RegisterRoute(nameof(DayScheduleEditPage), typeof(DayScheduleEditPage));
            Routing.RegisterRoute(nameof(DayScheduleDetailsPage), typeof(DayScheduleDetailsPage));

            Routing.RegisterRoute(nameof(ScheduleExerciseSetPage), typeof(ScheduleExerciseSetPage));
            Routing.RegisterRoute(nameof(NewScheduleExerciseSetPage), typeof(NewScheduleExerciseSetPage));
            Routing.RegisterRoute(nameof(ScheduleExerciseSetEditPage), typeof(ScheduleExerciseSetEditPage));


            //dodawac kazdy inny page tak samo jak wyzej (o ile nie bylo takiego route w appshell.xaml!!!!!
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
