using Microsoft.EntityFrameworkCore;
using Share;
using Tickets.Data;
using Tickets.Domains;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Services
{
    public class UserService : IUserService
    {
        readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> DeleteUserAsync(int userId)
        {
            var userDetails = await _dbContext.Users.FindAsync(userId);
            if (userDetails == null)
            {
                //data not found
                return 0;
            }

            _dbContext.Users.Remove(userDetails);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
          
            var users = await _dbContext.Users.AsNoTracking().ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
