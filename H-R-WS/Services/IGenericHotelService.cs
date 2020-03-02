using H_R_WS.Models;
using H_R_WS.ViewModels;
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

        Task<TEntity> GetItemByIdAsync(Guid? id);

        Task<IEnumerable<TEntity>> SearchFor(Expression<Func<TEntity, bool>> expression);

        Task CreateItemAsync(TEntity entity);

        Task EditItemAsync(TEntity entity);

        Task DeleteItemAsync(TEntity entity);
        RoomsAdminIndexViewModel GetAllRoomsAndRoomTypes();
        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();
    }
}
