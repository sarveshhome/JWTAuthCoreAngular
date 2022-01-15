using Microsoft.EntityFrameworkCore;
using MVCJWTTokenDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MVCJWTTokenDemo.DAL
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) {
            
        }
        public DbSet<MEmployee> Emp { get; set; }
    }
}
