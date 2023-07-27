using MoveYourBum.Helpers;
using MoveYourBum.Service.Reference;
using MoveYourBum.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace MoveYourBum.Services
{
    public class ScheduleDataStore : AListDataStore<ScheduleForView>
    {
        public ScheduleDataStore()
            : base()
        {
        }
        public override async Task<ScheduleForView> AddItemToService(ScheduleForView item)
        {
            return await _service.SchedulePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(ScheduleForView item)
        {
            return await _service.ScheduleDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<ScheduleForView> Find(ScheduleForView item)
        {
            return await _service.ScheduleGETAsync(item.Id);
        }

        public override async Task<ScheduleForView> Find(int id)
        {
            return await _service.ScheduleGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ScheduleAllAsync().Result.ToList();

        }

        public override async Task<bool> UpdateItemInService(ScheduleForView item)
        {
            return await _service.SchedulePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
