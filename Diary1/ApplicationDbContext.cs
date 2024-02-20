using Diary1.Models;
using Diary1.Models.Configurations;
using Diary1.Models.Domains;
using Diary1.Properties;
using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime;

namespace Diary1
{
    public class ApplicationDbContext : DbContext
    {

        //ApplicationDbContext settings = new ApplicationDbContext
        //{
        //    ServerAdress = "(local)",
        //    ServerName = "SQLEXPRESS",
        //    DataBaseName = "Diary",
        //    DataBaseUser = "danielsql",
        //    DataBasePassword = "Genowefa123!",
        //};
        
        public ApplicationDbContext()
            : base(settings.GetConnectionString())
        {
           
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        public string ServerAdress { get; set; }
        public string ServerName { get; set; }
        public string DataBaseName { get; set; }
        public string DataBaseUser { get; set; }
        public string DataBasePassword { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
        }
        public string GetConnectionString()
        {
            return $"Server={ServerAdress}{ServerName};Database={DataBaseName};User Id={DataBaseUser};Password={DataBasePassword};";
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}