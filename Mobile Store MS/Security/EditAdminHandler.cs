using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store_MS.Security
{
    public class EditAdminHandler : IAuthorizationRequirement
    {

    }
    public class EditEmployeesHandler: IAuthorizationRequirement
    {

    }
    public class ManageRoleHandler : IAuthorizationRequirement
    {

    }
}
