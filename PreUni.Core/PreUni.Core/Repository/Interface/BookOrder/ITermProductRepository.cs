using PreUni.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.Core.Repository.Interface
{
    public interface ITermProductRepository : IGenericRepository<TermProductModel>
    {
        Task<int> UpdateAsync(TermProductModel termProductModel);

        Task<List<ProductViewModel>> GetTheTermBooksInfo(int? TermID);

        Task<ProductViewModel> GetTheTermBooksInfo(int? TermID, int? ProductID);
    }
}
