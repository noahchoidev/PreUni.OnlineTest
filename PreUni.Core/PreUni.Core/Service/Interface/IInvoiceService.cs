using PreUni.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.Core.Service
{
    public interface IInvoiceService
    {
        Task<InvoiceViewModel> MakeInvoice();

        //Task<List<OrderDetailViewModel>> ConfirmOrderAboutInvoice();

        void SetOrderID(int orderid);
    }
}
