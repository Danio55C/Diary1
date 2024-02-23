using Diary;
using Diary1.Commands;
using Diary1.Models;
using Diary1.Models.Domains;
using Diary1.Models.Wrappers;
using Diary1.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;


namespace Diary1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public MainViewModel()
        {
            //using (var context = new ApplicationDbContext())
            //{
            //    var students = context.Students.ToList();
            //}

            AddStudentCommand = new RelayCommand(AddEdditStudent);
            EdditStudentCommand = new RelayCommand(AddEdditStudent, CanEditDeleteStudent);
            DeleteStudentCommand = new AsyncRelayCommand(DeleteStudent, CanEditDeleteStudent);
            RefreshStudentsCommand = new RelayCommand(RefreshStudents);
            EdditSettingsCommand = new RelayCommand(EdditSetings);
            RefreshDiary();
            InitGroups();
        }

        private void EdditSetings(object obj)
        {
            Settings settingsWindow = new Settings();
            settingsWindow.ShowDialog();

        }

        public ICommand AddStudentCommand { get; set; }
        public ICommand EdditStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand RefreshStudentsCommand { get; set; }
        public ICommand EdditSettingsCommand { get; set; }




        private StudentWrapper _selectedStudent;

        public StudentWrapper SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertChanged();
            }
        }

        private ObservableCollection<StudentWrapper> _students;

        public ObservableCollection<StudentWrapper> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertChanged();
            }
        }

        private int _selectedGroupId;

        public int SelectedGroupId
        {
            get { return _selectedGroupId; }
            set
            {
                _selectedGroupId = value;
                OnPropertChanged();
            }
        }

        private ObservableCollection<Group> _group;

        public ObservableCollection<Group> Groups
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertChanged();
            }
        }



        private void RefreshStudents(object obj)
        {
            RefreshDiary();
        }

        private bool CanEditDeleteStudent(object obj)
        {
            return SelectedStudent != null;
        }

        private async Task DeleteStudent(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync(
                "Usuwanie ucznia",
                $"Czy na pewno chcesz usunąć ucznia {SelectedStudent.FirstName} {SelectedStudent.LastName}?",
                MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
                return;

            _repository.DeleteStudent(SelectedStudent.Id);

            RefreshDiary();
        }



        private void AddEdditStudent(object obj)
        {
            var addEditStudentWindow = new AddEdditStudentView(obj as StudentWrapper);
            addEditStudentWindow.Closed += AddEditStudentWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }

        private void AddEditStudentWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private void RefreshDiary()
        {
                Students = new ObservableCollection<StudentWrapper>(
                _repository.GetStudents(SelectedGroupId));
        }

        private void InitGroups()
        {
            var groups = _repository.GetGroups();
            groups.Insert(0, new Group { Id = 0, Name = "Wszystkie" });
            Groups = new ObservableCollection<Group>(groups);

            SelectedGroupId = 0;
        }
    }
}
