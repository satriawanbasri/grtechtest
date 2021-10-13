using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace GrTechTest.Host.Utils
{
    public class DummyUserManager : UserManager<DummyUser>
    {
        public DummyUserManager() : base(new DummyUserStore<DummyUser>()) { }

        public override Task<DummyUser> FindAsync(string username, string password)
        {
            var taskInvoke = Task<DummyUser>.Factory.StartNew(() =>
            {
                if (username == "username" && password == "password")
                    return new DummyUser { Id = "NeedsAnId", UserName = "UsernameHere" };
                return null;
            });
            return taskInvoke;
        }
    }
}