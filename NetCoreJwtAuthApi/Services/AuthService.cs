using NetCoreJwtAuthApi.Data.Repositories;
using NetCoreJwtAuthApi.DTOs;
using NetCoreJwtAuthApi.Helpers;
using NetCoreJwtAuthApi.Models;

namespace NetCoreJwtAuthApi.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public AuthService(
            IUserRepository userRepository,
            JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public string Login(LoginDto dto)
        {
            var user = _userRepository.GetByUsername(dto.Username);

            if (user == null)
                throw new UnauthorizedAccessException("User tidak ditemukan");

            // verify hash
            if (!PasswordHasher.Verify(dto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Password salah");

            return _jwtService.GenerateToken(user);
        }
    }
}
