using DiplomaDB_Preview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDB_Preview.Classes
{

    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAdminsAsync();
    }


    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAdminsAsync()
        {
            return await _dbSet.Where(u => u.IsAdmin).ToListAsync();
        }
    }

    public class AsyncRepository<T> : Repository<T> where T : class
    {
        public AsyncRepository(DbContext context) : base(context) { }

        public async Task AddAssync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
    }

    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>> GetEventsByCategoryAsync(int categoryId);
    }

    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Event>> GetEventsByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(e => e.CategoryId == categoryId).ToListAsync();
        }
    }

    //public class CommentRepository : Repository<Comment>
    //{
    //    public CommentRepository(DbContext context) : base(context) { }

    //    public async Task<IEnumerable<Comment>> GetCommentsByEventAsync(int eventId)
    //    {
    //        return await _dbSet.Where(c => c.EventId == eventId).ToListAsync();
    //    }
    //}


}
