using GrTechTest.Business.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GrTechTest.Business.Repositories
{
    public class UserRepository
    {
        public int InsertUser(User user)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            grTechTestDbContext.User.Add(user);
            return grTechTestDbContext.SaveChanges();
        }

        public int UpdateUser(User user)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var userExist = grTechTestDbContext.User.Find(user.Id);
            grTechTestDbContext.Entry(userExist).State = EntityState.Detached;
            grTechTestDbContext.Entry(user).State = EntityState.Modified;
            return grTechTestDbContext.SaveChanges();
        }

        public int PermanentDeleteUser(string id)
        {
            var grTechTestDbContext = new GrTechTestDbContext();
            var user = grTechTestDbContext.User.Find(id);
            grTechTestDbContext.User.Remove(user);
            return grTechTestDbContext.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return new GrTechTestDbContext().User.Where(user => !user.IsDeleted).OrderByDescending(user => user.UpdatedOn).ToList();
        }

        public List<User> GetDeletedUsers()
        {
            return new GrTechTestDbContext().User.Where(user => user.IsDeleted).OrderByDescending(user => user.UpdatedOn).ToList();
        }

        public User GetUserById(string id)
        {
            return new GrTechTestDbContext().User.FirstOrDefault(user => !user.IsDeleted && user.Id == id);
        }

        public User GetDeletedUserById(string id)
        {
            return new GrTechTestDbContext().User.FirstOrDefault(user => user.IsDeleted && user.Id == id);
        }

        public User GetUserByEmail(string email)
        {
            return new GrTechTestDbContext().User.FirstOrDefault(user => !user.IsDeleted && user.Email == email);
        }
    }
}