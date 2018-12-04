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
        [HttpGet]
        [ResponseType(typeof(int[,]))]
        public IHttpActionResult Index(int id = 0)
        {
            int[,] matrix = new int[4, 4];
            int score = 0;
            if (HttpContext.Current.Session["Matrix"] == null)
            {
                matrix = Logic.InitializeMatrix();
                HttpContext.Current.Session["Matrix"] = matrix;
                HttpContext.Current.Session["Score"] = 0;
            }
            else
            {
                matrix = (int[,])HttpContext.Current.Session["Matrix"];
                score= (int)HttpContext.Current.Session["Score"];
            }

            matrix = (int[,])HttpContext.Current.Session["Matrix"];
            score= (int)HttpContext.Current.Session["Score"];


            //matrix[0, 0] = id;
            switch (id)
            {
                case 1:
                    Logic.MoveUp(matrix);
                    score += Logic.score;
                    break;
                case 2:
                    Logic.MoveRight(matrix);
                    score += Logic.score;
                    break;
                case 3:
                    Logic.MoveDown(matrix);
                    score += Logic.score;
                    break;
                case 4:
                    Logic.MoveLeft(matrix);
                    score += Logic.score;
                    break;
                default:
                    break;
            }

            HttpContext.Current.Session["Matrix"] = matrix;
            HttpContext.Current.Session["Score"] = score;
            return Ok(matrix);
        }
    }
}
