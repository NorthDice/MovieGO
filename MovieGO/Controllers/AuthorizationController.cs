﻿using Microsoft.AspNetCore.Mvc;
using MovieGO.Models;
using MovieGO.Models.UserData;
using MovieGO.Models.Users.User;


namespace MovieGO.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserServices _userService;

        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            await _userService.Register(request.UserName, request.Email, request.Password);
            return View();
        }
    }
}