using MoveYourBum.Service.Reference;
using MoveYourBum.Services.Abstract;
using System.Threading.Tasks;
using MoveYourBum.Helpers;
using System.Linq;

namespace MoveYourBum.Services
{
    public class ExerciseTypeDataStore : AListDataStore<ExerciseTypeForView>
    {
        public ExerciseTypeDataStore()
            : base()
        {
        }
        public override async Task<ExerciseTypeForView> AddItemToService(ExerciseTypeForView item)
        {
            return await _service.ExerciseTypePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(ExerciseTypeForView item)
        {
            return await _service.ExerciseTypeDELETEAsync(item.Id).HandleRequest();
        }
        public override async Task<ExerciseTypeForView> Find(ExerciseTypeForView item)
        {
            return await _service.ExerciseTypeGETAsync(item.Id);
        }

        public override async Task<ExerciseTypeForView> Find(int id)
        {
            return await _service.ExerciseTypeGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ExerciseTypeAllAsync().Result.ToList();

        }

        public override async Task<bool> UpdateItemInService(ExerciseTypeForView item)
        {
            return await _service.ExerciseTypePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
