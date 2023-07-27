using MoveYourBum.Service.Reference;
using MoveYourBum.ViewModels.Abstract;
using System;
using Xamarin.Forms;

namespace MoveYourBum.ViewModels.ExercisePhotoVM
{
    [QueryProperty(nameof(IdExercise), nameof(IdExercise))]
    public class NewExercisePhotoViewModel : ANewViewModel<ExercisePhotoForView>
    {
        #region Fields

        private int idExercise;
        string fileName;
        string fileUrl;
        #endregion Fields

        #region Properties
        
        public int IdExercise
        {
            get => idExercise;
            set => SetProperty(ref idExercise, value);
        }
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
        #endregion Properties

        public NewExercisePhotoViewModel()
            : base()
        {
        }
        public override ExercisePhotoForView SetItem()
        {
            return new ExercisePhotoForView
            {
                IdExercise = this.IdExercise,
                FileName = this.FileName,
                FileUrl = this.FileUrl,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
            };
        }

        public override bool ValidateSave()
        {
            if (fileUrl != "")
                return true;
            return false;
        }
    }
}
