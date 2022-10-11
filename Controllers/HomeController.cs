using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Teach_Space.Models;

namespace Teach_Space.Controllers
{
    public class HomeController : Controller
    {
        HttpClient hc = new HttpClient();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult demo()
        {
            return View();
        }
        public ActionResult Schedule()
        {
            return View();
        }

     
        //Getting users in list after registration
        public async Task<ActionResult> GetUsers([DataSourceRequest] DataSourceRequest request)
        {
            HttpClient hc = new HttpClient();
            //Response response = new Response();
            List<User> listUser = new List<User>();
            

            hc.BaseAddress = new Uri("https://localhost:44320/");

            HttpResponseMessage message = await hc.GetAsync("api/Users/GetUsers");

            if (message.IsSuccessStatusCode)
            {
                var display = message.Content.ReadAsAsync<List<User>>();
                listUser = display.Result;
            }
            //response.listUser = listUser;
            return Json(listUser.ToDataSourceResult(request));
        }


         //Creating Schedule for the Teach-space
        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> CreateSchedule([DataSourceRequest] DataSourceRequest request, Schedule item)
        {
            
            if (item != null && ModelState.IsValid)
            {
                hc.BaseAddress = new Uri("https://localhost:44320/");
                HttpResponseMessage message = await hc.PostAsJsonAsync("api/Schedule/CreateSchedule/", item);
            }

            return Json(new[] { item }.ToDataSourceResult(request, ModelState));
        }



        public ActionResult Event()
        {
            return View();
        }


        //Displaying the List to Users of schedule 
        public async Task<ActionResult> GetSchedule([DataSourceRequest] DataSourceRequest request)
        {
            HttpClient hc = new HttpClient();
            List<sp_GetSchedule_Result> schedulelist = new List<sp_GetSchedule_Result>();


            hc.BaseAddress = new Uri("https://localhost:44320/");

            HttpResponseMessage message = await hc.GetAsync("api/Schedule/displaySchedule");

            if (message.IsSuccessStatusCode)
            {
                var display = message.Content.ReadAsAsync<List<sp_GetSchedule_Result>>();
                schedulelist = display.Result;
            }
   
            return Json(schedulelist.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}
