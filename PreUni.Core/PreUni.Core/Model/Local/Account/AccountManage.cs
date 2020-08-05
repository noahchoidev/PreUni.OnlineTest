using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.Core.Model.Local.Account
{
    public enum ManageMessageId
    {
        ChangePasswordSuccess,
        ChangePasswordFail,
        SetPasswordSuccess,
        ResetPasswordSuccess,
        ResetPasswordFail,
        RemoveLoginSuccess,
        MailSentSuccess,
        ActivateAccountSuccess,
        ActivateAccountFail,
        ChangeEmailSuccess,
        ChangeEmailExistEmailFail,
        ChangeEmailPasswordFail,
        ConfirmActivation,
        AuthenticationFail
    }

    public enum ActiveStatusEnum
    {
        Inactive,
        Active,
    }
}
