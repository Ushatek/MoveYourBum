using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.ViewModels.ExerciseVM;
using MoveYourBum.Views.ExerciseTypeV;
using MoveYourBum.Views.ExerciseV;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ExerciseTypeVM
{
    public class ExerciseTypeViewModel : AListViewModel<ExerciseTypeForView>
    {
        public ExerciseTypeViewModel()
            : base("Lista kategorii ćwiczeń")
        {
        }

        public async override void OnItemSelected(ExerciseTypeForView exerciseType)
        {
            if (exerciseType == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ExercisePage)}?{nameof(ExerciseViewModel.ItemId)}={exerciseType.Id}");
        }

        public async override void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewExerciseTypePage));
        }

        public override void GoToEditPage(ExerciseTypeForView item)
        {
            Shell.Current.GoToAsync($"{nameof(ExerciseTypeEditPage)}?{nameof(ExerciseTypeEditViewModel.ItemId)}={item.Id}");
        }
    }
}