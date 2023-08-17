using ClassLibrary1.Models;
using ClassLibrary1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace ClassLibrary1.Repository
{
    public interface IUserRepository
    {
        Task AddUser(Users user);
        Task<bool> IsUserExist(Users user);
             
        Task<bool> IsValidUser(LoginViewModel user);
    }
}
