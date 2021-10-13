using GrTechTest.Business.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GrTechTest.Business.Repositories
{
    public class UserRoleRepository
    {
        public int InsertUserRole(UserRole userRole)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            grTechTestDbContext.UserRole.Add(userRole);
            return grTechTestDbContext.SaveChanges();
        }

        public int UpdateUserRole(UserRole userRole)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var userRoleExist = grTechTestDbContext.UserRole.Find(userRole.Id);
            grTechTestDbContext.Entry(userRoleExist).State = EntityState.Detached;
            grTechTestDbContext.Entry(userRole).State = EntityState.Modified;
            return grTechTestDbContext.SaveChanges();
        }

        public int PermanentDeleteUserRole(string id)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var userRole = grTechTestDbContext.UserRole.Find(id);
            grTechTestDbContext.UserRole.Remove(userRole);
            return grTechTestDbContext.SaveChanges();
        }

        public List<UserRole> GetUserRoles()
        {
            return new GrTechTestDbContext().UserRole
                .Include(userRole => userRole.User)
                .Include(userRole => userRole.Role)
                .Where(userRole => !userRole.IsDeleted)
                .OrderByDescending(userRole => userRole.UpdatedOn).ToList();
        }

        public List<UserRole> GetDeletedUserRoles()
        {
            return new GrTechTestDbContext().UserRole
                .Include(userRole => userRole.User)
                .Include(userRole => userRole.Role)
                .Where(userRole => userRole.IsDeleted)
                .OrderByDescending(userRole => userRole.UpdatedOn).ToList();
        }

        public UserRole GetUserRoleById(string id)
        {
            return new GrTechTestDbContext().UserRole
                .Include(userRole => userRole.User)
                .Include(userRole => userRole.Role)
                .FirstOrDefault(userRole => !userRole.IsDeleted && userRole.Id == id);
        }

        public UserRole GetDeletedUserRoleById(string id)
        {
            return new GrTechTestDbContext().UserRole.FirstOrDefault(userRole => userRole.IsDeleted && userRole.Id == id);
        }

        public List<UserRole> GetUserRolesByUserId(string userId)
        {
            return new GrTechTestDbContext().UserRole
                .Include(userRole => userRole.User)
                .Include(userRole => userRole.Role)
                .Where(userRole => !userRole.IsDeleted && userRole.UserId == userId)
                .OrderByDescending(userRole => userRole.UpdatedOn).ToList();
        }
    }
}