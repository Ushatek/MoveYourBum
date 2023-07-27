using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.ViewModels.DaySchedule;
using MoveYourBum.Views.DayScheduleV;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.DayVM
{
    [QueryProperty(nameof(IdDay), nameof(IdDay))]
    public class DayDetailsViewModel : AItemDetailsViewModel<DayForView>
    {
        #region Fields
        private DateTime date;
        private string notes;
        private string scheduleName;
        private string scheduleDescription;
        private List<DayScheduleForView> daySchedules;
        private int idDay;
        #endregion Fields
        #region Properties
        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public string Notes
        {
            get => notes;
            set => SetProperty(ref notes, value);
        }
        public string ScheduleName
        {
            get => scheduleName;
            set => SetProperty(ref scheduleName, value);
        }
        public string ScheduleDescription
        {
            get => scheduleDescription;
            set => SetProperty(ref scheduleDescription, value);
        }
        public ObservableCollection<DayScheduleForView> Items
        {
            get;
        }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command ManageScheduleCommand { get; }
        public Command ItemSelectedCommand { get; }
        public int IdDay
        {
            get => idDay;
            set => SetProperty(ref idDay, value);
        }
        #endregion Properties
        public DayDetailsViewModel()
        : base()
        {
            Items = new ObservableCollection<DayScheduleForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(NewDayScheduleForView);
            ManageScheduleCommand = new Command(DayScheduleForView);

            ItemSelectedCommand = new Command<DayScheduleForView>(ItemSelected);
        }

        public async void ItemSelected(DayScheduleForView item)
        {
            if (item == null)
                return;
            //await Shell.Current.DisplayAlert("Wybrano ćwiczenie", $"{item.IdSchedule}", "Zamknij");
            await Shell.Current.GoToAsync($"{nameof(DayScheduleDetailsPage)}?{nameof(DayScheduleDetailsViewModel.ItemId)}={item.Id}");
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = daySchedules;
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

        public async void DayScheduleForView()
        {
            await Shell.Current.GoToAsync($"{nameof(DaySchedulePage)}?{nameof(DayScheduleViewModel.ItemId)}={ItemId}");
        }
        public async void NewDayScheduleForView()
        {
            await Shell.Current.GoToAsync($"{nameof(NewDaySchedulePage)}?{nameof(NewDayScheduleViewModel.ItemId)}={ItemId}");
        }

        public override async void LoadProperties(DayForView item)
        {
            Date = item.Date.Value.Date;
            Notes = item.Notes;
            ScheduleName = ScheduleName;
            ScheduleDescription = ScheduleDescription;
            Notes = item.Notes;
            daySchedules = item?.DaySchedules?.ToList() ?? new List<DayScheduleForView>();
            await ExecuteLoadItemsCommand();
        }
    }
}