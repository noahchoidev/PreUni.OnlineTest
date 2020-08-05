using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.Core.Service
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string branchMail, string subject, string body);
    }
}
