using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Personal_Project.Models;
using Personal_Project.Views;
using Personal_Project.Views.AlertWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

            studentList= new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("D:\\UOR education\\SEM03\\Programming-Project\\Personal-Project\\Personal-Project\\Asserts\\1.png", UriKind.Absolute));
            studentList.Add(new Student("oshan", "nettasinghe", 23, "CE", image1, "1999-05-05", 2.72, "oshan@gmail.com"));
            BitmapImage image2 = new BitmapImage(new Uri("D:\\UOR education\\SEM03\\Programming-Project\\Personal-Project\\Personal-Project\\Asserts\\2.png", UriKind.Absolute));
            studentList.Add(new Student("Nehara", "Tharushi", 23, "CE", image2, "2000-05-05", 3.92, "nehara@gmail.com"));
            BitmapImage image3 = new BitmapImage(new Uri("D:\\UOR education\\SEM03\\Programming-Project\\Personal-Project\\Personal-Project\\Asserts\\3.png", UriKind.Absolute));
            studentList.Add(new Student("Ashen", "Nethsara", 23, "CE", image3, "1999-08-08", 3.0, "ashen@gmail.com"));


        }

        [RelayCommand]
        public void AddStudent()
        {

            var sudentRegVM = new StudentRegistrationVM();

            StudentRegistrationView studentRegistrationView = new StudentRegistrationView(sudentRegVM);
            studentRegistrationView.ShowDialog();


            if (sudentRegVM.student1 != null)
            {
                

                StudentList.Add(sudentRegVM.student1);

                
            }


        }


        [RelayCommand]
        public void Delete()
        {
            if(SelectedStudent != null)
            {
                
                string name = SelectedStudent.firstname;
                string last = SelectedStudent.lastname;

                StudentList.Remove(SelectedStudent);

                NotifyWindow notifydelete = new NotifyWindow($"{name} {last} deleted!");
                notifydelete.Show();
            }
            else
            {
                MessageBoxWindow deletealert = new MessageBoxWindow("Item Not Selected!", "Select a Student that you want to delete");
                deletealert.Show();
            }
        }


        [RelayCommand]
        public void EditStudent()
        {

            if (SelectedStudent !=null)
            {
                var editVM = new EditStudentVM(SelectedStudent);

                EditView window = new EditView(editVM);
                window.ShowDialog();

                int index = StudentList.IndexOf(SelectedStudent);

                StudentList.RemoveAt(index);
                StudentList.Insert(index, editVM.editedStudent);

              

            }
            else
            {
                MessageBoxWindow editalert = new MessageBoxWindow("Item Not Selected!", "Select a Student from Data Grid before editing");
                editalert.Show();
            }

        }




    }
}
