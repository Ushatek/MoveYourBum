using MoveYourBum.Service.Reference;
using MoveYourBum.Services;
using MoveYourBum.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ScheduleExerciseVM
{
    [QueryProperty(nameof(IdSchedule), nameof(IdSchedule))]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NewScheduleExerciseViewModel : ANewViewModel<ScheduleExerciseForView>
    {
        public NewScheduleExerciseViewModel()
            : base()
        {
            selectedExercise = new ExerciseForView();
            var exerciseDataStore = new ExerciseDataStore();
            exerciseDataStore.RefreshListFromService();
            exercises = exerciseDataStore.items;
        }

        #region Fields
        private int itemId;
        private string annotation;
        private int idSchedule;
        private ExerciseForView selectedExercise;
        private List<ExerciseForView> exercises;
        #endregion

        #region Properties
        public string Annotation
        {
            get => annotation;
            set => SetProperty(ref annotation, value);
        }
        public int IdSchedule
        {
            get => idSchedule;
            set => SetProperty(ref idSchedule, value);
        }
        public ExerciseForView SelectedExercise
        {
            get => selectedExercise;
            set => SetProperty(ref selectedExercise, value);
        }
        public List<ExerciseForView> Exercises
        {
            get
            {
                return exercises;
            }
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
        #endregion
        public override ScheduleExerciseForView SetItem()
        {
            return new ScheduleExerciseForView
            {
                Id = 0,
                Annotation = annotation,
                IdSchedule = IdSchedule,
                IdExercise = SelectedExercise.Id,
                ExerciseName = SelectedExercise.Name,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
            };
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(SelectedExercise?.Name);
        }
    }
}
