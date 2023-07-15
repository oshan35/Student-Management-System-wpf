using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Personal_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Personal_Project.ViewModels
{
    public partial class EditStudentVM : ObservableObject
    {

        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public BitmapImage image;

        [ObservableProperty]
        public string dateOfBirth;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string department;

        public Action CloseAction { get; internal set; }

        public Student editedStudent;

        public EditStudentVM(Student student)
        {
            editedStudent = student;

            Firstname = student.firstname;
            Lastname = student.lastname;
            Age = student.age;
            Image = student.image;
            DateOfBirth = student.dateOfBirth;
            Department = student.department;
            Email = student.email;
            Gpa = student.gpa;
        }

        public EditStudentVM()
        {

        }

        [RelayCommand]
        public void SaveChanges()
        {
            editedStudent.firstname = Firstname;
            editedStudent.lastname = Lastname;
            editedStudent.age = Age;
            editedStudent.email = Email;
            editedStudent.image= Image;
            editedStudent.dateOfBirth = DateOfBirth;
            editedStudent.email = Email;
            editedStudent.gpa= Gpa;

            MessageBox.Show("Changes Sucessfully saved!");
        }

        [RelayCommand]
        public void EditImage()
        {
            Microsoft.Win32.OpenFileDialog d = new Microsoft.Win32.OpenFileDialog();
            d.Filter = "Image files | *.bmp; *.png; *.jpg";
            d.FilterIndex = 1;
            if (d.ShowDialog() == true)
            {
                image = new BitmapImage(new Uri(d.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }



    }
}
