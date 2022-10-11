using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teach_Space.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Type { get; set; }
    }
}