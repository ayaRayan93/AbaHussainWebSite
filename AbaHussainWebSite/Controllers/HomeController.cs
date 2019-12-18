using AbaHussainWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbaHussainWebSite.Controllers
{
    public class HomeController : Controller
    {
        maindbEntities2 db = new maindbEntities2();
        public ActionResult Index()
        {
            Basics basic = (from e in db.Basics
                              select e).First();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;
          
            IEnumerable<Services> Service = (from e in db.Services
                                select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.Name;
            }
            ViewBag.service = s;
            return View();
        }
        public PartialViewResult _services()
        {

            IEnumerable<Services> Services = (from e in db.Services
                                                 select e);
          
            return PartialView("_services", Services);

        }
        public PartialViewResult _news()
        {

            IEnumerable<imgNew> imgNew = (from e in db.imgNew
                                            select e);

            return PartialView("_news", imgNew);

        }
        public ActionResult E_Index()
        {
            Basics basic = (from e in db.Basics
                            select e).OrderByDescending(e => e.BasicID)
                     .FirstOrDefault();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;
            IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                        select e);
            ViewData["listSocial"] = SocialMedialist;
            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.enName + ",";
            }
            ViewBag.service = s;
            return View();
        }
        public PartialViewResult _Eservices()
        {

            IEnumerable<Services> Services = (from e in db.Services
                                              select e);

            return PartialView("_Eservices", Services);

        }
        public PartialViewResult _Enews()
        {

            IEnumerable<imgNew> imgNew = (from e in db.imgNew
                                          select e);

            return PartialView("_news", imgNew);

        }
        public PartialViewResult _social()
        {

            IEnumerable<SocialMedia> imgNew = (from e in db.SocialMedia
                                               select e);

            return PartialView("_social", imgNew);

        }
        public ActionResult About()
        {
            Basics basic = (from e in db.Basics
                            select e).First();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;
            IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                        select e);
            ViewData["listSocial"] = SocialMedialist;
            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.Name + ",";
            }
            ViewBag.service = s;
            return View(basic);
        }

        public ActionResult E_About()
        {
            Basics basic = (from e in db.Basics
                            select e).OrderByDescending(e => e.BasicID)
                     .FirstOrDefault();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;
            IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                        select e);
            ViewData["listSocial"] = SocialMedialist;
            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.enName + ",";
            }
            ViewBag.service = s;
            return View(basic);
        }

        public ActionResult Contact()
        {
            Basics basic = (from e in db.Basics
                            select e).OrderByDescending(e => e.BasicID)
                     .FirstOrDefault();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;

            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.enName + ",";
            }
            ViewBag.service = s;
            return View();
        }
        public ActionResult E_Contact()
        {
            Basics basic = (from e in db.Basics
                            select e).OrderByDescending(e => e.BasicID)
                     .FirstOrDefault();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;

            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.enName + ",";
            }
            ViewBag.service = s;
            return View();
        }
        public ActionResult Branches()
        {
            Basics basic = (from e in db.Basics
                            select e).First();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;
            IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                        select e);
            ViewData["listSocial"] = SocialMedialist;
            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.Name + ",";
            }
            ViewBag.service = s;
            IEnumerable<Branches> Branches = (from e in db.Branches
                                             select e);
            return View(Branches);
        }
       // SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=maindb;Integrated Security=True");

        SqlConnection con = new SqlConnection(@"Data Source=198.38.83.200;User Id=hamdymor_abahussain;Password=abahussain@123;Initial Catalog=hamdymor_abahussain;Persist Security Info=True;");
        SqlCommand com;
        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                Basics basic = (from e in db.Basics
                                select e).First();
                ViewBag.email = basic.email;
                ViewBag.callus = basic.callus;
                ViewBag.parImgtxt = basic.parImgtxt;
                IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                            select e);
                ViewData["listSocial"] = SocialMedialist;
                IEnumerable<Services> Service = (from e in db.Services
                                                 select e);
                string s = "";
                foreach (Services item in Service)
                {
                    s += item.Name + ",";
                }
                ViewBag.service = s;
                con.Open();
                com = new SqlCommand("select * from Branches inner join BranchDetail on Branches.BID = BranchDetail.FKBranchID where BID=" + id, con);
                SqlDataReader SqlDr = com.ExecuteReader();
                DataTable d = new DataTable();
                d.Load(SqlDr);

                ViewBag.cunt = d.Rows.Count;
                con.Close();
                return View(d);
            }
            catch { con.Close(); return View(); }


        }
        [HttpGet]
        public ActionResult EDetails(int id)
        {
            try
            {
                Basics basic = (from e in db.Basics
                                select e).First();
                ViewBag.email = basic.email;
                ViewBag.callus = basic.callus;
                ViewBag.parImgtxt = basic.parImgtxt;
                IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                            select e);
                ViewData["listSocial"] = SocialMedialist;
                IEnumerable<Services> Service = (from e in db.Services
                                                 select e);
                string s = "";
                foreach (Services item in Service)
                {
                    s += item.Name + ",";
                }
                ViewBag.service = s;
                con.Open();
                com = new SqlCommand("select * from Branches inner join BranchDetail on Branches.BID = BranchDetail.FKBranchID where BID=" + id, con);
                SqlDataReader SqlDr = com.ExecuteReader();
                DataTable d = new DataTable();
                d.Load(SqlDr);

                ViewBag.cunt = d.Rows.Count;
                con.Close();
                return View(d);
            }
            catch { con.Close(); return View(); }


        }
        public ActionResult E_Branches()
        {
            Basics basic = (from e in db.Basics
                            select e).OrderByDescending(e => e.BasicID)
                     .FirstOrDefault();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;
            IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                        select e);
            ViewData["listSocial"] = SocialMedialist;
            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.enName+",";
            }
            ViewBag.service = s;
            IEnumerable<Branches> Branches = (from e in db.Branches
                                              select e);
            return View(Branches);
        }
        public ActionResult Products()
        {

            Basics basic = (from e in db.Basics
                            select e).First();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;
            IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                        select e);
            ViewData["listSocial"] = SocialMedialist;
            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.Name + ",";
            }
            ViewBag.service = s;
            IEnumerable<SubCategory> SubCategory1 = (from e in db.SubCategory
                                                     where e.SubCategoryID == 1
                                                     select e);
            foreach (SubCategory item in SubCategory1)
            {
                IEnumerable<Products> ProductsList = (from e in db.Products
                                                      where e.FKSubID == item.SubCategoryID
                                                      select e);
                item.Products = ProductsList;
            }
            return View(SubCategory1);
        }
        [HttpGet]
        public ActionResult GetProducts(string service_Name)
        {

            Basics basic = (from e in db.Basics
                            select e).First();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;
            IEnumerable<SocialMedia> SocialMedialist = (from e in db.SocialMedia
                                                select e);
            ViewData["listSocial"] = SocialMedialist;
            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.Name + ",";
            }
            ViewBag.service = s;

            Services Servicea = (from e in db.Services 
                                where e.Name==service_Name
                                select e ).First();
            IEnumerable<SubCategory> SubCategory1 = (from e in db.SubCategory
                                                    where e.FKServID==Servicea.ServicesID
                                                    select e);
            foreach (SubCategory item in SubCategory1)
            {
                IEnumerable<Products> ProductsList = (from e in db.Products
                                                  where e.FKSubID == item.SubCategoryID
                                                      select e);
                item.Products = ProductsList;
            }
            return View("~/Views/Home/Products.cshtml", SubCategory1);
        }
        //[HttpGet]
        //public PartialViewResult DisplayProduct(int id)
        //{
        //    //Basics basic = (from e in db.Basics
        //    //                select e).First();
        //    //ViewBag.email = basic.email;
        //    //ViewBag.callus = basic.callus;
        //    //ViewBag.parImgtxt = basic.parImgtxt;

        //    //IEnumerable<Services> Service = (from e in db.Services
        //    //                                 select e);
        //    //string s = "";
        //    //foreach (Services item in Service)
        //    //{
        //    //    s += item.Name + ",";
        //    //}
        //    //ViewBag.service = s;
        //    if (id == null)
        //    {
        //        id = 5;
        //    }
        //    con.Open();
        //    com = new SqlCommand("select * from Products where FKSubID=" + id, con);
        //    SqlDataReader SqlDr = com.ExecuteReader();
        //    DataTable d = new DataTable();
        //    d.Load(SqlDr);

        //    ViewBag.cunt = d.Rows.Count;
        //    con.Close();
        //    return PartialView("DisplayProduct", d);


        //}
        public PartialViewResult DisplayProduct()
        {
          
            SubCategory SubCategory = (from e in db.SubCategory
                                            select e).First();
            con.Close();
            con.Open();
            com = new SqlCommand("select * from Products where FKSubID=" + SubCategory.SubCategoryID, con);
            SqlDataReader SqlDr = com.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(SqlDr);

            ViewBag.cunt = d.Rows.Count;
            con.Close();
            return PartialView("DisplayProduct", d);

        }
        public ActionResult E_Products()
        {
            Basics basic = (from e in db.Basics
                            select e).OrderByDescending(e => e.BasicID)
                     .FirstOrDefault();
            ViewBag.email = basic.email;
            ViewBag.callus = basic.callus;
            ViewBag.parImgtxt = basic.parImgtxt;

            IEnumerable<Services> Service = (from e in db.Services
                                             select e);
            string s = "";
            foreach (Services item in Service)
            {
                s += item.enName + ",";
            }
            ViewBag.service = s;
            return View();
        }
    }
}