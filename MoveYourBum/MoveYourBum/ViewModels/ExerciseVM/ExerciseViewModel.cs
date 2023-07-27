using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using MoveYourBum.Views.ExerciseV;

namespace MoveYourBum.ViewModels.ExerciseVM
{
    public class ExerciseViewModel : AListViewModel<ExerciseForView>
    {
        public ExerciseViewModel()
            : base("Lista ćwiczeń")
        {
        }
        //napisanie metody ladujacej item do listy - w tym przyadku filtrujemy co dodac
        public async override Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    if(item.IdExerciseType == ItemId)//jesli rodzaj cwiczenia jest taki sam jak kliknietego to pokazemy na liscie
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

        public async override void OnItemSelected(ExerciseForView item)
        {
            if (item == null)
                return;
            //await Shell.Current.DisplayAlert("Wybrano ćwiczenie", $"{item.Name}", "Zamknij");
            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailsPage)}?{nameof(ExerciseDetailsViewModel.ItemId)}={item.Id}");
        }

        public async override void GoToAddPage()
        {
            //await Shell.Current.GoToAsync(nameof(NewExercisePage));
            await Shell.Current.GoToAsync($"{nameof(NewExercisePage)}?{nameof(NewExerciseViewModel.IdExerciseType)}={ItemId}");
        }

        public override void GoToEditPage(ExerciseForView item)
        {
            Shell.Current.GoToAsync($"{nameof(ExerciseEditPage)}?{nameof(ExerciseEditViewModel.ItemId)}={item.Id}");
        }
    }
}
