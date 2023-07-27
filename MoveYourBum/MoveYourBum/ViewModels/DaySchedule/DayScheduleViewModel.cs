using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.Views.DayScheduleV;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.DaySchedule
{
    public class DayScheduleViewModel : AListViewModel<DayScheduleForView>
    {
        public DayScheduleViewModel()
            : base("Treningi dnia")
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
                    if (item.IdDay == ItemId && item.IsActive == true)
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

        public async override void GoToAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(NewDaySchedulePage)}?{nameof(NewDayScheduleViewModel.ItemId)}={ItemId}");
        }

        public async override void GoToEditPage(DayScheduleForView item)
        {
            await Shell.Current.GoToAsync($"{nameof(DayScheduleEditPage)}?{nameof(DayScheduleEditViewModel.ItemId)}={item.Id}");
        }

        public async override void OnItemSelected(DayScheduleForView item)
        {
            if (item == null)
                return;
            //await Shell.Current.DisplayAlert("Wybrano trening", $"{item.ScheduleName}", "Zamknij");
            await Shell.Current.GoToAsync($"{nameof(DayScheduleDetailsPage)}?{nameof(DayScheduleDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}
