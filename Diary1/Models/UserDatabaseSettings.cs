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
                return Settings.Default.ServerAdress = "(local)";

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
                return Settings.Default.ServerName = "SQLEXPRESS";
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
                return Settings.Default.DataBaseName = "Diary";
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
                return Settings.Default.DataBaseUser = "danielsql";
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
                return Settings.Default.DataBasePassword = "Genowefa123!";
            }
            set
            {
                Settings.Default.DataBasePassword = value;
            }
        }



    }
        
    
}



