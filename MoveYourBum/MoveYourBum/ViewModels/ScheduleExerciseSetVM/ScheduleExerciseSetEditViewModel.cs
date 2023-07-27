using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.ScheduleExerciseSetVM
{
    public class ScheduleExerciseSetEditViewModel : AEditViewModel<ScheduleExerciseSetForView>
    {
        public ScheduleExerciseSetEditViewModel()
        : base()
        {
        }

        #region Fields
        private string plannedReps = "";
        private string actualReps = "";
        private string weightUsed = "";
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

        #endregion

        public override void LoadProperties(ScheduleExerciseSetForView item)
        {
            PlannedReps = item.PlannedReps;
            ActualReps = item.ActualReps;
            WeightUsed = item.WeightUsed;
        }

        public override ScheduleExerciseSetForView SetItem(ScheduleExerciseSetForView item)
        {
            item.PlannedReps = PlannedReps;
            item.ActualReps = ActualReps;
            item.WeightUsed = WeightUsed;
            item.ModifiedDate = DateTime.Now;
            return item;
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
