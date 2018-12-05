using _2048.BisnessLogic;
using _2048.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace _2048.Controllers.API
{
    public class GameController : ApiController
    {
        int score = 0;
        [HttpGet]
        [ResponseType(typeof(GameVM))]
        public IHttpActionResult Index(int id = 0)
        {
            GameVM game = new GameVM();

            game.Matrix = (int[,])HttpContext.Current.Session["Matrix"];
            game.Score= (int)HttpContext.Current.Session["Score"];
            game.Result = (int)HttpContext.Current.Session["Result"];
            
            switch (id)
            {
                case 1:
                    game.Score += Logic.MoveUp(game.Matrix);
                    game.Result = Logic.maxResult;
                    break;
                case 2:
                    game.Score += Logic.MoveRight(game.Matrix);
                    game.Result = Logic.maxResult;
                    break;
                case 3:
                    game.Score += Logic.MoveDown(game.Matrix);
                    game.Result = Logic.maxResult;
                    break;
                case 4:
                    game.Score += Logic.MoveLeft(game.Matrix);
                    game.Result = Logic.maxResult;
                    break;
                default:
                    break;
            }

            HomeController home = new HomeController();
            home.IsWon(game);
            
            HttpContext.Current.Session["Matrix"] = game.Matrix;
            HttpContext.Current.Session["Score"] = game.Score;
            return Ok(game);
        }


        

    }
}
