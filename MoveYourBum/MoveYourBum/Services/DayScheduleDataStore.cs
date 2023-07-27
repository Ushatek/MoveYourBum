using MoveYourBum.Helpers;
using MoveYourBum.Service.Reference;
using MoveYourBum.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace MoveYourBum.Services
{
    public class DayScheduleDataStore : AListDataStore<DayScheduleForView>
    {
        public DayScheduleDataStore()
            : base()
        {
        }
        public override async Task<DayScheduleForView> AddItemToService(DayScheduleForView item)
        {
            return await _service.DaySchedulePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(DayScheduleForView item)
        {
            return await _service.DayScheduleDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<DayScheduleForView> Find(DayScheduleForView item)
        {
            return await _service.DayScheduleGETAsync(item.Id);
        }

        public override async Task<DayScheduleForView> Find(int id)
        {
            return await _service.DayScheduleGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.DayScheduleAllAsync().Result.ToList();

        }

        public override async Task<bool> UpdateItemInService(DayScheduleForView item)
        {
            return await _service.DaySchedulePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
