using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ExerciseVM
{
    [QueryProperty(nameof(IdExerciseType), nameof(IdExerciseType))]
    public class NewExerciseViewModel : ANewViewModel<ExerciseForView>
    {
        public NewExerciseViewModel()
            : base()
        {
        }

        #region Fields
        private string name = "";
        private string description = "";
        private string properTechniqueDescription = "";
        private string muscleInvolvedDescription = "";
        private int idExerciseType;
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
        public int IdExerciseType
        {
            get => idExerciseType;
            set => SetProperty(ref idExerciseType, value);
        }
        #endregion

        public override ExerciseForView SetItem()
        {
            return new ExerciseForView
            {
                IdExerciseType = this.IdExerciseType,
                Name = Name,
                Description = Description,
                ProperTechniqueDescription = ProperTechniqueDescription,
                MuscleInvolvedDescription = MuscleInvolvedDescription,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
            };
        }

        public override bool ValidateSave()
        {
            if (name != "" && IdExerciseType != 0)
                return true;
            return false;
        }
    }
}
