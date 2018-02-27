using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JqueryAjaxDemo.Models;
using System.Web.Mvc;
using System.Configuration;
using System.Data;

namespace JqueryAjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        
        public ActionResult Index()
        {
            return View();
        }
        // GET: AddEmployee
        public ActionResult AddEmployee()
        {

            return View();
        }
        //Post method to add details
        [HttpPost]
        public ActionResult AddEmployee(Employee obj)

        {
            AddDetails(obj);

            return View();
        }

        
        //To add Records into database
        private void AddDetails(Employee obj)
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            SqlConnection con = new SqlConnection(constr);

            SqlCommand com = new SqlCommand("AddEmp", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
    }
}