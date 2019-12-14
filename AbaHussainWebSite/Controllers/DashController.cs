using AbaHussainWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbaHussainWebSite.Controllers
{
    public class DashController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=maindb;Integrated Security=True");

        // SqlConnection con = new SqlConnection(@"Data Source=198.38.83.200;User Id=hamdymor_abahussain;Password=abahussain@123;Initial Catalog=maindb;Integrated Security=True");
        SqlCommand com;

        // GET: Dash

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string pass)
        {
            try
            {

                if (username == "Admin" && pass == "111")
                {
                    Session["UserLog"] = "login";
                    return RedirectToAction("Home");
                }
                else { return View(); }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["UserLog"] = null;
            return Redirect("Login");
        }
        public ActionResult Home(string addr)
        {if (Session["UserLog"] != null)
            {
                try
                {
                    int []ar = new int[2];
                       ar = getids();
                    int brow = ar[0];
                    int benrow = ar[1];
                    con.Open();
                    if (brow != 0 && benrow!=0)
                    {
                        Basics j = new Basics();
                        com = new SqlCommand("select * from Basics where BasicID=" + brow + " ", con);
                        SqlCommand com1 = new SqlCommand("select * from Basics where BasicID=" + benrow + " ", con);
                        SqlDataReader SqlDr = com.ExecuteReader();
                        DataTable dtt = new DataTable();
                        dtt.Load(SqlDr);

                        SqlDataReader SqlDr1 = com1.ExecuteReader();
                        DataTable dtt1 = new DataTable();
                        dtt1.Load(SqlDr1);

                        j.email = dtt.Rows[0]["email"].ToString();
                        j.Address = dtt.Rows[0]["Address"].ToString();
                        j.website = dtt.Rows[0]["website"].ToString();
                        j.callus = dtt.Rows[0]["callus"].ToString();
                        ViewBag.addr = dtt1.Rows[0]["Address"].ToString();
                        con.Close();
                        return View(j);
                    }
                    return View();
                }
                catch { return View(); }
            }
            else { return Redirect("Login"); }   
        }
        public int[] getids()
        {
            int brow = 0;
            int benrow = 0;
            int[] arr=new int[2] { brow,benrow};
            con.Open();
            com = new SqlCommand("select * from Basics", con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            
            for (int t = 0; t < dt.Rows.Count; t++)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[t]["email"])))
                {
                    brow = int.Parse(dt.Rows[t]["BasicID"].ToString());
                    benrow = brow + 1;

                }
            }
            con.Close();
            arr[0] = brow;
            arr[1] = benrow;
            return arr;
        }
        [HttpPost]
        public ActionResult Home(Basics bas, string addr)
        {
            try
            {
                int[] r = new int[2];
                r = getids();
                int brow = r[0];
                int benrow = r[1];
                con.Open();
               
                if (brow == 0 && benrow == 0)
                {
                    com = new SqlCommand("insert into  Basics(email,Address,website,callus) Values ('" + bas.email + "',N'" + bas.Address + "','" + bas.website + "','" + bas.callus + "')", con);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("insert into  Basics(Address) Values ('" + addr + "')", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    ViewBag.msg = "your Data inserted successfully";
                }
                else
                {
                    com = new SqlCommand("update Basics set email='"+ bas.email + "',Address=N'"+ bas.Address + "',website='" + bas.website + "',callus='" + bas.callus + "' where BasicID="+brow, con);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("update   Basics set Address='" + addr + "' where BasicID="+benrow, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    ViewBag.msg = "your Data Edited successfully";
                }
                 return Redirect("Home");
            }
            catch
            {
                ViewBag.Emsg = "your Data didn't insert correctly";
                return View();
            }
        }
        public ActionResult mainText()
        {
            if (Session["UserLog"] != null)
            {
                try
                {
                    int[] ar = new int[2];
                    ar = getids();
                    int brow = ar[0];
                    int benrow = ar[1];
                    con.Open();
                    if (brow != 0 && benrow != 0)
                    {
                        Basics j = new Basics();
                        com = new SqlCommand("select * from Basics where BasicID=" + brow + " ", con);
                        SqlCommand com1 = new SqlCommand("select * from Basics where BasicID=" + benrow + " ", con);
                        SqlDataReader SqlDr = com.ExecuteReader();
                        DataTable dtt = new DataTable();
                        dtt.Load(SqlDr);

                        SqlDataReader SqlDr1 = com1.ExecuteReader();
                        DataTable dtt1 = new DataTable();
                        dtt1.Load(SqlDr1);
                        //
                        j.headerMidtxt = dtt.Rows[0]["headerMidtxt"].ToString();
                        j.ourServtxt = dtt.Rows[0]["ourServtxt"].ToString();
                        j.ParagMidtxt = dtt.Rows[0]["ParagMidtxt"].ToString();
                        j.maintextNews = dtt.Rows[0]["maintextNews"].ToString();
                        j.mainImagText1 = dtt.Rows[0]["mainImagText1"].ToString();
                        j.mainImagText2 = dtt.Rows[0]["mainImagText2"].ToString();
                        j.midHeaderIndexPage = dtt.Rows[0]["midHeaderIndexPage"].ToString();
                        j.midParaIndexPage = dtt.Rows[0]["midParaIndexPage"].ToString();
                        j.parImgtxt = dtt.Rows[0]["parImgtxt"].ToString();
                       
                        ViewBag.enourServtxt = dtt1.Rows[0]["ourServtxt"].ToString();
                        ViewBag.headerMidtxt = dtt1.Rows[0]["headerMidtxt"].ToString();
                        ViewBag.enParagMidtxt = dtt1.Rows[0]["ParagMidtxt"].ToString();
                        ViewBag.maintextNews = dtt1.Rows[0]["maintextNews"].ToString();
                        ViewBag.mainImagText1 = dtt1.Rows[0]["mainImagText1"].ToString();
                        ViewBag.mainImagText2 = dtt1.Rows[0]["mainImagText2"].ToString();
                        ViewBag.parImgtxt = dtt1.Rows[0]["parImgtxt"].ToString();
                        ViewBag.midHeaderIndexPage = dtt1.Rows[0]["midHeaderIndexPage"].ToString();
                        ViewBag.midParaIndexPage = dtt1.Rows[0]["midParaIndexPage"].ToString();
                        con.Close();
                        return View(j);
                    }
                    return View();
                }
                catch { return View(); }
            }
            else { return Redirect("Login"); }
        }
        [HttpPost]
        public ActionResult mainText(Basics bas, string enourServtxt, string enheaderMidtxt, string enParagMidtxt, string enmaintextNews, string enmainImagText1, string enmainImagText2, string enparImgtxt, string enmidHeaderIndexPage, string enmidParaIndexPage)
        {
            //try
            //{
                int[] r = new int[2];
                r = getids();
                int brow = r[0];
                int benrow = r[1];
                if (brow != 0 && benrow != 0)
                {
                    con.Open();
                    com = new SqlCommand("update  Basics set ourServtxt=N'" + bas.ourServtxt + "',headerMidtxt=N'" + bas.headerMidtxt + "',ParagMidtxt=N'" + bas.ParagMidtxt + "',maintextNews=N'" + bas.maintextNews + "',mainImagText1=N'" + bas.mainImagText1 + "',mainImagText2=N'" + bas.mainImagText2 + "',parImgtxt=N'" + bas.parImgtxt + "',midHeaderIndexPage=N'" + bas.midHeaderIndexPage + "',midParaIndexPage=N'" + bas.midParaIndexPage + "'where BasicID=" + brow, con);

                    // com = new SqlCommand("insert into  Basics(ourServtxt,headerMidtxt,ParagMidtxt,maintextNews,mainImagText1,mainImagText2,parImgtxt,midHeaderIndexPage,midParaIndexPage) Values (N'" + bas.ourServtxt + "',N'" + bas.headerMidtxt + "',N'" + bas.ParagMidtxt + "',N'" + bas.maintextNews + "',N'" + bas.mainImagText1 + "',N'" + bas.mainImagText2 + "',N'" + bas.parImgtxt + "',N'" + bas.midHeaderIndexPage + "',N'" + bas.midParaIndexPage + "')", con);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("update  Basics set ourServtxt=N'" + enourServtxt + "',headerMidtxt=N'" + enheaderMidtxt + "',ParagMidtxt=N'" + enParagMidtxt + "',maintextNews=N'" + enmaintextNews + "',mainImagText1=N'" + enmainImagText1 + "',mainImagText2=N'" + enmainImagText2 + "',parImgtxt=N'" + enparImgtxt + "',midHeaderIndexPage=N'" + enmidHeaderIndexPage + "',midParaIndexPage=N'" + enmidParaIndexPage + "' where BasicID=" + benrow, con);
                    // com = new SqlCommand enourServtxt + "','" + headerMidtxt + "','" + enParagMidtxt + "','" + maintextNews + "','" + mainImagText1 + "','" + mainImagText2 + "','" + parImgtxt + "','" + midHeaderIndexPage + "','" + midParaIndexPage + "')", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    ViewBag.msg = "your Data updated successfully";
                    return View();
                }
                else { ViewBag.Emsg = "برجاء ادخال معلومات الاتصال اولا"; return View(); }
                
            //}
            //catch(Exception ex) { ViewBag.Emsg = "your Data didn't insert correctly"; return View(); }
        }
        public ActionResult socialmedia()
        {if (Session["UserLog"] != null)
            {
                DDLSocialMedia();
                return View();
            }
            else { return Redirect("Login"); }
        }
        [HttpPost]
        public ActionResult socialmedia(SocialMedia sM)
        {
            try
            {
                con.Open();
                com = new SqlCommand("select icon from SocialMedia where icon='" + sM.icon + "'", con);
                SqlDataReader sqldr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sqldr);
                if (dt.Rows.Count <= 0)
                {
                    com = new SqlCommand("insert into  SocialMedia Values ('" + sM.icon + "','" + sM.link + "')", con);
                    com.ExecuteNonQuery();
                }
                else ViewBag.Emsg = "اللينك موجود من قبل";
                con.Close();
                DDLSocialMedia();
                return View();
            }
            catch
            {
                ViewBag.Emsg = "Error Ocurred"; return View();
            }
        }
        public PartialViewResult _SocialLinks()
        {
            con.Open();
            com = new SqlCommand("select * from SocialMedia", con);
            SqlDataReader sqldr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqldr);
            con.Close();
            return PartialView("_SocialLinks", dt);
        }
        public void DDLFun()
        {

            //try
            //{

            con.Open();
            com = new SqlCommand("select * from SocialMedia ", con);
            SqlDataReader SqlDr = com.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(SqlDr);
            DataRow newRow = d.NewRow();
            con.Close();
            string[] arr = new string[4] { "facebook", "twitter", "whatsapp", "instagram" };
            List<SocialMedia> List = new List<SocialMedia>();

            if (d.Rows.Count > 0)
            {

                //for (int i = 0; i < d.Rows.Count; i++)
                //{
                for (int k = 0; k < arr.Length; k++)
                {


                    if (!arr[k].Contains(d.Rows[k]["icon"].ToString()))
                    {
                        List.Add(new SocialMedia() { SocialID = k + 1, icon = arr[k] });
                        break;
                    }
                    else { continue; }
                }


                // }

                ViewBag.listIcons = List;
            }

            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    List.Add(new SocialMedia() { SocialID = i + 1, icon = arr[i] });
                }
                ViewBag.listIcons = List;
            }



            //}
            // catch {  }

        }
        public void DDLSocialMedia()
        {
            try
            {
                con.Open();
                List<SocialMedia> List = new List<SocialMedia>();
                List.Add(new SocialMedia() { SocialID = 1, icon = "facebook" });
                List.Add(new SocialMedia() { SocialID = 2, icon = "twitter" });
                List.Add(new SocialMedia() { SocialID = 3, icon = "instagram" });
               // List.Add(new SocialMedia() { SocialID = 4, icon = "whatsapp" });
                ViewData["listSocial"] = new SelectList(List, "SocialID", "icon");

                con.Close();
            }

            catch { con.Close(); }

        }
        public ActionResult subcategory()
        {if (Session["UserLog"] != null)
            {
                DDlSevices();
                return View();
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult subcategory(SubCategory sub)
        {
            try
            {
                con.Open();
                com = new SqlCommand("insert into  SubCategory Values (N'" + sub.SubCateName + "','" + sub.FKServID + "',N'" + sub.enSubName + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                DDlSevices();
                if (ViewData["listServ"] != null)
                    return View();
                else return View(ViewBag.Emsg);
            }
            catch { ViewBag.Emsg = "Error Ocurred"; return View(); }
        }
        public void DDlSevices()
        {
            try
            {
                con.Open();
                com = new SqlCommand("select * from Services ", con);
                SqlDataReader SqlDr = com.ExecuteReader();
                DataTable d = new DataTable();
                d.Load(SqlDr);
                List<Services> List = new List<Services>();
                for (int t = 0; t < d.Rows.Count; t++)
                {
                    int id = int.Parse(d.Rows[t]["ServicesID"].ToString());
                    string name = d.Rows[t]["Name"].ToString();
                    List.Add(new Services() { ServicesID = id, Name = name });
                    ViewData["listServ"] = new SelectList(List, "ServicesID", "Name");
                }

                con.Close();
            }

            catch { con.Close(); }
        }
        public PartialViewResult _subcat()
        {
            con.Open();
            com = new SqlCommand("select * from SubCategory", con);
            SqlDataReader sqldr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqldr);
            con.Close();

            return PartialView("_subcat", dt);
        }
        public ActionResult LastNew()
        {if (Session["UserLog"] != null)
            {
                return View();
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult LastNew(imgNew singlenews)
        {
            HttpPostedFileBase file = Request.Files["imgfile"];
            if (file != null && file.ContentLength > 0)
                try
                {
                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    singlenews.img = "~/imgs/" + file.FileName;
                    con.Open();
                    com = new SqlCommand("insert into  imgNew Values ('" + singlenews.img + "',N'" + singlenews.Headertxt + "','" + singlenews.DateNew + "',N'" + singlenews.Maintxt + "',N'" + singlenews.enHeadertxt + "',N'" + singlenews.enMaintxt + "')", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    return View();
                }
                catch { ViewBag.msg = "your news didn't insert correctly"; return View(); }

            else
            {
                ViewBag.msg = "file not uploaded"; return View();
            }
        }
        public PartialViewResult _lastNew()
        {
            con.Open();
            com = new SqlCommand("select * from ImgNew", con);
            SqlDataReader sqldr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqldr);
            con.Close();

            return PartialView("_lastNew", dt);
        }
        public ActionResult products()
        {if (Session["UserLog"] != null)
            {
                DDlsub();
                return View();
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult products(Products pro)
        {
            HttpPostedFileBase file = Request.Files["img"];
            if (file != null && file.ContentLength > 0)
                try
                {
                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    pro.img = "~/imgs/" + file.FileName;
                    con.Open();
                    com = new SqlCommand("insert into  Products Values ('" + pro.Price + "',N'" + pro.Text + "','" + pro.img + "'," + pro.FKSubID + ",N'" + pro.enText + "')", con);
                    com.ExecuteNonQuery();
                    con.Close();

                    DDlsub();
                    if (ViewData["listsub"] != null)
                    { return View(); }
                    else { return View(ViewBag.Emsg); }
                }
                catch { ViewBag.Emsg = "a product didn't insert correctly"; return View(); }

            else
            {
                ViewBag.Emsg = "file not uploaded"; return View();
            }
        }
        public void DDlsub()
        {
            try
            {
                con.Open();
                com = new SqlCommand("select * from SubCategory ", con);
                SqlDataReader SqlDr = com.ExecuteReader();
                DataTable d = new DataTable();
                d.Load(SqlDr);
                List<SubCategory> List = new List<SubCategory>();
                for (int t = 0; t < d.Rows.Count; t++)
                {
                    int id = int.Parse(d.Rows[t]["SubCategoryID"].ToString());
                    string name = d.Rows[t]["SubCateName"].ToString();
                    List.Add(new SubCategory() { SubCategoryID = id, SubCateName = name });
                    ViewData["listsub"] = new SelectList(List, "SubCategoryID", "SubCateName");
                }


                con.Close();
            }

            catch { con.Close(); }
        }
        public PartialViewResult _product()
        {
            con.Open();
            com = new SqlCommand("select * from products", con);
            SqlDataReader sqldr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqldr);
            con.Close();

            return PartialView("_product", dt);
        }
        public ActionResult Services()
        {if (Session["UserLog"] != null)
            {
                try
                {
                    con.Open();
                    com = new SqlCommand("select * from SubCategory ", con);
                    SqlDataReader SqlDr = com.ExecuteReader();
                    DataTable d = new DataTable();
                    d.Load(SqlDr);
                    List<SubCategory> List = new List<SubCategory>();
                    for (int t = 0; t < d.Rows.Count; t++)
                    {
                        int id = int.Parse(d.Rows[t]["SubCategoryID"].ToString());
                        string name = d.Rows[t]["SubCateName"].ToString();
                        List.Add(new SubCategory() { SubCategoryID = id, SubCateName = name });
                        ViewData["listsub"] = new SelectList(List, "ServicesID", "Name");
                    }

                    con.Close();
                }
                catch { con.Close(); }
                return View();
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult services(Services serv)
        {

            HttpPostedFileBase file = Request.Files["imgfile"];
            if (file != null && file.ContentLength > 0)
                try
                {
                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    serv.img = "~/imgs/" + file.FileName;
                    con.Open();
                    com = new SqlCommand("insert into  Services Values (N'" + serv.Name + "',N'" + serv.textServe + "',N'" + serv.img + "','" + serv.enName + "','" + serv.entxtServe + "')", con);
                    com.ExecuteNonQuery();
                    con.Close();

                    return View();
                }
                catch
                {
                    ViewBag.Emsg = "your services didn't insert correctly"; return View();
                }

            else
            {
                ViewBag.Emsg = "file not uploaded"; return View();
            }

        }
        public PartialViewResult _services()
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("select * from Services", con);
            SqlDataReader sqldr = com1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqldr);

            con.Close();
            // IEnumerable<DataRow> s = dt.AsEnumerable();
            return PartialView("_services", dt);
        }
        public PartialViewResult _Branches()
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("select * from Branches", con);
            SqlDataReader sqldr = com1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqldr);

            con.Close();
            // IEnumerable<DataRow> s = dt.AsEnumerable();
            return PartialView("_Branches", dt);
        }
        public ActionResult AllBranches()
        {if (Session["UserLog"] != null)
            {
                return View();
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult AllBranches(Branches br)
        {
            BranchDetail bd = new BranchDetail();
            HttpPostedFileBase file = Request.Files["imgfile"];
            HttpPostedFileBase files = Request.Files["files"];
            // string[] files = Request.Files["fileUpload"];
            if (file != null && file.ContentLength > 0)
                try
                {
                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    br.mainImg = "~/imgs/" + file.FileName;
                    con.Open();
                    com = new SqlCommand("insert into  Branches Values ('" + br.phone + "',N'" + br.Title + "',N'" + br.mainImg + "',N'" + br.AddBranche + "',N'" + br.enTitle + "',N'" + br.enAddrBranch + "')", con);
                    com.ExecuteNonQuery();
                    int id = getMaxId();
                    SqlCommand com2;
                    for ( int i=0;i<Request.Files.Count; i++)
                    { if (i == 0)
                        { continue; }
                        else
                        {
                            if (Request.Files[i].ContentLength > 0)
                            {
                                Request.Files[i].SaveAs(Server.MapPath("~/imgs/" + Request.Files[i].FileName));
                                bd.imgSrc = "~/imgs/" + Request.Files[i].FileName;
                                com2 = new SqlCommand("insert into BranchDetail values('" + bd.imgSrc + "'," + id + ")", con);
                                com2.ExecuteNonQuery();
                            }
                        }
                    }
                    con.Close();
                    ViewBag.msg = "your data inserted successfully";
                    return View();
                }
                catch(Exception ex)
                {
                    ViewBag.Emsg = "your data didn't insert correctly"; return View();
                }

            else
            {
                ViewBag.Emsg = "file not uploaded"; return View();
            }
        }
        [HttpPost]
        public JsonResult Upload()
        {
            BranchDetail bd = new BranchDetail();

            con.Open();
            foreach (HttpPostedFileBase file in Request.Files)
            {
                if (file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    com = new SqlCommand("insert into BranchDetail values(N'" + bd.imgSrc + "'," + getMaxId() + ")", con);

                }
            }
            con.Close();

            return Json(new { result = true });
        }
        public int getMaxId()
        {
            try
            {
                com = new SqlCommand("select top(1)BID from Branches order by BID desc ", con);
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return int.Parse(dt.Rows[0][0].ToString());
            }
            catch { con.Close(); return 0; }
        }
        public ActionResult Details()
        {if (Session["UserLog"] != null)
            {
                return View();
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult Details(int id)
        {
            try
            {

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

        //----------------------------------------edit data in table ----------------------
        [HttpGet]
        public ActionResult EditBranch(int id)
        {if (Session["UserLog"] != null)
            {
                try
                {
                    con.Open();
                    Branches j = new Branches();
                    com = new SqlCommand("select * from Branches where BID=" + id + " ", con);
                    SqlDataReader SqlDr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(SqlDr);
                    j.BID = id;
                    j.Title = dt.Rows[0]["Title"].ToString();
                    j.enTitle = dt.Rows[0]["enTitle"].ToString();
                    j.phone = dt.Rows[0]["phone"].ToString();
                    j.AddBranche = dt.Rows[0]["AddBranche"].ToString();
                    j.enAddrBranch = dt.Rows[0]["enAddrBranch"].ToString();
                    j.mainImg = dt.Rows[0]["mainImg"].ToString();
                    con.Close();
                    return View(j);
                }
                catch { ViewBag.Emsg = "Error occured"; return View(); };
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult EditBranch(Branches bran)
        {
            try
            {
                HttpPostedFileBase files = Request.Files["files"];
                HttpPostedFileBase file = Request.Files["imgfile"];
                if (file != null && file.ContentLength > 0)
                {

                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    bran.mainImg = "~/imgs/" + file.FileName;
                    con.Open();
                    com = new SqlCommand("update Branches set Title=N'" + bran.Title + "',enTitle=N'" + bran.enTitle + "',phone='" + bran.phone + "',mainImg=N'" + bran.mainImg + "',AddBranche=N'" + bran.AddBranche + "',enAddrBranch=N'" + bran.enAddrBranch + "'where BID=" + bran.BID, con);
                    com.ExecuteNonQuery();
                    SqlCommand com2;
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        if (i == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (Request.Files[i].ContentLength > 0)
                            {
                                Request.Files[i].SaveAs(Server.MapPath("~/imgs/" + Request.Files[i].FileName));
                                string imgSrc = "~/imgs/" + Request.Files[i].FileName;
                                com2 = new SqlCommand("insert into BranchDetail values('" + imgSrc + "'," + bran.BID + ")", con);
                                com2.ExecuteNonQuery();
                            }
                        }

                        con.Close();
                        return RedirectToAction("AllBranches");
                    }
                }
                else
                {
                    ViewBag.Emsg = "file not uploaded";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.Emsg = "فشل التعديل";
                return View();
            }
            return View();
        }


        [HttpGet]
        public ActionResult EditServ(int id)
        {if (Session["UserLog"] != null)
            {
                try
                {
                    con.Open();
                    Services j = new Services();
                    com = new SqlCommand("select * from Services where ServicesID=" + id + " ", con);
                    SqlDataReader SqlDr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(SqlDr);
                    j.ServicesID = int.Parse(dt.Rows[0]["ServicesID"].ToString());
                    j.Name = dt.Rows[0]["Name"].ToString();
                    j.textServe = dt.Rows[0]["textServe"].ToString();
                    j.enName = dt.Rows[0]["enName"].ToString();
                    j.entxtServe = dt.Rows[0]["entxtServe"].ToString();
                    j.img = dt.Rows[0]["img"].ToString();
                    con.Close();
                    return View(j);
                }
                catch { ViewBag.Emsg = "Error occured"; return View(); };
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult EditServ(Services serv)
        {

            HttpPostedFileBase file = Request.Files["imgfile"];
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    serv.img = "~/imgs/" + file.FileName;
                    con.Open();
                    com = new SqlCommand("update Services set Name=N'" + serv.Name + "',textServe=N'" + serv.textServe + "',img=N'" + serv.img + "',enName=N'" + serv.enName + "',entxtServe=N'" + serv.entxtServe + "'where ServicesID=" + serv.ServicesID, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("Services");
                }

                catch
                {
                    ViewBag.Emsg = "فشل التعديل";
                    return View();
                }
            }
            else { ViewBag.Emsg = "file not uploaded"; return View(); }

        }

        [HttpGet]
        public ActionResult EditimgNew(int id)
        {if (Session["UserLog"] != null)
            {
                try
                {
                    con.Open();
                    imgNew j = new imgNew();
                    com = new SqlCommand("select * from imgNew where NewID=" + id + " ", con);
                    SqlDataReader SqlDr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(SqlDr);
                    j.NewID = int.Parse(dt.Rows[0]["NewID"].ToString());
                    j.Headertxt = dt.Rows[0]["Headertxt"].ToString();
                    j.Maintxt = dt.Rows[0]["Maintxt"].ToString();
                    j.enHeadertxt = dt.Rows[0]["enHeadertxt"].ToString();
                    j.enMaintxt = dt.Rows[0]["enMaintxt"].ToString();
                    j.img = dt.Rows[0]["img"].ToString();
                    j.DateNew = Convert.ToDateTime(dt.Rows[0]["DateNew"].ToString());
                    con.Close();
                    return View(j);
                }
                catch { ViewBag.Emsg = "Error occured"; return View(); };
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult EditimgNew(imgNew im)
        {

            HttpPostedFileBase file = Request.Files["imgfile"];
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    im.img = "~/imgs/" + file.FileName;
                    con.Open();
                    com = new SqlCommand("update imgNew set Headertxt=N'" + im.Headertxt + "',Maintxt=N'" + im.Maintxt + "',img=N'" + im.img + "',DateNew=N'" + im.DateNew + "',enHeadertxt=N'" + im.enHeadertxt + "', enMaintxt=N'" + im.enMaintxt + "' where NewID=" + im.NewID, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("lastNew");
                }

                catch
                {
                    ViewBag.Emsg = "فشل التعديل";
                    return View();
                }
            }
            else { ViewBag.Emsg = "file not uploaded"; return View(); }

        }



        [HttpGet]
        public ActionResult Editsubcate(int id)
        {if (Session["UserLog"] != null)
            {
                try
                {
                    con.Open();
                    SubCategory j = new SubCategory();
                    com = new SqlCommand("select * from SubCategory where SubCategoryID=" + id + " ", con);
                    SqlDataReader SqlDr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(SqlDr);
                    j.SubCategoryID = int.Parse(dt.Rows[0]["SubCategoryID"].ToString());
                    j.SubCateName = dt.Rows[0]["SubCateName"].ToString();
                    j.enSubName = dt.Rows[0]["enSubName"].ToString();
                    DDlSevices();
                    con.Close();
                    return View(j);
                }
                catch { ViewBag.Emsg = "Error occured"; return View(); };
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult Editsubcate(SubCategory sub)
        { try
                {
                   
                    con.Open();
                    com = new SqlCommand("update SubCategory set SubCateName=N'" + sub.SubCateName + "',enSubName=N'" + sub.enSubName + "' where SubCategoryID=" + sub.SubCategoryID, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    DDlSevices();
                    return RedirectToAction("subcategory");
                }

                catch
                {
                    ViewBag.Emsg = "فشل التعديل";
                    return View();
                }
           
        }

        
              [HttpGet]
        public ActionResult Editproduct(int id)
        {if (Session["UserLog"] != null)
            {
                try
                {
                    DDlsub();
                    con.Open();
                    Products j = new Products();
                    com = new SqlCommand("select * from Products where ProductID=" + id + " ", con);
                    SqlDataReader SqlDr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(SqlDr);
                    j.ProductID = int.Parse(dt.Rows[0]["ProductID"].ToString());
                    j.Text = dt.Rows[0]["Text"].ToString();
                    j.enText = dt.Rows[0]["enText"].ToString();
                    j.Price = decimal.Parse(dt.Rows[0]["Price"].ToString());
                    j.img = dt.Rows[0]["img"].ToString();

                    con.Close();
                    return View(j);
                }
                catch { ViewBag.Emsg = "Error occured"; return View(); };
            }
            else return Redirect("Login");
        }
        [HttpPost]
        public ActionResult Editproduct(Products pro)
        {
            DDlsub();
            HttpPostedFileBase file = Request.Files["img"];
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    file.SaveAs(Server.MapPath("~/imgs/" + file.FileName));
                    pro.img = "~/imgs/" + file.FileName;
                    con.Open();
                    com = new SqlCommand("update Products set Text=N'" + pro.Text + "',enText=N'" + pro.enText + "',img=N'" + pro.img + "',Price=" + pro.Price + " where ProductID=" + pro.ProductID, con);
                    com.ExecuteNonQuery();
                    
                    con.Close();
                    return RedirectToAction("products");
                }
                catch
                {
                    ViewBag.Emsg = "file not upload";
                    return View();
                }
            }
            else
            {
                ViewBag.Emsg = "فشل التعديل";
                return View();
            }
        }


    }
}