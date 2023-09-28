using System.Net;
using System.Runtime.Intrinsics.X86;
using DAO;
using Data;
using DtoModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;

namespace Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly BookingRepository bookingRepository;

        private readonly DataContext dataContext;

        private readonly ILogger logger;


        public BookingController(BookingRepository bookingRepository, DataContext dataContext, ILoggerFactory loggerFactory)
        {
            this.bookingRepository = bookingRepository;
            this.dataContext = dataContext;
            logger = loggerFactory.CreateLogger<BookingController>();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("create")]
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


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("cancel")]
        public async Task<ActionResult> CancelBooking(CancelBookingViewModel cancelBookingViewModel)
        {
            var booking = await dataContext.Bookings.Where(x => x.Id == cancelBookingViewModel.BookingId).FirstOrDefaultAsync();

            if (booking != null && DateTime.Now < booking.CheckIn.Subtract(TimeSpan.FromHours(24)))
            {
                var response = await bookingRepository.DeleteBooking(cancelBookingViewModel.BookingId);

                if (response)
                {
                    return Ok();
                }

                return UnprocessableEntity("Cannot cancel the booking");
            }

            var res = await bookingRepository.DeleteBooking(cancelBookingViewModel.BookingId);

            if (res)
            {
                return Ok("Cancellation would be processed after receiving the payment of cancellation fees");
            }

            return UnprocessableEntity("Cannot cancel the booking");

        }

    }
}