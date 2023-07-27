using MoveYourBum.Helpers;
using MoveYourBum.Service.Reference;
using MoveYourBum.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace MoveYourBum.Services
{
    public class ScheduleExerciseSetDataStore : AListDataStore<ScheduleExerciseSetForView>
    {
        public ScheduleExerciseSetDataStore()
            : base()
        {
        }
        public override async Task<ScheduleExerciseSetForView> AddItemToService(ScheduleExerciseSetForView item)
        {
            return await _service.ScheduleExerciseSetPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(ScheduleExerciseSetForView item)
        {
            return await _service.ScheduleExerciseSetDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<ScheduleExerciseSetForView> Find(ScheduleExerciseSetForView item)
        {
            return await _service.ScheduleExerciseSetGETAsync(item.Id);
        }

        public override async Task<ScheduleExerciseSetForView> Find(int id)
        {
            return await _service.ScheduleExerciseSetGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ScheduleExerciseSetAllAsync().Result.ToList();

        }

        public override async Task<bool> UpdateItemInService(ScheduleExerciseSetForView item)
        {
            return await _service.ScheduleExerciseSetPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
