using MoveYourBum.Service.Reference;
using MoveYourBum.Services;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.ViewModels.ExerciseVM;
using MoveYourBum.ViewModels.ScheduleExerciseSetVM;
using MoveYourBum.ViewModels.ScheduleExerciseVM;
using MoveYourBum.Views.ExerciseV;
using MoveYourBum.Views.ScheduleExerciseSetV;
using MoveYourBum.Views.ScheduleExerciseV;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.DaySchedule
{
    [QueryProperty(nameof(IdSchedule), nameof(IdSchedule))]
    public class DayScheduleDetailsViewModel : AItemDetailsViewModel<DayScheduleForView>
    {
        #region Fields
        private string name;
        private string description;
        private List<ScheduleExerciseForView> scheduleExercises;
        private int idSchedule;

        private int liftedTotal;

        #endregion Fields

        public Command LoadItemsCommand { get; }
        public Command ManageExercisesCommand { get; }
        public Command ManageSetsCommand { get; }

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
        public List<ScheduleExerciseForView> ScheduleExercises
        {
            get => scheduleExercises;
            set => SetProperty(ref scheduleExercises, value);
        }
        public int IdSchedule
        {
            get => idSchedule;
            set => SetProperty(ref idSchedule, value);
        }
        public int LiftedTotal
        {
            get => liftedTotal;
            set => SetProperty(ref liftedTotal, value);
        }
        #endregion Properties


        public Command ItemTappedCommand { get; }
        public DayScheduleDetailsViewModel()
        : base()
        {
            Items = new ObservableCollection<ScheduleExerciseForView>();
            ScheduleExercises = new List<ScheduleExerciseForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ManageExercisesCommand = new Command(ScheduleExerciseForView);

            ManageSetsCommand = new Command<ScheduleExerciseForView>(ScheduleExerciseSetForView);

            ItemTappedCommand = new Command<ScheduleExerciseForView>(ItemTapped);
        }

        public new async void ItemTapped(ScheduleExerciseForView item)
        {
            //await Shell.Current.DisplayAlert("Wybrano ćwiczenie", $"{item.ExerciseName}", "Zamknij");
            await Shell.Current.GoToAsync($"{nameof(ExerciseDetailsPage)}?{nameof(ExerciseDetailsViewModel.ItemId)}={item.IdExercise}");
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
                    if (item.IdSchedule == IdSchedule && item.IsActive == true)
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
        private LiftedValueDataStore liftedValueDataStore => new LiftedValueDataStore();


        public override async void LoadProperties(DayScheduleForView item)
        {
            LiftedTotal = liftedValueDataStore.LiftedValueOfSchedule(item.Id);
            IdSchedule = item.IdSchedule;
            Name = item.ScheduleName;
            Description = item.ScheduleDescription;
            scheduleExercises = item.ScheduleExercises.ToList() ?? new List<ScheduleExerciseForView>();
            await ExecuteLoadItemsCommand();
        }

        public async void ScheduleExerciseSetForView(ScheduleExerciseForView item)
        {
            await Shell.Current.GoToAsync($"{nameof(ScheduleExerciseSetPage)}?{nameof(ScheduleExerciseSetViewModel.ItemId)}={ItemId}&{nameof(ScheduleExerciseSetViewModel.IdScheduleExercise)}={item.Id}");
        }
    }
}