using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2048.BisnessLogic;
using _2048.Models;

namespace _2048.Controllers
{
    public class HomeController : Controller
    {
        public int[,] matrix = new int[4, 4];
        public int score = 0;

        public ActionResult Index()
        {
            if (HttpContext.Session["Matrix"] == null) 
            {
                matrix = Logic.InitializeMatrix();
                HttpContext.Session["Matrix"] = matrix;
                HttpContext.Session["Score"] = 0;
            }
            else
            {
                matrix = (int[,])HttpContext.Session["Matrix"];
                score = (int)HttpContext.Session["Score"];
            }


            GameVM game = new GameVM();
            game.Matrix = matrix;
            game.Score = score;
            if (score > 2048 || score == 2048)
            {
                ViewBag.Message = "You Won !!!";
            }
            return View(game);
        }
        [HttpPost]
        public ActionResult Index(string submit)
        {
            matrix = (int[,])HttpContext.Session["Matrix"];
            score = (int)HttpContext.Session["Score"];
            switch (submit)
            {
                case "New":
                    matrix = Logic.InitializeMatrix();
                    score = 0;
                    break;
                case "Up":
                    score+=Logic.MoveUp(matrix);
                    break;
                case "Down":
                    score+=Logic.MoveDown(matrix);
                    break;
                case "Left":
                    score+=Logic.MoveLeft(matrix);
                    break;
                case "Right":
                    score+=Logic.MoveRight(matrix);
                    break;
            }

            HttpContext.Session["Matrix"] = matrix;
            HttpContext.Session["Score"] = score;
            return RedirectToAction("Index");
        }
    }
}