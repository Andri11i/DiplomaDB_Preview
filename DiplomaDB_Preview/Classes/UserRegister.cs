using DiplomaDB_Preview.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDB_Preview.Classes
{
    public class UserRegister
    {
        UnitOfWork _unitOfWork;
        IRepository<User> _userRepostitory;
        public UserRegister(UnitOfWork unitOfWork, IRepository<User> userRepostitory)
        {
            _userRepostitory = userRepostitory;
            _unitOfWork = unitOfWork;
        }
        
        void PrintMessage(string message) => Console.WriteLine($"[UserReg]:{message}");
        bool ValidateUser(User user) => (user != null && user.City != null && user.LastName != null);

        public bool AddUser(User user)
        {
            try
            {
                bool ValidUser = ValidateUser(user);
                if (!ValidUser)
                    throw new Exception("User is not vallid for regestration");

                _userRepostitory.Add(user);
                _unitOfWork.Commit();

                return true;
            }
            catch (Exception E)
            {
                PrintMessage(E.Message);
                return false;
            }
        }

        public User GetUser(int id) {
            try
            {
                User FoundUser = _userRepostitory.GetById(id);

                if (FoundUser == null)
                    throw new Exception("User Not Found");
                return FoundUser;
            }
            catch (Exception E)
            {
                PrintMessage(E.Message);
                return null;
            }
        }


        public bool DeleteUserById(int id) 
        {
            try
            {
                User FoundUser = GetUser(id);

                if (FoundUser == null)
                    throw new Exception("User Not Found");

                _userRepostitory.Delete(id);
                _unitOfWork.Commit();

                return true;
            }
            catch (Exception E)
            {
                PrintMessage(E.Message);
                return false;
            }
        }


    }
}
