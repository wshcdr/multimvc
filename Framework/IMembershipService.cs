﻿using System.Web.Security;

namespace BA.MultiMvc.Framework
{
    public interface IMembershipService:ITenantModel 
    {
        int MinPasswordLength { get; }
        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

}
