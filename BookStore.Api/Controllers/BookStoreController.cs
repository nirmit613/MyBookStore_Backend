﻿using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {

                User user = _repository.Login(model);
                if (user == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "User Not Found");

                //return Ok(user);
                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }

        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                User user = _repository.Register(model);
                if (user == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Bad Request");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }

        }
    }
}
