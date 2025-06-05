using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using Mission.Services.IServices;

namespace Mission.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly DbContext _context;

        public UserService(IUserRepository userRepository, DbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<string> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<UserResponseModel> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<UserResponseModel?> UpdateUser(UserResponseModel updatedUser)
        {
            // Find the existing user record.
            var existingUser = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == updatedUser.Id);

            if (existingUser == null)
                return null;

            // Update properties - adjust based on your UserResponseModel properties.
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.EmailAddress = updatedUser.EmailAddress;
            // ... update any other properties as needed.

            await _context.SaveChangesAsync();

            // Map the updated User entity to a UserResponseModel.
            var responseModel = new UserResponseModel
            {
                Id = existingUser.Id,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                PhoneNumber = existingUser.PhoneNumber,
                EmailAddress = existingUser.EmailAddress,
                UserType = existingUser.UserType
                
            };

            return responseModel;
        }
    }
}
