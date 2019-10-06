using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSt.Context;
using MSt.Data.Models;
using MusicStore.Services;

namespace MusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<string> Login([FromBody] LoginModel obj)
        {
            return await _authService.LoginAsync(obj);
        }

    }
}
