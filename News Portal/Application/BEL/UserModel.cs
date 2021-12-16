using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEL
{
    class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}