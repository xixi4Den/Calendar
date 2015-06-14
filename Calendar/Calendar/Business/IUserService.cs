using Calendar.Models;

namespace Calendar.Business
{
    public interface IUserService
    {
        ApplicationUser GetUserById(string id);
    }
}