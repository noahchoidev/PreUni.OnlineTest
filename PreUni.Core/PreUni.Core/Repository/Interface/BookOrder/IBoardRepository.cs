using PreUni.Core.Model;
using System.Threading.Tasks;

namespace PreUni.Core.Repository.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBoardRepository : IGenericRepository<BoardModel>
    {
        Task<int> UpdateAsync(BoardModel TermModel);
    }
}
