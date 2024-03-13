using Diary1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diary1.Models
{
    public class UserDatabaseSettings : IDataErrorInfo
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


        

        //<add name = "ApplicationDbContext" connectionString=" Server=(local)\SQLEXPRESS;Database=Diary;User Id=sqldaniel;Password=1234;" providerName="System.Data.SqlClient" />
        private bool _isServerAdressValid;
        private bool _isServerNameValid;
        private bool _isDatabaseNameValid;
        private bool _isDataBaseUserValid;
        private bool _isDataBasePasswordValid;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ServerAdress):
                        if (string.IsNullOrWhiteSpace(ServerAdress))
                        {
                            Error = "Pole jest wymagane";
                            _isServerAdressValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isServerAdressValid = true;
                        }

                        break;
                    case nameof(ServerName):
                        if (string.IsNullOrWhiteSpace(ServerName))
                        {
                            Error = "Pole jest wymagane";
                            _isServerNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isServerNameValid = true;
                        }

                        break;

                    case nameof(DataBaseName):
                        if (string.IsNullOrWhiteSpace(DataBaseName))
                        {
                            Error = "Pole jest wymagane";
                            _isDatabaseNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDatabaseNameValid = true;
                        }

                        break;

                    case nameof(DataBaseUser):
                        if (string.IsNullOrWhiteSpace(DataBaseUser))
                        {
                            Error = "Pole jest wymagane";
                            _isDataBaseUserValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBaseUserValid = true;
                        }

                        break;

                    case nameof(DataBasePassword):
                        if (string.IsNullOrWhiteSpace(DataBasePassword))
                        {
                            Error = "Pole jest wymagane";
                            _isDataBasePasswordValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isDataBasePasswordValid = true;
                        }

                        break;
                    default:
                        break;
                }
                return Error;
            }
        }
        public string Error { get; set; }
        public bool IsValid
        {
            get
            {
                return _isServerAdressValid &&
                    _isServerNameValid &&
                    _isDatabaseNameValid &&
                    _isDataBaseUserValid &&
                    _isDataBasePasswordValid;

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

    }
}
















