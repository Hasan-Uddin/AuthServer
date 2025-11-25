using Domain.Applications;
using Domain.Customers;
using Domain.Permissions;
using Domain.RolePermissions;
using Domain.Roles;
using Domain.Todos;
using Domain.UserLoginHistories;
using Domain.UserProfiles;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Customer> Customers { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<Applicationapply> Applications { get; }
    DbSet<RolePermission> RolePermissions { get; }
    DbSet<Role> Roles { get; }
    DbSet<UserLoginHistory> UserLoginHistory { get; }
    DbSet<UserProfile> UserProfile { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
