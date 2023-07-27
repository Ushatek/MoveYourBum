using MoveYourBum.Helpers;
using MoveYourBum.Service.Reference;
using MoveYourBum.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace MoveYourBum.Services
{
    public class ExercisePhotoDataStore : AListDataStore<ExercisePhotoForView>
    {
        public ExercisePhotoDataStore()
            : base()
        {
        }
        public override async Task<ExercisePhotoForView> AddItemToService(ExercisePhotoForView item)
        {
            return await _service.ExercisePhotoPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(ExercisePhotoForView item)
        {
            return await _service.ExercisePhotoDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<ExercisePhotoForView> Find(ExercisePhotoForView item)
        {
            return await _service.ExercisePhotoGETAsync(item.Id);
        }

        public override async Task<ExercisePhotoForView> Find(int id)
        {
            return await _service.ExercisePhotoGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ExercisePhotoAllAsync().Result.ToList();

        }

        public override async Task<bool> UpdateItemInService(ExercisePhotoForView item)
        {
            return await _service.ExercisePhotoPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
