using Data;
using DtoModel;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {

        private readonly DataContext dataContext;

        private readonly IRoomRepository roomRepository;

        private readonly ILogger logger;

        public RoomController(DataContext dataContext, IRoomRepository roomRepository, ILoggerFactory loggerFactory)
        {
            this.dataContext = dataContext;
            this.roomRepository = roomRepository;
            this.logger = loggerFactory.CreateLogger<RoomController>();
        }


        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult> CreateRoom(CreateRoomViewModel createRoomViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await roomRepository.CreateRoom(createRoomViewModel);

                    if (response)
                    {
                        return Ok("Successfully updated room details");
                    }

                    return UnprocessableEntity();
                }

                catch (Exception ex)
                {
                    logger.LogError(ex.StackTrace);
                }

            }

            return BadRequest();
        }

        [HttpPost("updatePrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateRoomPrice(UpdateRoomPriceViewModel updateRoomPriceViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await roomRepository.UpdatePrice(updateRoomPriceViewModel);

                    if (response)
                    {
                        return Ok("Room pricing updated successfully");
                    }

                    return UnprocessableEntity();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.StackTrace);
                }
            }

            return BadRequest();
        }

        [HttpPost("updateRoomAvailability")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateRoomAvailability(UpdateRoomAvailabityViewModel updateRoomAvailabityViewModel)
        {
            if (ModelState.IsValid)
            {
                var response = await roomRepository.UpdateAvailability(updateRoomAvailabityViewModel);

                if (response)
                {
                    return Ok("Room availability successfully updated");
                }

                return UnprocessableEntity();
            }

            return BadRequest();
        }
    }
}