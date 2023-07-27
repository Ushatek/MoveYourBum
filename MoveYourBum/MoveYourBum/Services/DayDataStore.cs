using MoveYourBum.Helpers;
using MoveYourBum.Service.Reference;
using MoveYourBum.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace MoveYourBum.Services
{
    public class DayDataStore : AListDataStore<DayForView>
    {
        public DayDataStore()
            :base()
        {
        }

        public override async Task<DayForView> AddItemToService(DayForView item)
        {
            return await _service.DayPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(DayForView item)
        {
            return await _service.DayDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<DayForView> Find(DayForView item)
        {
            return await _service.DayGETAsync(item.Id);
        }

        public override async Task<DayForView> Find(int id)
        {
            return await _service.DayGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.DayAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(DayForView item)
        {
            return await _service.DayPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
