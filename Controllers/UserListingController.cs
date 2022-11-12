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
    public class UserListingController : Controller
    {
        
        // GET: UserListing
        public ActionResult Index()
        {
            return View();
        }

        public Action UserListing()
        {
            try
            {
                using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    var draw = Request.Form.GetValues("draw").FirstOrDefault();
                    var start = Request.Form.GetValues("start").FirstOrDefault();
                    var length = Request.Form.GetValues("length").FirstOrDefault();
                    var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                    var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                    var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                    //Paging Size (10,20,50,100)    
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;
                    int skip = start != null ? Convert.ToInt32(start) : 0;
                    int recordsTotal = 0;

                    // Getting all Customer data   

                    SqlDataAdapter da = new SqlDataAdapter("sp_getUser", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //total number of rows count
                    recordsTotal = dt.Rows.Count;

                    //Returning Json Data  
                    return Json(new { draw = draw, 
                                      recordsFiltered = recordsTotal, 
                                      recordsTotal = recordsTotal,
                                      data = abc
                                    });  
                }  
                }
            catch(Exception)
            {
                throw;
            }
        }
    }
            }
}