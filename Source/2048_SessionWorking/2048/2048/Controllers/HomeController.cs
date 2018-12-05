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
        public int result = 0;
        
        public ActionResult Index()
        {
            
            if (HttpContext.Session["Matrix"] == null) 
            {
                matrix = Logic.InitializeMatrix();
                HttpContext.Session["Matrix"] = matrix;
                HttpContext.Session["Score"] = 0;
                HttpContext.Session["Result"] = 0;
            }
            else
            {
                matrix = (int[,])HttpContext.Session["Matrix"];
                score = (int)HttpContext.Session["Score"];
                result = (int)HttpContext.Session["Result"];
            }


            GameVM game = new GameVM();
            game.Matrix = matrix;
            game.Score = score;
            game.hasBeenWon = false;
            game.isGameOver = false;
            game.Result = result;
            if (result > 2048 || result == 2048)
            {
                game.hasBeenWon = true;
            }
            else if (Logic.CheckEmptySlots(matrix)!=true&&Logic.CheckGameOver()==true)
            {
                game.isGameOver = true;
            }

            return View(game);
        }
        [HttpPost]
        public ActionResult Index(string submit)
        {
            matrix = (int[,])HttpContext.Session["Matrix"];
            score = (int)HttpContext.Session["Score"];
            result = (int)HttpContext.Session["Result"];
            switch (submit)
            {
                case "New":
                    matrix = Logic.InitializeMatrix();
                    score = 0;
                    break;
                case "Up":
                    score+=Logic.MoveUp(matrix);
                    result = Logic.maxResult;
                    break;
                case "Down":
                    score+=Logic.MoveDown(matrix);
                    result = Logic.maxResult;
                    break;
                case "Left":
                    score+=Logic.MoveLeft(matrix);
                    result = Logic.maxResult;
                    break;
                case "Right":
                    score+=Logic.MoveRight(matrix);
                    result = Logic.maxResult;
                    break;
            }

            HttpContext.Session["Matrix"] = matrix;
            HttpContext.Session["Score"] = score;
            HttpContext.Session["Result"] = result;
            return RedirectToAction("Index");
        }
    }
}