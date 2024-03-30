using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenS_Fontend_Test.App_Start;
using ZenS_Fontend_Test.Models;
using ZenS_Fontend_Test.Service;

namespace ZenS_Fontend_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Joke joke;

            string userInfor = CookieHelper.Get("userInfor");

            if (String.IsNullOrEmpty(userInfor))
            {
                joke = JokeService.GetNextJoke(0);
            }
            else
            {
                joke = JokeService.GetNextJoke(int.Parse(userInfor));
            }
            
            return View(joke);
        }

        [HttpPost]
        public JsonResult Like(int jokeId)
        {
            CookieHelper.Create("userInfor", jokeId.ToString(), DateTime.Now.AddDays(1));

            try
            {
                JokeService.Vote(jokeId, 1, true);

                Joke joke = JokeService.GetNextJoke(jokeId);

                return Json(new { success = true, data = joke });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Dislike(int jokeId)
        {
            CookieHelper.Create("userInfor", jokeId.ToString(), DateTime.Now.AddDays(1));

            try
            {
                JokeService.Vote(jokeId, 1, false);

                Joke joke = JokeService.GetNextJoke(jokeId);
                
                return Json(new { success = true, data = joke });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}