using System;

namespace PreUni.Core.Model
{
    //[Table("UserProfile")]
    public class UserProfile
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    //[Table("webpages_Membership")]
    public class webpages_Membership
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public string ConfirmationToken { get; set; }

        public Nullable<bool> IsConfirmed { get; set; }

        public Nullable<System.DateTime> LastPasswordFailureDate { get; set; }

        public int PasswordFailuresSinceLastSuccess { get; set; }

        public string Password { get; set; }

        public Nullable<System.DateTime> PasswordChangedDate { get; set; }

        public string PasswordSalt { get; set; }

        public string PasswordVerificationToken { get; set; }

        public Nullable<System.DateTime> PasswordVerificationTokenExpirationDate { get; set; }

    }
}
