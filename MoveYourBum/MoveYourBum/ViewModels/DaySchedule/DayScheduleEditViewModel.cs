using MoveYourBum.Service.Reference;
using MoveYourBum.Services;
using MoveYourBum.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.DaySchedule
{
    public class DayScheduleEditViewModel : AEditViewModel<DayScheduleForView>
    {
        #region Fields
        private DateTime dayDate;
        private string scheduleName;
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
        
        #endregion Properties
        public DayScheduleEditViewModel()
            : base()
        {
            selectedSchedule = new ScheduleForView();
            var scheduleDataStore = new ScheduleDataStore();
            scheduleDataStore.RefreshListFromService();
            schedules = scheduleDataStore.items;
        }

        public override void LoadProperties(DayScheduleForView item)
        {
            SelectedSchedule = schedules.FirstOrDefault(sch => sch.Id == item.IdSchedule);
            ScheduleName = item.ScheduleName;
        }

        public override DayScheduleForView SetItem(DayScheduleForView item)
        {
            item.ModifiedDate = DateTime.Now;
            item.IdSchedule = selectedSchedule.Id;
            return item;
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(SelectedSchedule?.Name);
        }
    }
}
