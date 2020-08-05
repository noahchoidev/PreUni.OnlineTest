using PreUni.Core.Model;
using PreUni.Core.Model.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.Core.Repository.Interface
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetailModel>
    {
        Task<int> UpdateAsync(OrderDetailModel orderDetailModel);

        Task<List<OrderDetailViewModel>> GetOrderDetailsAsync(int orderID);

        Task<List<OrderDetailViewModel>> GetOrderDetailsAsync(int? termId, string branchCode, int pageSize = 10, int pageNumber = 1);

        Task<OrderDetailViewModel> GetOrderDetailsAsyncWith(int orderDetailID);

        Task DeleteAsync(int id);
    }
}
