using Share;

namespace Services
{
    public interface IUserService
    {
      Task<List<UserDto>> GetUsersAsync();
        Task<int> DeleteUserAsync(int userId);
    }
}
