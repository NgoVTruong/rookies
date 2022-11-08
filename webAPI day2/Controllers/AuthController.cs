using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webAPI_day2.Models;
using webAPI_day2.DTOs.Responses;
using webAPI_day2.DTOs.Requests;

namespace webAPI_day2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<UserModel> _users = new List<UserModel>
        {
            new UserModel {
                Username = "admin",
                Password = "admin"
            },
        };

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            // check username and password if they are valid
            var result = from item in _users
                         where item.Username == loginRequest.Username
                         where item.Password == loginRequest.Password
                         select item;

            if (result.Count() == 0) return Unauthorized();

            // generate token if credential is valid


            return Ok(new LoginSuccessResponse("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYzNjNiMTM1ZWIyYzE5MWZhMmI5NjQwMCIsIm5hbWUiOiJOZ8O0IE1pbmggU2FvIiwidXNlcm5hbWUiOiJzYW9ubSIsImVtYWlsIjoic2Fvbm1AZ21haWwuY29tIiwicm9sZSI6InVzZXIiLCJpYXQiOjE2Njc4MTgwMzYsImV4cCI6MTY2NzkwNDQzNn0.pf6aCnAi04mJThwncJl-fj9P6IwDjZIFkdxWeW_KXoo"));
        }
    }
}