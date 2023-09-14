using Data;
using DtoModel;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAO
{

    public class UserRepository : IUserRepository
    {

        private readonly UserManager<AppIdentityUser> userManager;

        private readonly IBookingRepository bookingRepository;

        private readonly ILogger logger;

        private readonly DataContext dataContext;

        public UserRepository(UserManager<AppIdentityUser> userManager, DataContext dataContext, IBookingRepository bookingRepository, ILoggerFactory loggerFactory)
        {
            this.userManager = userManager;
            this.bookingRepository = bookingRepository;
            this.dataContext = dataContext;
            logger = loggerFactory.CreateLogger<UserRepository>();
        }

        public async Task<UserInfo> CreateUser(CreateUserViewModel createUserViewModel)
        {
            try
            {
                var userWithEmail = await userManager.FindByEmailAsync(createUserViewModel.Email);
                var userWithPhone = await dataContext.users.Select(x => x.PhoneNumber == createUserViewModel.PhoneNumber).FirstOrDefaultAsync();
                var userWithName = await userManager.FindByNameAsync(createUserViewModel.UserName);

                if (userWithEmail == null && !userWithPhone && userWithName == null)
                {
                    var result = await userManager.CreateAsync(new AppIdentityUser
                    {
                        UserName = createUserViewModel.UserName,
                        Id = Guid.NewGuid().ToString(),
                        FirstName = createUserViewModel.FirstName,
                        LastName = createUserViewModel.LastName,
                        PhoneNumber = createUserViewModel.PhoneNumber,
                        Email = createUserViewModel.Email
                    }, createUserViewModel.Password);

                    if (result.Succeeded)
                    {
                        var createdUser = await userManager.FindByEmailAsync(createUserViewModel.Email);

                        return new UserInfo
                        {
                            FirstName = createdUser.FirstName,
                            LastName = createdUser.LastName,
                            Email = createdUser.Email,
                            Phone = createdUser.PhoneNumber
                        };
                    }

                    return new UserInfo();
                }

                return new UserInfo();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                UserInfo emptyUserInfo = new UserInfo();
                return emptyUserInfo;
            }

        }

        public async Task<bool> DeleteUser(AppIdentityUser User)
        {
            try
            {
                await userManager.DeleteAsync(User);
                dataContext.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }
        }

        public async Task<AppIdentityUser> GetUserById(string UserId)
        {
            return await userManager.FindByIdAsync(UserId);
        }

        public async Task<List<UserInfo>> ListUsers()
        {
            var response = await dataContext.users.ToListAsync();

            List<UserInfo> userInfos = new List<UserInfo>();

            if (response.Count() > 0)
            {

                foreach (var user in response)
                {
                    userInfos.Add(
                        new UserInfo
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Phone = user.PhoneNumber,
                            Email = user.Email
                        }
                    );
                }

                return userInfos;
            }

            return userInfos;

        }

        public async Task<bool> RemoveBooking(string BookingId)
        {
            try
            {
                var response = await bookingRepository.DeleteBooking(BookingId);

                if (response)
                {
                    return true;
                }

                return false;
            }

            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }
        }

        public bool UpdateEmail(string NewEmail)
        {
            
        }

        public bool UpdateFirstName(string firstname)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLastName(string lastname)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePhoneNumber(string NewPhoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}