using Calendar.DataAccess;
using Calendar.Models;

namespace Calendar.Business
{
    public class UserService: IUserService
    {
        private ApplicationDbContext dbContext;

        public UserService()
        {
            dbContext = new ApplicationDbContext();
        }

        public ApplicationUser GetUserById(string id)
        {
            return dbContext.Set<ApplicationUser>().Find(id);
        }
    }
}