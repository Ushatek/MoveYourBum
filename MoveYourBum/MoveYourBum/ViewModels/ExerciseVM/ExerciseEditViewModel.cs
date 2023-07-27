using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.ExerciseVM
{
    public class ExerciseEditViewModel : AEditViewModel<ExerciseForView>
    {
        #region Fields
        private string name;
        private string description;
        private string properTechniqueDescription = "";
        private string muscleInvolvedDescription = "";

        #endregion

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
        #endregion

        public ExerciseEditViewModel()
        : base()
        {
        }
        public override void LoadProperties(ExerciseForView item)
        {
            Name = item.Name;
            Description = item.Description;
            ProperTechniqueDescription = item.ProperTechniqueDescription;
            MuscleInvolvedDescription= item.MuscleInvolvedDescription;
        }

        public override ExerciseForView SetItem(ExerciseForView item)
        {
            item.Name = Name;
            item.Description = Description;
            item.ProperTechniqueDescription = ProperTechniqueDescription;
            item.MuscleInvolvedDescription = MuscleInvolvedDescription;
            item.ModifiedDate = DateTime.Now;
            return item;
        }

        public override bool ValidateSave()
        {
            if (name != "")
                return true;
            return false;
        }
    }
}
