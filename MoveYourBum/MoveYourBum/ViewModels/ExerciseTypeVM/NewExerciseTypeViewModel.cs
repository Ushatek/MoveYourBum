using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.ExerciseTypeVM
{
    public class NewExerciseTypeViewModel : ANewViewModel<ExerciseTypeForView>
    {
        public NewExerciseTypeViewModel()
            : base()
        {
        }
        #region Fields
        private string name = "";
        private string description = "";
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
        #endregion
        public override ExerciseTypeForView SetItem()
        {
            return new ExerciseTypeForView
            {
                Name = Name,
                Description = Description,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
            };
        }

        public override bool ValidateSave()
        {
            return name != "";
        }
    }
}
