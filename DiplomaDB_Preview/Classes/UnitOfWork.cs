using DiplomaDB_Preview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDB_Preview.Classes
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IEventRepository Events { get; }
      //  IRepository<CommentRepository> Comments { get; }
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public IUserRepository  _users;
        public IEventRepository _events;
       // public CommentRepository _comments;


        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IUserRepository Users
        {
            get
            {
                return _users ?? (_users = new UserRepository(_context));
            }
        }


        public IEventRepository Events
        {
            get
            {
                return _events ?? (_events = new EventRepository(_context));
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }



}
