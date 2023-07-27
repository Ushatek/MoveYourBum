using MoveYourBum.Helpers;
using MoveYourBum.Service.Reference;
using MoveYourBum.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace MoveYourBum.Services
{
    public class ScheduleExerciseDataStore : AListDataStore<ScheduleExerciseForView>
    {
        public ScheduleExerciseDataStore()
            : base()
        {
        }
        public override async Task<ScheduleExerciseForView> AddItemToService(ScheduleExerciseForView item)
        {
            return await _service.ScheduleExercisePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(ScheduleExerciseForView item)
        {
            return await _service.ScheduleExerciseDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<ScheduleExerciseForView> Find(ScheduleExerciseForView item)
        {
            return await _service.ScheduleExerciseGETAsync(item.Id);
        }

        public override async Task<ScheduleExerciseForView> Find(int id)
        {
            return await _service.ScheduleExerciseGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ScheduleExerciseAllAsync().Result.ToList();

        }

        public override async Task<bool> UpdateItemInService(ScheduleExerciseForView item)
        {
            return await _service.ScheduleExercisePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
