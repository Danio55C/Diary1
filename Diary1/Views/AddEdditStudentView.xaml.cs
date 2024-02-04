using Diary1.Models;
using Diary1.Models.Wrappers;
using Diary1.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diary1.Views
{
    /// <summary>
    /// Interaction logic for AddEdditStudentView.xaml
    /// </summary>
    public partial class AddEdditStudentView : MetroWindow
    {
        public AddEdditStudentView(StudentWrapper student=null)
        {
            InitializeComponent();
            DataContext = new AddEditStudentViewModel(student);
            
        }
    }
}
