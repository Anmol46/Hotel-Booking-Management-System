using Data;
using DtoModel;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAO
{

    public class RoomRepository : IRoomRepository
    {

        private readonly DataContext dataContext;

        private readonly ILogger logger;

        public RoomRepository(ILoggerFactory loggerFactory, DataContext dataContext)
        {
            this.dataContext = dataContext;
            logger = loggerFactory.CreateLogger<RoomRepository>();
        }

        public async Task<bool> CreateRoom(CreateRoomViewModel createRoomViewModel)
        {
            try
            {

                Room room = new Room
                {
                    RoomId = new Guid().ToString(),
                    RoomType = createRoomViewModel.RoomType,
                    Available = createRoomViewModel.Available,
                    Price = createRoomViewModel.Price,
                    MaxGuests = createRoomViewModel.MaxGuests,
                };

                await dataContext.Rooms.AddAsync(room);
                dataContext.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }

        }

        public async Task<bool> UpdatePrice(UpdateRoomPriceViewModel updateRoomPriceViewModel)
        {
            try
            {
                var room = await dataContext.Rooms.Where(x => x.RoomId == updateRoomPriceViewModel.RoomId).FirstOrDefaultAsync();
                room.UpdatePrice(updateRoomPriceViewModel.NewPrice);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> UpdateAvailability(UpdateRoomAvailabityViewModel updateRoomAvailabityViewModel)
        {
            try
            {
                var room = await dataContext.Rooms.Where(x => x.RoomId == updateRoomAvailabityViewModel.RoomId).FirstOrDefaultAsync();
                room.UpdateAvailability(updateRoomAvailabityViewModel.Availability);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> DeleteRoom(string RoomId)
        {
            try
            {

                var room = await dataContext.Rooms.Where(x => x.RoomId == RoomId).FirstOrDefaultAsync();

                if (room != null)
                {
                    dataContext.Rooms.Remove(room);
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