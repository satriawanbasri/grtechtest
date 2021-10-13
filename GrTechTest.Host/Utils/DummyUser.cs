using Microsoft.AspNet.Identity;

namespace GrTechTest.Host.Utils
{
    public class DummyUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}