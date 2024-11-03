using Data_Access_Layer.Database_Connection;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Access_Layer.Service
{
    
    public class Queries
    {
        private readonly AppDbContext _dbContext;
        public Queries(AppDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public async Task<Login> GetLogin(string userName, string password)
        {
            
            var login = await _dbContext.Login.FirstOrDefaultAsync(x => x.Username == userName && x.Password == password);
            
            if (login == null)
            {
                throw new Exception("User Not Found");
            }

            return login;
        }
    }
}
