using Microsoft.EntityFrameworkCore;
using PatientInfoPortal.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientInfoPortal.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
