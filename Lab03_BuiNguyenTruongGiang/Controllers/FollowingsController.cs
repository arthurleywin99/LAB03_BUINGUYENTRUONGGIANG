﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using Lab03_BuiNguyenTruongGiang.DTOs;
using Lab03_BuiNguyenTruongGiang.Models;
using Microsoft.AspNet.Identity;

namespace Lab03_BuiNguyenTruongGiang.Controllers
{
    public class FollowingsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();  
                if (context.Followings.Any(p => p.FollowerId == userId && p.FollowerId == followingDto.FolloweeId))
                {
                    return BadRequest("Following already exists!");
                }
                else
                {
                    var following = new Following
                    {
                        FollowerId = userId,
                        FolloweeId = followingDto.FolloweeId
                    };
                    context.Followings.Add(following);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
