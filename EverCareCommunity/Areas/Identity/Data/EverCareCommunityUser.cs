using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EverCareCommunity.Areas.Identity.Data;


public enum RoleType
{
    Admin,
    Manager,
    Doctor,
    Caregiver
}

// Add profile data for application users by adding properties to the EverCareCommunityUser class
public class EverCareCommunityUser : IdentityUser
{
    private RoleType role;

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public RoleType Role { get; set; } = RoleType.Admin;
}

