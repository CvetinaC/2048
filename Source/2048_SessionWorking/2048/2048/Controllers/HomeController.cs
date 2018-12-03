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
        public static int score = 0;

        public ActionResult Index()
        {
            if (HttpContext.Session["Matrix"] == null) 
            {
                matrix = Logic.InitializeMatrix();
                HttpContext.Session["Matrix"] = matrix;
            }
            else
            {
                matrix = (int[,])HttpContext.Session["Matrix"];
            }

            GameVM game = new GameVM(); //
            game.Matrix = matrix;

            return View(game);
        }
        [HttpPost]
        public ActionResult Index(string submit)
        {
            matrix = (int[,])HttpContext.Session["Matrix"];
            switch (submit)
            {
                case "New":
                    matrix = Logic.InitializeMatrix();
                    break;
                case "Up":
                    Logic.MoveUp(matrix);
                    score = Logic.score;
                    break;
                case "Down":
                    Logic.MoveDown(matrix);
                    score = Logic.score;
                    break;
                case "Left":
                    Logic.MoveLeft(matrix);
                    score = Logic.score;
                    break;
                case "Right":
                    Logic.MoveRight(matrix);
                    score = Logic.score;
                    break;
            }
            if (score > 2048 || score == 2048)
            {
                ViewBag.Message = "You Won !!!";
            }
            HttpContext.Session["Matrix"] = matrix;
            return RedirectToAction("Index");
        }
    }
}