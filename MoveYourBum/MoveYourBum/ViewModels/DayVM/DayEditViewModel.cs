using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.DayVM
{
    public class DayEditViewModel : AEditViewModel<DayForView>
    {
        #region Fields
        private DateTime date;
        private string notes;

        #endregion

        #region Properties
        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public string Notes
        {
            get => notes;
            set => SetProperty(ref notes, value);
        }
        #endregion

        public DayEditViewModel()
        : base()
        {
        }
        public override void LoadProperties(DayForView item)
        {
            Date = item.Date.Value.Date;
            Notes = item.Notes;
        }

        public override DayForView SetItem(DayForView item)
        {
            item.Date = Date;
            item.Notes = Notes;
            item.ModifiedDate = DateTime.Now;
            return item;
        }

        public override bool ValidateSave()
        {
            if (Date != null)
                return true;
            return false;
        }
    }
}
