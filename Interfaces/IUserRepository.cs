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

        Task<bool> UpdateEmail(UpdateUserEmailViewModel updateUserEmailViewModel);

        bool UpdatePhoneNumber(string NewPhoneNumber);

        Task<bool> RemoveBooking(string BookingId);

        Task<List<UserInfo>> ListUsers();

        Task<AppIdentityUser> GetUserById(string UserId);

    }
}