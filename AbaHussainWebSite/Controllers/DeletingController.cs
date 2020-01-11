using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbaHussainWebSite.Controllers
{
    public class DeletingController : Controller
    {
        //SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=maindb;Persist Security Info=True;");

        SqlConnection con = new SqlConnection(@"Data Source=198.38.83.200;User Id=hamdymor_abahussain;Password=abahussain@123;Initial catalog=hamdymor_abahussainweb;Persist Security Info=True;");
        SqlCommand com;
        // GET: Deleting
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSocial(int id)
        {
            
                con.Open();
          
                com = new SqlCommand("delete from SocialMedia where SocialID=" + id, con);
                com.ExecuteNonQuery();
                con.Close();
                return Json(true, JsonRequestBehavior.AllowGet);
            

        }
        [HttpPost]
        public void Deletesubcat(int id)
        {try {
                con.Open();
                com = new SqlCommand("delete from Products where FKSubID=" + id, con);
                com.ExecuteNonQuery();
                com = new SqlCommand("delete from SubCategory where SubCategoryID="+id, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch { }

        }

        [HttpPost]
        public void Deleteserv(int id)
        {
           // try
           // {
                con.Open();
                //com = new SqlCommand("delete from Products join SubCategory on FKSubID=SubCategoryID where SubCategory.FKServID="+id, con);
                //com.ExecuteNonQuery();
                //com = new SqlCommand("delete from SubCategory where FKServID=" + id, con);
                //com.ExecuteNonQuery();
                com = new SqlCommand("delete from Services where ServicesID=" + id, con);
                com.ExecuteNonQuery();
                con.Close();
            // RedirectToAction("Services", "Dash");
           // }
            //catch { }

        }

        [HttpPost]
        public void DeleteimgNew(int id)
        {
            try
            {
                con.Open();
                com = new SqlCommand("delete from imgNew where NewID=" + id, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch { }

        }

        [HttpPost]
        public void Deleteproducts(int id)
        {
            try
            {
                con.Open();

                com = new SqlCommand("delete from Products where ProductID=" + id, con);
                com.ExecuteNonQuery();
                con.Close();
              
            }
            catch { }

        }

        [HttpPost]
        public void Deletebranch(int id)
        {
            try
            {
                con.Open();
                com = new SqlCommand("delete from BranchDetail where FKBranchID=" + id, con);
                com.ExecuteNonQuery();
                com = new SqlCommand("delete from Branches where BID=" + id, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch { }

        }
        [HttpPost]
        public void Deletebranchdetails(int id)
        {
            try
            {
                con.Open();
                com = new SqlCommand("delete from BranchDetail where DetailsBranch=" + id, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch { }

        }

    }
}