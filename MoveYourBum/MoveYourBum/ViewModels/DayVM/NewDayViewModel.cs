using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.DayVM
{
    public class NewDayViewModel : ANewViewModel<DayForView>
    {
        public NewDayViewModel()
            : base()
        {
            Date = DateTime.Today;
        }

        #region Fields
        private DateTime date;
        private string notes = "";
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

        public override DayForView SetItem()
        {
            return new DayForView
            {
                Date = Date,
                Notes = Notes,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
            };
        }

        public override bool ValidateSave()
        {
            if (Date != null)
                return true;
            return false;
        }
    }
}
