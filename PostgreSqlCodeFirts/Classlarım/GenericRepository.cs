using PostgreSqlCodeFirts.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlCodeFirts.Classlarım
{
    public class GenericRepository<T>: IDisposable where T: class 
    {
        private readonly Context _db;
        public GenericRepository() { _db = new Context(); }

        public void Dispose() { _db.Dispose(); }

        // Tüm verileri getirme, includes ile navigation property ekleyebilirsin
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db.Set<T>();

            // Navigation property ekleme
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }

        // Tek bir veri çekme, includes ile navigation property ekleyebilirsin
        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        // Yeni veri ekleme
        public async Task AddAsync(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
        }

        // Mevcut veriyi güncelleme

        public async Task UpdateAsync(T entity)
        {
            // DbContext entity'i takip etmiyorsa Attach et
            var entry = _db.Entry(entity);
            if (entry.State == EntityState.Detached)
                _db.Set<T>().Attach(entity);

            entry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        // Silme işlemi
        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await _db.Set<T>().FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
