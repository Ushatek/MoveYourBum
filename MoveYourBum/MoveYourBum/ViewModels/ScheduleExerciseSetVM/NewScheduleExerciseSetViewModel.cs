using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ScheduleExerciseSetVM
{
    [QueryProperty(nameof(IdScheduleExercise), nameof(IdScheduleExercise))]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class NewScheduleExerciseSetViewModel : ANewViewModel<ScheduleExerciseSetForView>
    {
        public NewScheduleExerciseSetViewModel()
            : base()
        {
        }

        #region Fields
        private string plannedReps = "";
        private string actualReps = "";
        private string weightUsed = "";
        private int idScheduleExercise;
        private int itemId;
        #endregion

        #region Properties
        public string PlannedReps
        {
            get => plannedReps;
            set => SetProperty(ref plannedReps, value);
        }

        public string ActualReps
        {
            get => actualReps;
            set => SetProperty(ref actualReps, value);
        }
        public string WeightUsed
        {
            get => weightUsed;
            set => SetProperty(ref weightUsed, value);
        }
        public int IdScheduleExercise
        {
            get => idScheduleExercise;
            set => SetProperty(ref idScheduleExercise, value);
        }
        public int ItemId
        {
            get => itemId;
            set => SetProperty(ref itemId, value);
        }
        #endregion
        public override ScheduleExerciseSetForView SetItem()
        {
            return new ScheduleExerciseSetForView
            {
                IdScheduleExercise = IdScheduleExercise,
                IdDaySchedule = ItemId,
                PlannedReps = PlannedReps,
                ActualReps = ActualReps,
                WeightUsed = WeightUsed,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
            };
        }

        public bool IsNumericNotNegative(string item)
        {
            int number;
            var isNumber = int.TryParse(item, out number);
            return number >= 0 && isNumber;
        }

        public override bool ValidateSave()
        {
            if (plannedReps != "" && IsNumericNotNegative(plannedReps)
                && actualReps != "" && IsNumericNotNegative(actualReps)
                && weightUsed != "" && IsNumericNotNegative(weightUsed))
                return true;
            return false;
        }
    }
}
