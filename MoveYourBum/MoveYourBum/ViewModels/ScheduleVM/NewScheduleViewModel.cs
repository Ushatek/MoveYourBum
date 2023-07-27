using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.ScheduleVM
{
    public class NewScheduleViewModel : ANewViewModel<ScheduleForView>
    {
        public NewScheduleViewModel()
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

        public override ScheduleForView SetItem()
        {
            return new ScheduleForView
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
            if (name != "")
                return true;
            return false;
        }
    }
}