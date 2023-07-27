using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.ViewModels.ScheduleExerciseVM;
using MoveYourBum.Views.ScheduleExerciseV;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ScheduleVM
{
    [QueryProperty(nameof(IdSchedule), nameof(IdSchedule))]
    public class ScheduleDetailsViewModel : AItemDetailsViewModel<ScheduleForView>
    {
        #region Fields
        private string name;
        private string description;
        private List<ScheduleExerciseForView> scheduleExercises;
        private int idSchedule;
        #endregion Fields
        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public ObservableCollection<ScheduleExerciseForView> Items
        {
            get;
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command ManageExercisesCommand { get; }
        public int IdSchedule
        {
            get => idSchedule;
            set => SetProperty(ref idSchedule, value);
        }
        #endregion Properties

        public ScheduleDetailsViewModel()
        : base()
        {
            Items = new ObservableCollection<ScheduleExerciseForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(NewScheduleExerciseForView);
            ManageExercisesCommand = new Command(ScheduleExerciseForView);

        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = scheduleExercises;
                foreach (var item in items)
                {
                    if (item.IdSchedule == ItemId && item.IsActive == true)
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

        public async void ScheduleExerciseForView()
        {
            await Shell.Current.GoToAsync($"{nameof(ScheduleExercisePage)}?{nameof(ScheduleExerciseViewModel.ItemId)}={ItemId}");
        }
        public async void NewScheduleExerciseForView()
        {
            await Shell.Current.GoToAsync($"{nameof(NewScheduleExercisePage)}?{nameof(NewScheduleExerciseViewModel.IdSchedule)}={ItemId}");
        }

        public override async void LoadProperties(ScheduleForView item)
        {
            Name = item.Name;
            Description = item.Description;
            scheduleExercises = item?.ScheduleExercises?.ToList() ?? new List<ScheduleExerciseForView>();
            await ExecuteLoadItemsCommand();
        }
    }
}
