using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teach_Space.Models;

namespace Teach_Space.Controllers
{
    public class AccountController : ApiController
    {
        //private User _currentUser;
        private TeachSpaceEntities entities = new TeachSpaceEntities();
        //private object varhashedBytes;
        public static int UserId;
        public AccountController()
        {
            this.entities = new TeachSpaceEntities();
        }

        [Route("api/Account/Register")]
        [HttpPost]
        public void Register(User model)
        {
            //model.IsAdmin = true;

            if (ModelState.IsValid)
            {
                using (entities)
                {
                    //var user = 
                    //model.IsAdmin = false;
                    //model.CreatedDateTime = DateTime.Today;
                    ObjectParameter errorMessage = new ObjectParameter("errorMessage", typeof(string));
                    entities.sp_Registeration(model.FullName, model.Address, model.Email, model.Password, model.DOB, errorMessage);
                    //entities.Users.Add(model);
                    entities.SaveChanges();
                }
            }
        }



        public HttpResponseMessage Login(User model)
        {
            if (ModelState.IsValid)
            {
                using (entities)
                {
                    
                    var _currentUser = entities.Users.FirstOrDefault(m => m.Email == model.Email && m.Password == model.Password);
                    if (_currentUser != null)
                    {
                        UserId = _currentUser.ID;
                        if(UserId == 1)
                        {
                            var adminUrl = this.Url.Link("Default", new
                            {
                                Controller = "Home",
                                Action = "Schedule"
                            });
                            return Request.CreateResponse(HttpStatusCode.Created,
                                                     new { Success = true, RedirectUrl = adminUrl });

                        }
                        //TODO: Redirect To Single app Page with this UserId
                        Debug.WriteLine("Success");
                        //Redirect("https://localhost:44320/Account/Login");

                        var newUrl = this.Url.Link("Default", new
                        {
                            Controller = "Home",
                            Action = "Event"
                        });
                        return Request.CreateResponse(HttpStatusCode.OK,
                                                 new { Success = true, RedirectUrl = newUrl });
                    }



                }
            }
            var newUrl1 = this.Url.Link("Default", new
            {
                Controller = "Home",
                Action = "Login"
            });
            return Request.CreateResponse(HttpStatusCode.Unauthorized,
                                                     new { Success = true, RedirectUrl = newUrl1 });
            
        }
    }

}
