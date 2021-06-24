using System;
using System.Collections.Generic;
using GR = Global.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Data;
using Client.Mappers;
using Client.Repositories;

namespace Client.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly GR.IAuthRepository _authRepository;

        public AuthService(GR.IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public User Login(string email, string password)
        {
            return _authRepository.Login(email, password)?.ToClient();
        }

        public bool Register(User user)
        {
            return _authRepository.Register(user.ToGlobal());
        }

        public bool EmailExists(string email)
        {
            return _authRepository.EmailExists(email);
        }
    }
}
