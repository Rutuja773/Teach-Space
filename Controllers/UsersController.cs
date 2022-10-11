using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teach_Space.Models;

namespace Teach_Space.Controllers
{
    public class UsersController : ApiController
    {
        TeachSpaceEntities db = new TeachSpaceEntities();

        [Route("api/Users/GetUsers")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {

            //Response response = new Response();
            List<User> listUser = new List<User>();
            listUser = db.Users.ToList();
            return Json(listUser);
        }


        //[Route("api/Useres/CreateSchedule")]
        //[HttpPost]
        //public Response CreateSchedule(Schedule schedule)
        //{
        //    Response response = new Response();
        //    Schedule schedules = new Schedule();
        //    if (Schedule.Type == "Add")
        //    {
        //        schedule.ID =
        //    }

        //    return response;

        //}
    }
}
