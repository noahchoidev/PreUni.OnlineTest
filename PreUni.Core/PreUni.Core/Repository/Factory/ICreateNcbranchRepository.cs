namespace PreUni.Core.Repository
{
    public interface ICreateNcbranchRepository
    {
        IBookingRepository CreateBookingRepository();

        IScanningTimeRepository CreateScanningTimeRepository();
    }
}
