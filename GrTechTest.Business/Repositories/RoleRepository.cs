using GrTechTest.Business.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GrTechTest.Business.Repositories
{
    public class RoleRepository
    {
        public int InsertRole(Role role)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            grTechTestDbContext.Role.Add(role);
            return grTechTestDbContext.SaveChanges();
        }

        public int UpdateRole(Role role)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var roleExist = grTechTestDbContext.Role.Find(role.Id);
            grTechTestDbContext.Entry(roleExist).State = EntityState.Detached;
            grTechTestDbContext.Entry(role).State = EntityState.Modified;
            return grTechTestDbContext.SaveChanges();
        }

        public int PermanentDeleteRole(string id)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var role = grTechTestDbContext.Role.Find(id);
            grTechTestDbContext.Role.Remove(role);
            return grTechTestDbContext.SaveChanges();
        }

        public List<Role> GetRoles()
        {
            return new GrTechTestDbContext().Role.Where(role => !role.IsDeleted).OrderByDescending(role => role.UpdatedOn).ToList();
        }

        public List<Role> GetDeletedRoles()
        {
            return new GrTechTestDbContext().Role.Where(role => role.IsDeleted).OrderByDescending(role => role.UpdatedOn).ToList();
        }

        public Role GetRoleById(string id)
        {
            return new GrTechTestDbContext().Role.FirstOrDefault(role => !role.IsDeleted && role.Id == id);
        }

        public Role GetDeletedRoleById(string id)
        {
            return new GrTechTestDbContext().Role.FirstOrDefault(role => role.IsDeleted && role.Id == id);
        }
    }
}