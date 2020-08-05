using PreUni.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.Core.Repository.Interface
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
        bool IsDuplicatedProduct(ProductModel productModel);

        Task<int> UpdateAsync(ProductModel productModel);

        //Task<List<ProductViewModel>> GetTheTermBooksInfo(int? TermID);
    }
}
