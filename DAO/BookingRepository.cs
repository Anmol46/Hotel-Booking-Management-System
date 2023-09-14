using Data;
using DtoModel;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAO
{

    public class BookingRepository : IBookingRepository
    {

        private readonly DataContext dataContext;

        private readonly ILogger logger;

        private readonly UserManager<AppIdentityUser> userManager;


        public BookingRepository(DataContext dataContext, ILoggerFactory loggerFactory, UserManager<AppIdentityUser> userManager)
        {
            this.dataContext = dataContext;
            this.userManager = userManager;
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


        public async Task<bool> UpdatePaidStatus(UpdateUserPaidStatusViewModel updateUserPaidStatusViewModel)
        {
            try
            {
                var user = await userManager.FindByIdAsync(updateUserPaidStatusViewModel.UserId);

                if (user != null)
                {
                    var booking = await dataContext.Bookings.Where(x => x.UserId == updateUserPaidStatusViewModel.UserId).FirstOrDefaultAsync();

                    if (booking != null)
                    {
                        booking.UpdatePaidStatus(updateUserPaidStatusViewModel.Paid);
                        dataContext.Bookings.Update(booking);
                        await dataContext.SaveChangesAsync();
                        return true;
                    }

                    return false;
                }

                return false;
            }

            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }
        }


        public async Task<bool> UpdateCheckOut(UpdateCheckOutViewModel updateCheckOutViewModel)
        {

            try
            {
                var user = await dataContext.users.Where(x => x.Id == updateCheckOutViewModel.UserId).FirstOrDefaultAsync();

                if (user != null)
                {

                    var booking = await dataContext.Bookings.Where(x => x.UserId == updateCheckOutViewModel.UserId).FirstOrDefaultAsync();

                    if (booking != null)
                    {
                        booking.UpdateCheckOut(updateCheckOutViewModel.CheckOut);
                        return true;
                    }

                    return false;
                }

                return false;
            }

            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> DeleteBooking(string BookingId)
        {
            try
            {
                var booking = await dataContext.Bookings.Where(x => x.Id == BookingId).FirstOrDefaultAsync();

                if (booking != null)
                {
                    dataContext.Remove(booking);
                    dataContext.SaveChanges();
                    return true;
                }

                return false;
            }

            catch(Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> DeleteAllBookingsOfUser(string UserId)
        {
            try
            {
                var user = await userManager.FindByIdAsync(UserId);

                if (user != null)
                {
                    var bookings = await dataContext.Bookings.Select(x => x.UserId == UserId).ToListAsync();
                    dataContext.RemoveRange(bookings);
                    dataContext.SaveChanges();
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

    }

}
