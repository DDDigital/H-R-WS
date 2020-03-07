using H_R_WS.Data;
using H_R_WS.Models;
using H_R_WS.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace H_R_WS.Services
{
    public class GenericHotelService<TEntity> : IGenericHotelService<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> DbSet;

        //Контект
        public GenericHotelService(ApplicationDbContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }
        //Отримання всіх пунктів
        public async Task<IEnumerable<TEntity>> GetAllItemsAsync()
        {
            return await DbSet.ToArrayAsync();
        }
        //Отримання речі за ID 
        public async Task<TEntity> GetItemByIdAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await DbSet.FindAsync(id);
        }
        //Пошук речі
        public async Task<IEnumerable<TEntity>> SearchFor(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).ToArrayAsync();
        }
        //Створення речі
        public async Task CreateItemAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
        //Редагування
        public async Task EditItemAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        //Видалення
        public async Task DeleteItemAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public RoomsAdminIndexViewModel GetAllRoomsAndRoomTypes()
        {

            var rooms = _context.Rooms.ToList();
            var roomtypes = _context.RoomTypes.ToList();

            var RoomsAdminIndeViewModel = new RoomsAdminIndexViewModel
            {
                Rooms = rooms,
                RoomTypes = roomtypes
            };
            return RoomsAdminIndeViewModel;
        }
        public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync()
        {
            return await _context.RoomTypes.ToArrayAsync();
        }
        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.Include(x => x.RoomType);
        }
        public IEnumerable<Room> GetAllRoomsWithFeature(string featureID)
        {
            var RoomFeatures = _context.RoomFeatureRelationships.Include(x => x.Room).Include(x => x.Room.RoomType).Where(x => x.FeatureID == featureID);
            var SelectedRooms = new List<Room>();
            foreach (var roomFeature in RoomFeatures)
            {
                SelectedRooms.Add(roomFeature.Room);
            }
            return SelectedRooms;
        }
        public List<SelectedRoomFeatureViewModel> PopulateSelectedFeaturesForRoom(Room room)
        {
            var viewModel = new List<SelectedRoomFeatureViewModel>();
            var allFeatures = _context.Features;
            if (room.ID == "" || room.ID == null)
            {
                foreach (var feature in allFeatures)
                {
                    viewModel.Add(new SelectedRoomFeatureViewModel
                    {
                        FeatureID = feature.ID,
                        Feature = feature,
                        Selected = false
                    });
                }
            }
            else
            {
                var roomFeatures = _context.RoomFeatureRelationships.Where(x => x.RoomID == room.ID);
                var roomFeatureIDs = new HashSet<string>(roomFeatures.Select(x => x.FeatureID));


                foreach (var feature in allFeatures)
                {
                    viewModel.Add(new SelectedRoomFeatureViewModel
                    {
                        FeatureID = feature.ID,
                        Feature = feature,
                        Selected = roomFeatureIDs.Contains(feature.ID)
                    });
                }
            }

            return viewModel;
        }
        public void UpdateRoomFeaturesList(Room room, string[] SelectedFeatureIDs)
        {
            var PreviouslySelectedFeatures = _context.RoomFeatureRelationships.Where(x => x.RoomID == room.ID);
            _context.RoomFeatureRelationships.RemoveRange(PreviouslySelectedFeatures);
            _context.SaveChanges();


            if (SelectedFeatureIDs != null)
            {
                foreach (var featureID in SelectedFeatureIDs)
                {
                    var AllFeatureIDs = new HashSet<string>(_context.Features.Select(x => x.ID));
                    if (AllFeatureIDs.Contains(featureID))
                    {
                        _context.RoomFeatureRelationships.Add(new RoomFeature
                        {
                            FeatureID = featureID,
                            RoomID = room.ID
                        });
                    }
                }
                _context.SaveChanges();
            }
        }
    }
}
