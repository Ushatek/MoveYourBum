using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using MoveYourBum.ViewModels.ExercisePhotoVM;
using MoveYourBum.Views.ExercisePhotoV;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ExerciseVM
{
    [QueryProperty(nameof(IdExercise), nameof(IdExercise))]
    public class ExerciseDetailsViewModel : AItemDetailsViewModel<ExerciseForView>
    {
        #region Fields
        private string name;
        private string description;
        private string properTechniqueDescription;
        private string muscleInvolvedDescription;
        private List<ExercisePhotoForView> exercisePhotos;
        private int idExercise;
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
        public string ProperTechniqueDescription
        {
            get => properTechniqueDescription;
            set => SetProperty(ref properTechniqueDescription, value);
        }
        public string MuscleInvolvedDescription
        {
            get => muscleInvolvedDescription;
            set => SetProperty(ref muscleInvolvedDescription, value);
        }
        public ObservableCollection<ExercisePhotoForView> Items
        {
            get;
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command ManagePhotosCommand { get; }
        public int IdExercise
        {
            get => idExercise;
            set => SetProperty(ref idExercise, value);
        }
        #endregion Properties

        public ExerciseDetailsViewModel()
        : base()
        {
            Items = new ObservableCollection<ExercisePhotoForView>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddItemCommand = new Command(NewExercisePhotoForView);
            ManagePhotosCommand = new Command(ExercisePhotoForView);

        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = exercisePhotos;
                foreach (var item in items)
                {
                    if(item.IdExercise == ItemId && item.IsActive == true)
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

        public async void ExercisePhotoForView()
        {
            await Shell.Current.GoToAsync($"{nameof(ExercisePhotoPage)}?{nameof(ExercisePhotoViewModel.ItemId)}={ItemId}");
        }
        public async void NewExercisePhotoForView()
        {
            await Shell.Current.GoToAsync($"{nameof(NewExercisePhotoPage)}?{nameof(NewExercisePhotoViewModel.IdExercise)}={ItemId}");
        }

        public override async void LoadProperties(ExerciseForView item)
        {
            Name = item.Name;
            Description = item.Description;
            ProperTechniqueDescription = item.ProperTechniqueDescription;
            MuscleInvolvedDescription = item.MuscleInvolvedDescription;
            exercisePhotos = item?.Photos?.ToList() ?? new List<ExercisePhotoForView>();
            await ExecuteLoadItemsCommand();
        }

    }
}
