using MoveYourBum.Views.DayV;
using MoveYourBum.Views.ExerciseTypeV;
using MoveYourBum.Views.ScheduleV;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command DayCommand { get; }
        public Command ScheduleCommand { get; }
        public Command ExerciseTypeCommand { get; }
        public AboutViewModel()
        {
            Title = "Strona główna";
            DayCommand = new Command(OnDayItem);
            ScheduleCommand = new Command(OnScheduleItem);
            ExerciseTypeCommand = new Command(OnExerciseTypeItem);
        }

        public async void OnDayItem(object obj)
        {
            await Shell.Current.Navigation.PushAsync(new DayPage());
        }

        public async void OnScheduleItem(object obj)
        {
            await Shell.Current.Navigation.PushAsync(new SchedulePage());
        }

        public async void OnExerciseTypeItem(object obj)
        {
            await Shell.Current.Navigation.PushAsync(new ExerciseTypePage());
        }

    }
}