using MoveYourBum.Helpers;
using MoveYourBum.Service.Reference;
using MoveYourBum.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace MoveYourBum.Services
{
    public class ExerciseDataStore : AListDataStore<ExerciseForView>
    {
        public ExerciseDataStore()
            : base()
        {
        }
        public override async Task<ExerciseForView> AddItemToService(ExerciseForView item)
        {
            return await _service.ExercisePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(ExerciseForView item)
        {
            return await _service.ExerciseDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<ExerciseForView> Find(ExerciseForView item)
        {
            return await _service.ExerciseGETAsync(item.Id);
        }

        public override async Task<ExerciseForView> Find(int id)
        {
            return await _service.ExerciseGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ExerciseAllAsync().Result.ToList();

        }

        public override async Task<bool> UpdateItemInService(ExerciseForView item)
        {
            return await _service.ExercisePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
