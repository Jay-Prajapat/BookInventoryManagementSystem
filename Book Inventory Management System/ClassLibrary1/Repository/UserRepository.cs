using ClassLibrary1.DAL;
using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using ClassLibrary1.ViewModels;

namespace ClassLibrary1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookInventoryEntity _dbContext;
        public UserRepository()
        {
            _dbContext = BookDataAccess.GetInstance();
        }
        public async Task AddUser(Users user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsUserExist(Users user)
        {
            return await _dbContext.Users.AnyAsync(u => u.UserName.Equals(user.UserName) || u.Email.Equals(user.Email));
        }

        public async Task<bool> IsValidUser(LoginViewModel user)
        {
            return await _dbContext.Users.AnyAsync(u => u.UserName == user.UserName && u.Password == user.Password);
        }
    }
}
