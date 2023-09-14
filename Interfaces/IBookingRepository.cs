using DtoModel;

namespace Interfaces {

    public interface IBookingRepository {

        public Task<bool> CreateBooking(CreateBookingViewModel createBookingViewModel);

        public Task<bool> UpdatePaidStatus(UpdateUserPaidStatusViewModel updateUserPaidStatusViewModel);

        public Task<bool> DeleteAllBookingsOfUser(string UserId);

        public Task<bool> DeleteBooking(string BookingId);
    }
}