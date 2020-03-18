using H_R_WS.Models;
using H_R_WS.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace H_R_WS.Services
{
    public interface IGenericHotelService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllItemsAsync();

        Task<TEntity> GetItemByIdAsync(string id);

        Task<IEnumerable<TEntity>> SearchFor(Expression<Func<TEntity, bool>> expression);

        Task CreateItemAsync(TEntity entity);

        Task EditItemAsync(TEntity entity);

        Task DeleteItemAsync(TEntity entity);
        RoomsAdminIndexViewModel GetAllRoomsAndRoomTypes();
        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();
        IEnumerable<Room> GetAllRoomsWithFeature(string feature);
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Booking> GetAllBookings();
        List<SelectedRoomFeatureViewModel> PopulateSelectedFeaturesForRoom(Room room);
        void UpdateRoomFeaturesList(Room room, string[] SelectedFeatureIDs);
        Task<AddImagesViewModel> AddImagesAsync(List<IFormFile> files);
        Task RemoveImageAsync(Image image);
        void UpdateRoomImagesList(Room room, string[] imageIDs);
        Task<RoomFeaturesAndImagesViewModel> GetRoomFeaturesAndImagesAsync(Room room);
    }
}
