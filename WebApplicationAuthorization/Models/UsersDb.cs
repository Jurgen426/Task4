using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAuthorization.Models
{
    public class UsersDb
    {
        public List<MyUser> Users { get; set; }

        public UsersDb()
        {
            Users = new List<MyUser>();
        }

    }
}