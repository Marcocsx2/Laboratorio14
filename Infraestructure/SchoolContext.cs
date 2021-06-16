using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Infraestructure
{
    class SchoolContext : DbContext
    {
        public SchoolContext() : base("name = MyContextDB")
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
