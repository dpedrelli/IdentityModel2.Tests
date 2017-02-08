// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "User Role")]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        //[HttpGet]
        //[Authorize(Roles = "User Role")]
        //public IActionResult GetWithRole(string id)
        //{
        //    return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        //}
    }
}