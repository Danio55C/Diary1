using Diary1.Models;
using Diary1.Models.Configurations;
using Diary1.Models.Domains;
using Diary1.Models.Wrappers;
using Diary1.Properties;
using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime;

namespace Diary1
{
    public class ApplicationDbContext : DbContext
    {

        

        public ApplicationDbContext()
            : base(CreateSettings().GetConnectionString())
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rating> Ratings { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
        }


        private static UserDatabaseSettings CreateSettings()
        {
            UserDatabaseSettings databaseSettings = new UserDatabaseSettings();
            //databaseSettings.ServerAdress;
            //databaseSettings.ServerName;
            //databaseSettings.DataBaseName;
            //databaseSettings.DataBaseUser;
            //databaseSettings.DataBasePassword; 
            return databaseSettings;
        }

        
    }

    //public UserDatabaseSettings settings = new UserDatabaseSettings
    //{
    //    ServerAdress = "(local)",
    //    ServerName = "SQLEXPRESS",
    //    DataBaseName = "Diary",
    //    DataBaseUser = "danielsql",
    //    DataBasePassword = "Genowefa123!"
    //};







}



    

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
