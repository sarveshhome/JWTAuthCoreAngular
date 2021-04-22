using Microsoft.EntityFrameworkCore;
using MVCJWTTokenDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCJWTTokenDemo.DAL
{
    public class PatientDbContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("tblPatient");            
            //Mapping
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=sony-vaio;Initial Catalog=PatientDB;User ID=sa;Password=password@123");
        }
        public DbSet<Patient> Patients { get; set; }
    }
}
