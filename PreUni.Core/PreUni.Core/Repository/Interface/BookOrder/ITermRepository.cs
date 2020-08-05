using PreUni.Core.Model;
using System.Threading.Tasks;

namespace PreUni.Core.Repository.Interface
{
    public interface ITermRepository : IGenericRepository<TermModel>
    {
        Task<int> UpdateAsync(TermModel TermModel);
    }
}
