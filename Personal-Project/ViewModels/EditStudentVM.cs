using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Personal_Project.Models;
using Personal_Project.Views;
using Personal_Project.Views.AlertWindows;
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

            MessageBoxWindow alert = new MessageBoxWindow("Saved!", "Edited details were saved!");
            alert.ShowDialog();

            CloseAction();
        }

        [RelayCommand]
        public void EditImage()
        {
            Microsoft.Win32.OpenFileDialog d = new Microsoft.Win32.OpenFileDialog();
            d.Filter = "Image files | *.bmp; *.png; *.jpg";
            d.FilterIndex = 1;
            if (d.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(d.FileName));

                NotifyWindow imagenotify = new NotifyWindow("Image Uploaded Sucessfully!");
                imagenotify.Show();
            }
        }



    }
}
