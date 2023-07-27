using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.Views.ScheduleExerciseV;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ScheduleExerciseVM
{
    public class ScheduleExerciseViewModel : AListViewModel<ScheduleExerciseForView>
    {
        public ScheduleExerciseViewModel()
            : base("Lista ćwiczeń treningu")
        {
        }

        public async override Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    if (item.IdSchedule == ItemId)//jesli należy do danego treningu
                        Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async override void OnItemSelected(ScheduleExerciseForView item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Wybrano ćwiczenie", $"{item.ExerciseName}", "Zamknij");
            //await Shell.Current.GoToAsync($"{nameof(ExerciseDetailsPage)}?{nameof(ExerciseDetailsViewModel.ItemId)}={item.Id}");
        }

        public async override void GoToAddPage()
        {
            //await Shell.Current.GoToAsync(nameof(NewScheduleExercisePage));
            await Shell.Current.GoToAsync($"{nameof(NewScheduleExercisePage)}?{nameof(NewScheduleExerciseViewModel.IdSchedule)}={ItemId}");
        }

        public override void GoToEditPage(ScheduleExerciseForView item)
        {
            Shell.Current.GoToAsync($"{nameof(ScheduleExerciseEditPage)}?{nameof(ScheduleExerciseEditViewModel.ItemId)}={item.Id}");
        }
    }
}
