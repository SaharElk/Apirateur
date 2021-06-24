using System;
using System.Collections.Generic;
using GS = Global.Services;
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
        private readonly GS.AuthService _authService;

        public AuthService(GS.AuthService authService)
        {
            _authService = authService;
        }

        public User Login(string email, string password)
        {
            return _authService.Login(email, password)?.ToClient();
        }

        public bool Register(User user)
        {
            return _authService.Register(user.ToGlobal());
        }
    }
}
