using PreUni.Core.Repository.Interface;

namespace PreUni.Core.Repository
{
    public interface ICreateBookOrderRepository
    {
        ITermRepository CreateTermRepository();

        ITermProductRepository CreateTermProductRepository();

        IBoardRepository CreateBoardRepository();

        IUserRepository CreateUserRepository();

        IUserRolesRepository CreateUserRoleRepository();

        IRoleRepository CreateRoleRepository();

        ICollegeRepository CreateCollegeRepository();

        ICategoryRepository CreateCategoryRepository();
        
        IProductRepository CreateProductRepository();

        IOrderRepository CreateOrderRepository();

        IOrderDetailRepository CreateOrderDetailRepository();

        IUnPermittableBranchProductRepository CreateUnPermittableBranchProductRepository();
    }
}
