using Data;
using DtoModel;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DAO
{

    public class BookingRepository : IBookingRepository
    {

        private readonly DataContext dataContext;

        private readonly ILogger logger;


        public BookingRepository(DataContext dataContext, ILoggerFactory loggerFactory)
        {
            this.dataContext = dataContext;
            logger = loggerFactory.CreateLogger<BookingRepository>();

        }

        public async Task<bool> CreateBooking(CreateBookingViewModel createBookingViewModel)
        {
            try
            {

                Booking booking = new Booking
                {
                    Id = new Guid().ToString(),
                    UserId = createBookingViewModel.UserId,
                    RoomId = createBookingViewModel.RoomId,
                    DateCreated = DateTime.Now,
                    CheckIn = createBookingViewModel.CheckIn,
                    CheckOut = createBookingViewModel.CheckOut,
                    Completed = false,
                    Paid = createBookingViewModel.Paid,
                    Guests = createBookingViewModel.Guests,
                    CustomerName = createBookingViewModel.CustomerName,
                    CustomerPhone = createBookingViewModel.CustomerPhone
                };

                await dataContext.Bookings.AddAsync(booking);
                dataContext.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }

        }

    }
}