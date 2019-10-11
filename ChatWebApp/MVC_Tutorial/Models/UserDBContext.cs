using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Tutorial.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext()
        {

        }

        public DbSet<Users> Users { get; set; }

    }
}