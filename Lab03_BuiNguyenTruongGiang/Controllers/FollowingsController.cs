using System;
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
    [RoutePrefix("api/followings")]
    public class FollowingsController : ApiController
    {
        [HttpPost]
        [Route("follow")]
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

        [HttpPost]
        [Route("unfollow")]
        public IHttpActionResult Unfollow(FollowingDto followingDto)
        {                       
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                Following follow = context.Followings.FirstOrDefault(p => p.FollowerId == userId && p.FolloweeId == followingDto.FolloweeId);
                if (follow == null)
                {
                    return BadRequest("This user doesnot exist!");
                }
                else
                {
                    context.Followings.Remove(follow);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
