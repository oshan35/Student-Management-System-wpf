using CommunityToolkit.Mvvm.ComponentModel;
using Personal_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Personal_Project.ViewModels
{
    public partial class UserVM:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> studentList;


        [ObservableProperty]
        public Student selectedStudent=null;

        public UserVM()
        {
            studentList = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("Asserts/image.png", UriKind.Relative));
            studentList.Add(new Student("oshan", "nettasinghe", image1, "1999-05-05", 2.72));

        }






    }
}
