using DtoModel;

namespace Interfaces {

    public interface IRoomRepository {

        public Task<bool> CreateRoom(CreateRoomViewModel createRoomViewModel);

        public Task<bool> UpdatePrice(UpdateRoomPriceViewModel updateRoomPriceViewModel);

        public Task<bool> UpdateAvailability(UpdateRoomAvailabityViewModel updateRoomAvailabityViewModel);

        public Task<bool> DeleteRoom(string RoomId);
    }
}