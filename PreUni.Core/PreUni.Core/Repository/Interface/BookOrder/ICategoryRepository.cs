using PreUni.Core.Model;
using System.Threading.Tasks;

namespace PreUni.Core.Repository.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICategoryRepository : IGenericRepository<CategoryModel>
    {
        Task<int> UpdateAsync(CategoryModel category);
    }

}
