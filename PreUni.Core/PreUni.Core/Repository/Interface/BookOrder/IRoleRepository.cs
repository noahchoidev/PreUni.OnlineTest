using PreUni.Core.Model;
using System.Threading.Tasks;

namespace PreUni.Core.Repository.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRoleRepository : IGenericRepository<RoleModel>
    {
        Task<int> UpdateAsync(RoleModel RoleModel);
    }
}
