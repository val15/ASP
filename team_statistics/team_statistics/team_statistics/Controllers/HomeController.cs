using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Sql;


namespace team_statistics.Controllers
{

   public class HomeController : Controller
    {
       string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
       List<SelectListItem> team = new List<SelectListItem>();
       List<SelectListItem> player = new List<SelectListItem>();
       List<SelectListItem> tournament = new List<SelectListItem>();
       public ActionResult Index()
       {
          ViewBag.var1 = GetOptions();
           ViewBag.var2 = team;
           ViewBag.var3 = player;
           return View();
       }
          
       
         private SelectList GetOptions()
          {
            
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("SELECT Id, Tournament FROM TounamentType", conn);

                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {

                        tournament.Add(new SelectListItem { Text = myReader["Tournament"].ToString(), Value = myReader["Id"].ToString() });
                    }
                     

                }
                catch (Exception e)
                {
                    string msg = e.Message;
                }
                finally
                {

                    conn.Close();
                }
           
                return new SelectList(tournament, "Value", "Text", "id");
               
            }
        }

   
     
        
        
        public JsonResult Team(string name)
        {
            
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select Team,Id from Team where Tournament ='" + name + "' ", conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {

                    team.Add(new SelectListItem { Text = myReader["Team"].ToString(), Value = myReader["Id"].ToString() });
                }
            }
            return Json(team, JsonRequestBehavior.AllowGet);
        
          }

        public JsonResult Player(string name)
        {

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select Player,Id from Player where Team ='" + name + "' ", conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {

                    player.Add(new SelectListItem { Text = myReader["Player"].ToString(), Value = myReader["Id"].ToString() });
                }
            }
            return Json(player, JsonRequestBehavior.AllowGet);

        }
        }

       
    }

