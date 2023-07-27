using MoveYourBum.Service.Reference;
using MoveYourBum.Services;
using MoveYourBum.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.DaySchedule
{
    [QueryProperty(nameof(IdDay), nameof(IdDay))]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NewDayScheduleViewModel : ANewViewModel<DayScheduleForView>
    {
        #region Fields
        private DateTime dayDate;
        private string scheduleName;
        private int idDay;
        private int itemId;
        private ScheduleForView selectedSchedule;
        private List<ScheduleForView> schedules;
        #endregion Fields
        #region Properties
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command ManagePhotosCommand { get; }
        public DateTime DayDate
        {
            get => dayDate;
            set => SetProperty(ref dayDate, value);
        }
        public string ScheduleName
        {
            get => scheduleName;
            set => SetProperty(ref scheduleName, value);
        }
        public ScheduleForView SelectedSchedule
        {
            get => selectedSchedule;
            set => SetProperty(ref selectedSchedule, value);
        }
        public List<ScheduleForView> Schedules
        {
            get
            {
                return schedules;
            }
        }
        public int IdDay
        {
            get => idDay;
            set => SetProperty(ref idDay, value);
        }
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }
        #endregion Properties
        public NewDayScheduleViewModel()
            : base()
        {
            selectedSchedule = new ScheduleForView();
            var scheduleDataStore = new ScheduleDataStore();
            scheduleDataStore.RefreshListFromService();
            schedules = scheduleDataStore.items;
        }

        public override DayScheduleForView SetItem()
        {
            return new DayScheduleForView
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                IdDay = ItemId,
                IdSchedule = SelectedSchedule.Id,
                ScheduleName = SelectedSchedule.Name,
            };
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(SelectedSchedule?.Name);
        }
    }
}
