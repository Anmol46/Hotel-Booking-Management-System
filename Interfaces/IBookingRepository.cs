using DtoModel;

namespace Interfaces {

    public interface IBookingRepository {

        public Task<bool> CreateBooking(CreateBookingViewModel createBookingViewModel);
    }
}