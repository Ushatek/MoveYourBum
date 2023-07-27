using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.Views.ExercisePhotoV;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ExercisePhotoVM
{
    public class ExercisePhotoViewModel : AListViewModel<ExercisePhotoForView>
    {
        public ExercisePhotoViewModel()
            : base("Lista zdjęć")
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
                    if (item.IdExercise == ItemId)//jesli rodzaj cwiczenia jest taki sam jak kliknietego to pokazemy na liscie
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

        public async override void OnItemSelected(ExercisePhotoForView item)
        {
            if (item == null)
                return;
            await Shell.Current.DisplayAlert("Link do zdjęcia", $"{item.FileUrl}", "Zamknij");
        }
        public async override void GoToAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(NewExercisePhotoPage)}?{nameof(NewExercisePhotoViewModel.IdExercise)}={ItemId}");
        }

        public async override void GoToEditPage(ExercisePhotoForView item)
        {
            await Shell.Current.GoToAsync($"{nameof(ExercisePhotoEditPage)}?{nameof(ExercisePhotoEditViewModel.ItemId)}={item.Id}");

        }
    }
}
