using Fram_4._5._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fram_4._5._2.Repository
{
    public interface IUserRepository 
    {
        Task<List<ApplicationUser>> GetUserAsync();
    }
}