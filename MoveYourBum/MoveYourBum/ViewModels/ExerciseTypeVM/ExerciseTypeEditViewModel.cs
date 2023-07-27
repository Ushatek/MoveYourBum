using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.ExerciseTypeVM
{
    public class ExerciseTypeEditViewModel : AEditViewModel<ExerciseTypeForView>
    {
        #region Fields
        private string name;
        private string description;

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

        public ExerciseTypeEditViewModel()
        : base()
        {
        }

        public override void LoadProperties(ExerciseTypeForView item)
        {
            Name = item.Name;
            Description = item.Description;
        }

        public override ExerciseTypeForView SetItem(ExerciseTypeForView item)
        {
            item.Name = Name;
            item.Description = Description;
            item.ModifiedDate = DateTime.Now;
            return item;
        }

        public override bool ValidateSave()
        {
            return Name != "";
        }
    }
}