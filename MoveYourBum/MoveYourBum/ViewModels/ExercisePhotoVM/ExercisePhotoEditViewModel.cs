using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;

namespace MoveYourBum.ViewModels.ExercisePhotoVM
{
    public class ExercisePhotoEditViewModel : AEditViewModel<ExercisePhotoForView>
    {
        #region Fields
        private string fileName;
        private string fileUrl;
        #endregion

        #region Properties

        public string FileName
        {
            get => fileName;
            set => SetProperty(ref fileName, value);
        }

        public string FileUrl
        {
            get => fileUrl;
            set => SetProperty(ref fileUrl, value);
        }
        #endregion

        public ExercisePhotoEditViewModel()
        : base()
        {
        }
        public override void LoadProperties(ExercisePhotoForView item)
        {
            FileName = item.FileName;
            FileUrl = item.FileUrl;
        }

        public override ExercisePhotoForView SetItem(ExercisePhotoForView item)
        {
            item.FileName = FileName;
            item.FileUrl = FileUrl;
            item.ModifiedDate = DateTime.Now;
            return item;
        }

        public override bool ValidateSave()
        {
            if (fileUrl != "")
                return true;
            return false;
        }
    }
}
