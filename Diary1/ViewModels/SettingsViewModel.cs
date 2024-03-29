﻿using Diary;
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

            UserDatabaseSettings  = new UserDatabaseSettings
            {
                ServerAdress = Settings.Default.ServerAdress,
                ServerName = Settings.Default.ServerName,
                DataBaseName = Settings.Default.DataBaseName,
                DataBaseUser = Settings.Default.DataBaseUser,
                DataBasePassword = Settings.Default.DataBasePassword,
            };
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
            if (!UserDatabaseSettings.IsValid)
                return;
            UserDatabaseSettings.Save();
            
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {

           window.Close();
        }
    }
}
        



        


            
























