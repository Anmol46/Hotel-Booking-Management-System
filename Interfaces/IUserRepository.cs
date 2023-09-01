using DtoModel;
using Models;

namespace Interfaces
{

    public interface IUserRepository
    {

        Task<UserInfo> CreateUser(CreateUserViewModel createUserViewModel);

        Task<bool> DeleteUser(string Id);

        bool UpdateFirstName(string firstname);

        bool UpdateLastName(string lastname);

        bool UpdateEmail(string NewEmail);

        bool UpdatePhoneNumber(string NewPhoneNumber);

        bool AddBooking(Booking booking);

        bool RemoveBooking(string BookingId);

        // List<AppIdentityUser> ListUsers();

        AppIdentityUser GetUserById(string UserId);

    }
}