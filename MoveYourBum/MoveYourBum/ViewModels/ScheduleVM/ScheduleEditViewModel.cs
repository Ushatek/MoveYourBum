using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.ScheduleVM
{
    public class ScheduleEditViewModel : AEditViewModel<ScheduleForView>
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

        public ScheduleEditViewModel()
        : base()
        {
        }
        public override void LoadProperties(ScheduleForView item)
        {
            Name = item.Name;
            Description = item.Description;
        }

        public override ScheduleForView SetItem(ScheduleForView item)
        {
            item.Name = Name;
            item.Description = Description;
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
