using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teach_Space.Models
{
    public class Response
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public User user { get; set; }
        public Schedule schedule { get; set; }
        public List<User> listUser  { get; set; }
    }
}