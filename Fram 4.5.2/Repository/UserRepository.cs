using Fram_4._5._2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fram_4._5._2.Repository
{
    public class UserRepository : IUserRepository
    {

        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<List<ApplicationUser>> GetUserAsync()
        {
            var answer = await _context.Users.Include(p=>p.RegionalCenter).ToListAsync();

            return answer;

        }


    }
}
