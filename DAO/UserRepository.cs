using Data;
using DtoModel;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace DAO
{

    public class UserRepository : IUserRepository
    {

        private readonly UserManager<AppIdentityUser> userManager;

        private readonly ILogger logger;

        private readonly DataContext dataContext;

        public UserRepository(UserManager<AppIdentityUser> userManager, DataContext dataContext, ILoggerFactory loggerFactory)
        {
            this.userManager = userManager;
            this.dataContext = dataContext;
            logger = loggerFactory.CreateLogger<UserRepository>();
        }

        public bool AddBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInfo> CreateUser(CreateUserViewModel createUserViewModel)
        {
            var result = await userManager.CreateAsync(new AppIdentityUser
            {
                UserName = "Anmoa122",
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

            UserInfo userInfo = new UserInfo();

            return userInfo;
        }

        public async Task<bool> DeleteUser(string Id)
        {
            try
            {

                AppIdentityUser user = dataContext.users.Where(x => x.Id == Id).FirstOrDefault();

                if (user != null)
                {
                    dataContext.Remove(user);
                    await dataContext.SaveChangesAsync();
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

        public AppIdentityUser GetUserById(string UserId)
        {
            throw new NotImplementedException();
        }

        // public List<AppIdentityUser> ListUsers()
        // {
        //     var response = dataContext.users.ToList();

        //     if(response != null){

        //     }
        // }

        public bool RemoveBooking(string BookingId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmail(string NewEmail)
        {
            throw new NotImplementedException();
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