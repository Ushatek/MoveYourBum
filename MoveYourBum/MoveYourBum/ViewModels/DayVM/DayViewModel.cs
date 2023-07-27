using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.Views.DayV;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using System.Linq;

namespace MoveYourBum.ViewModels.DayVM
{
    public class DayViewModel : AListViewModel<DayForView>
    {
        public DayViewModel()
            : base("Zaplanuj trening dla dnia")
        {
        }
        //napisanie ladowania dni do listy - w celu sortowania po dacie malejaco - najnowszy dzien u gory
        public async override Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                var sortedItems = items.OrderByDescending(d => d.Date).ToList();
                Items.Clear();
                foreach (var item in sortedItems)
                {
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

        public async override void OnItemSelected(DayForView item)
        {
            if (item == null)
                return;
            //await Shell.Current.DisplayAlert("Wybrano dzień", $"{item.Date}", "Zamknij");
            await Shell.Current.GoToAsync($"{nameof(DayDetailsPage)}?{nameof(DayDetailsViewModel.ItemId)}={item.Id}");
        }

        public async override void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewDayPage));
        }

        public override void GoToEditPage(DayForView item)
        {
            Shell.Current.GoToAsync($"{nameof(DayEditPage)}?{nameof(DayEditViewModel.ItemId)}={item.Id}");
        }
    }
}