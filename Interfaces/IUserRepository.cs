using DtoModel;
using Models;

namespace Interfaces
{

    public interface IUserRepository
    {

        Task<UserInfo> CreateUser(CreateUserViewModel createUserViewModel);

        Task<bool> DeleteUser(AppIdentityUser User);

        bool UpdateFirstName(string firstname);

        bool UpdateLastName(string lastname);

        bool UpdateEmail(string NewEmail);

        bool UpdatePhoneNumber(string NewPhoneNumber);

        bool RemoveBooking(string BookingId);

        Task<List<UserInfo>> ListUsers();

        AppIdentityUser GetUserById(string UserId);

    }
}