using MoveYourBum.Service.Reference;
using MoveYourBum.Services;
using MoveYourBum.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveYourBum.ViewModels.ScheduleExerciseVM
{
    public class ScheduleExerciseEditViewModel : AEditViewModel<ScheduleExerciseForView>
    {
        public ScheduleExerciseEditViewModel()
        : base()
        {
            selectedExercise = new ExerciseForView();
            var exerciseDataStore = new ExerciseDataStore();
            exerciseDataStore.RefreshListFromService();
            exercises = exerciseDataStore.items;
        }

        #region Fields
        private string annotation;
        private string exerciseName;
        private ExerciseForView selectedExercise;
        private List<ExerciseForView> exercises;
        #endregion

        #region Properties

        public string Annotation
        {
            get => annotation;
            set => SetProperty(ref annotation, value);
        }

        public string ExerciseName
        {
            get => exerciseName;
            set => SetProperty(ref exerciseName, value);
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
        #endregion


        public override void LoadProperties(ScheduleExerciseForView item)
        {
            SelectedExercise = exercises.FirstOrDefault(ex => ex.Id == item.IdExercise);
            Annotation = item.Annotation;
            ExerciseName = item.ExerciseName;
        }

        public override ScheduleExerciseForView SetItem(ScheduleExerciseForView item)
        {
            item.Annotation = Annotation;
            item.IdExercise = selectedExercise.Id;
            item.ExerciseName = selectedExercise.Name;

            item.ModifiedDate = DateTime.Now;
            return item;
        }

        public override bool ValidateSave()
        {
            if (selectedExercise != null)
                return true;
            return false;
        }
    }
}