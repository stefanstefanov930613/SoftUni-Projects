﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TwitterForum.Data;
using TwitterForum.Models;

namespace TwitterForum.Controllers
{
    [Authorize]
    public class TweetsController : Controller
    {
        ApplicationDbContext db;
 
        public TweetsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
        {
              
            return View();
        }

        public IActionResult SaveToDatabase(string text)
        {
            var tweet = new Tweet();
            tweet.Text = text;
            tweet.CreatedOn = DateTime.Now;
            tweet.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            db.Tweets.Add(tweet);
            db.SaveChanges();

            return Redirect("/");
        }
    }
}