using System.Runtime.Intrinsics.X86;
using DAO;
using DtoModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;

namespace Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly BookingRepository bookingRepository;

        private readonly ILogger logger;


        public BookingController(BookingRepository bookingRepository, ILoggerFactory loggerFactory)
        {
            this.bookingRepository = bookingRepository;
            logger = loggerFactory.CreateLogger<BookingController>();
        }


        public async Task<ActionResult> CreateBooking(CreateBookingViewModel createBookingViewModel)
        {

            if (ModelState.IsValid)
            {

                try
                {

                    // Booking booking = new Booking
                    // {
                    //     Id = new Guid().ToString(),
                    //     UserId = createBookingViewModel.UserId,
                    //     RoomId = createBookingViewModel.RoomId,
                    //     DateCreated = DateTime.Now,
                    //     CheckIn = createBookingViewModel.CheckIn,
                    //     CheckOut = createBookingViewModel.CheckOut,
                    //     Completed = false,
                    //     Paid = createBookingViewModel.Paid,
                    //     Guests = createBookingViewModel.Guests,
                    //     CustomerName = createBookingViewModel.CustomerName,
                    //     CustomerPhone = createBookingViewModel.CustomerPhone
                    // };

                    var response = await bookingRepository.CreateBooking(createBookingViewModel);

                    if (response)
                    {
                        return Ok("Booking successfully created");
                    }

                    return UnprocessableEntity("Cannot create a booking with the provided details");
                }

                catch (Exception ex)
                {
                    logger.LogError(ex.StackTrace);
                }
            }

            return BadRequest();

        }

    }
}