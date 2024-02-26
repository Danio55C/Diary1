using Diary;
using Diary1.Commands;
using Diary1.Models;
using Diary1.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Diary1.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        
        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);

            ConfirmCommand = new RelayCommand(Confirm);

            //UserDatabaseSettings userSettings = new UserDatabaseSettings
            //{
            //    ServerAdress = Settings.Default.ServerAdress,
            //    ServerName = Settings.Default.ServerAdress,
            //    DataBaseName = Settings.Default.ServerAdress,
            //    DataBaseUser = Settings.Default.ServerAdress,
            //    DataBasePassword = Settings.Default.ServerAdress,
            //};


        }

        

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private UserDatabaseSettings _settings;
        
        public UserDatabaseSettings UserDatabaseSettings
        {
            get { return _settings; }
            set { 
                _settings = value;
                OnPropertChanged();
            }
        }
        private void Confirm(object obj)
        {
            UserDatabaseSettings.Save();
            
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();

            

        }

        private void Close(object obj)
        {
            throw new NotImplementedException();
        }


    }










}













