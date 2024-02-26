using Diary1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diary1.Models
{
    public class UserDatabaseSettings
    {





        public string ServerAdress
        {
            get
            {
                return Settings.Default.ServerAdress;

            }
            set
            {
                Settings.Default.ServerAdress = value;
            }
        }
        public string ServerName
        {
            get
            {
                return Settings.Default.ServerName;
            }
            set
            {
                Settings.Default.ServerName = value;
            }

        }
        public string DataBaseName
        {
            get
            {
                return Settings.Default.DataBaseName;
            }
            set
            {
                Settings.Default.DataBaseName = value;
            }
        }



        public string DataBaseUser
        {
            get
            {
                return Settings.Default.DataBaseUser;
            }
            set
            {
                Settings.Default.DataBaseUser = value;
            }
        }
        public string DataBasePassword
        {
            get
            {
                return Settings.Default.DataBasePassword;
            }
            set
            {
                Settings.Default.DataBasePassword = value;
            }
        }

        public string GetConnectionString()
        {
            return $"Server={ServerAdress}\\{ServerName};Database={DataBaseName};User Id={DataBaseUser};Password={DataBasePassword};";
        }

        public void Save()
        {
            Settings.Default.Save();
        }


        //<add name = "ApplicationDbContext" connectionString=" Server=(local)\SQLEXPRESS;Database=Diary;User Id=sqldaniel;Password=1234;" providerName="System.Data.SqlClient" />
    }


}



