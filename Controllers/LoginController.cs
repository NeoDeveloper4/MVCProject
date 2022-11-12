using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult LoginUser()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginUser(LoginModel lm)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_loginUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email",lm.Email);
            cmd.Parameters.AddWithValue("@Password",lm.Password);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                Session["Email"] = lm.Email.ToString();
                return RedirectToAction("UserListing");
            }
            else
            {
                ViewData["Message"] = "Wrong Email and Password";
            }
            con.Close();
            return View();
        }
        public ActionResult UserListing()
        {
            return View();
        }

    }
}