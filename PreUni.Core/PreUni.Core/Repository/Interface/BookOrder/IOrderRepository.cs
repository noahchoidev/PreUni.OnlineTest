using PreUni.Core.Model;
using PreUni.Core.Model.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.Core.Repository.Interface
{
    public interface IOrderRepository : IGenericRepository<OrderModel>
    {
        Task<int> UpdateAsync(OrderModel orderModel);

        Task<bool> IsDuplicatedOrderNo(string orderNo);

        Task<IEnumerable<OrderReportViewModel>> GetWeeklyOrderAsync(int Term, string BranchCode);
    }
}
