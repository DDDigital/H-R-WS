using H_R_WS.Data;
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
        public async Task<TEntity> GetItemByIdAsync(Guid? id)
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
    }
}
