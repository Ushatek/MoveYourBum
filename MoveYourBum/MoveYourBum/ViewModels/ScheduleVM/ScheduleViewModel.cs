using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.Views.ScheduleV;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ScheduleVM
{
    public class ScheduleViewModel : AListViewModel<ScheduleForView>
    {
        public ScheduleViewModel()
            : base("Lista treningów")
        {
        }

        public async override void OnItemSelected(ScheduleForView item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ScheduleDetailsPage)}?{nameof(ScheduleDetailsViewModel.ItemId)}={item.Id}");

        }

        public async override void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewSchedulePage));
        }

        public override void GoToEditPage(ScheduleForView item)
        {
            Shell.Current.GoToAsync($"{nameof(ScheduleEditPage)}?{nameof(ScheduleEditViewModel.ItemId)}={item.Id}");
        }
    }
}