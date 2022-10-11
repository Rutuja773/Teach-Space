using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teach_Space.Models;

namespace Teach_Space.Controllers
{
    public class ScheduleController : ApiController
    {
        private TeachSpaceEntities entities;
        public ScheduleController()
        {
            this.entities = new TeachSpaceEntities();
        }



        [Route("api/Schedule/CreateSchedule")]
        [HttpPost]
        public HttpResponseMessage CreateSchedule(Schedule schedule)
        {
            ObjectParameter errorMessage = new ObjectParameter("errorMessage", typeof(string));
            entities.sp_CreateSchedule(schedule.UserID, schedule.Topic, schedule.Date, schedule.Time, schedule.MODE, errorMessage);
            entities.SaveChanges();
            //return (IHttpActionResult)Request.CreateResponse(HttpStatusCode.OK, schedule);
            return Request.CreateResponse(HttpStatusCode.OK);
        }



        //[Route("api/Schedule/displaySchedule")]
        [HttpGet]
        public IHttpActionResult displaySchedule()
        {

            //Response response = new Response();
            List<sp_GetSchedule_Result> list = new List<sp_GetSchedule_Result>();
            list = entities.sp_GetSchedule().ToList();

           
                return Json(list);
         }


            //response.ResponseCode = "200";
            //response.ResponseMessage = "Data Fetched";
            //response.listUser = listUser;

            //return Json(listUser);
        
    }
}
