using DAO;
using Data;
using DtoModel;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger logger;

        private readonly DataContext dataContext;

        private readonly IUserRepository userRepository;

        private readonly UserManager<AppIdentityUser> userManager;

        public UserController(DataContext dataContext, IUserRepository userRepository, ILoggerFactory
        loggerFactory, UserManager<AppIdentityUser> userManager)
        {
            this.dataContext = dataContext;
            this.userRepository = userRepository;
            this.userManager = userManager;
            logger = loggerFactory.CreateLogger<UserController>();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult<UserInfo>> CreateUser([FromBody] CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // var listUsers = userManager.users.ToList().Where(x => x.Email == createUserViewModel.Email);

                    var userInfo = await userRepository.CreateUser(createUserViewModel);

                    if (userInfo != null)
                    {
                        return Ok(userInfo);
                    }

                    return BadRequest();
                }

                catch (Exception ex)
                {
                    logger.LogError(ex.StackTrace);
                }
            }
            else
            {
                return UnprocessableEntity("Could not create an account the with the provided details");
            }

            return BadRequest();

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("delete/{id}")]
        public async Task<ActionResult> DeleteUser(DeleteUserViewModel deleteUserViewModel)
        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(deleteUserViewModel.Email);

                if (user != null)
                {
                    var response = await userRepository.DeleteUser(user);

                    if(response){
                        return Ok("User deleted successfully");
                    }
                }

                return UnprocessableEntity("Cannot find any user registered with this email");
            }

            return BadRequest();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<UserInfo>>> ListUsers()
        {
            var response = await userRepository.ListUsers();

            if (response != null)
            {
                return Ok(response);
            }

            return NoContent();
        }
    }
}