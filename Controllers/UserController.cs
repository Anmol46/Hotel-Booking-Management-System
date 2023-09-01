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

        public UserController(DataContext dataContext, IUserRepository userRepository, ILoggerFactory
        loggerFactory)
        {
            this.dataContext = dataContext;
            this.userRepository = userRepository;
            logger = loggerFactory.CreateLogger<UserController>();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                return UnprocessableEntity();
            }

            return BadRequest();

        }


        // public List<AppIdentityUser> ListUsers()
        // {
        //     var response = userRepository.;

        //     if (response != null)
        //     {
        //         return response.ToList();
        //     }

        //     List<AppIdentityUser> list = new List<AppIdentityUser>();

        //     return list;
        // }
    }
}