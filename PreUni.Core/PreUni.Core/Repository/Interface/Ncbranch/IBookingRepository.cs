using PreUni.Core.Model;
using System.Threading.Tasks;

namespace PreUni.Core.Repository
{
    public interface IBookingRepository : IGenericRepository<BookingModel>
    {
        Task<int> UpdateAsync(BookingModel model);
    }
}
