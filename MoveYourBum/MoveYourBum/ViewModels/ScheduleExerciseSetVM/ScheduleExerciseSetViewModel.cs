using MoveYourBum.Service.Reference;
using MoveYourBum.Services;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.Views.ScheduleExerciseSetV;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ScheduleExerciseSetVM
{
    [QueryProperty(nameof(IdScheduleExercise), nameof(IdScheduleExercise))]
    public class ScheduleExerciseSetViewModel : AListViewModel<ScheduleExerciseSetForView>
    {
        public ScheduleExerciseSetViewModel() 
            : base("Lista powtórzeń treningu")
        {
        }
        private int idScheduleExercise;
        private int liftedTotal;

        public int IdScheduleExercise
        {
            get => idScheduleExercise;
            set => SetProperty(ref idScheduleExercise, value);
        }
        public int LiftedTotal
        {
            get => liftedTotal;
            set => SetProperty(ref liftedTotal, value);
        }
        private LiftedValueDataStore liftedValueDataStore => new LiftedValueDataStore();
        public void LoadLiftedValue()
        {
            LiftedTotal = liftedValueDataStore.LiftedValueOfExercise(IdScheduleExercise, ItemId);
        }

        //napisanie metody ladujacej item do listy - filtrujemy co dodac
        public async override Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    if (item.IdScheduleExercise == IdScheduleExercise && item.IdDaySchedule == ItemId)//jesli rodzaj cwiczenia jest taki sam jak kliknietego to pokazemy na liscie
                        Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                LoadLiftedValue();
                IsBusy = false;
            }
        }
        public async override void GoToAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(NewScheduleExerciseSetPage)}?{nameof(NewScheduleExerciseSetViewModel.IdScheduleExercise)}={IdScheduleExercise}&{nameof(NewScheduleExerciseSetViewModel.ItemId)}={ItemId}");
        }

        public override void GoToEditPage(ScheduleExerciseSetForView item)
        {
            Shell.Current.GoToAsync($"{nameof(ScheduleExerciseSetEditPage)}?{nameof(ScheduleExerciseSetEditViewModel.ItemId)}={item.Id}");
        }
    }
}