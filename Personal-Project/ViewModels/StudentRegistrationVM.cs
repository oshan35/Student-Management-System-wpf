using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Personal_Project.Models;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Controls;
using System.Windows;
using Microsoft.Win32;



namespace Personal_Project.ViewModels
{
    public partial class StudentRegistrationVM: ObservableObject
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

        public static Student student;

        public StudentRegistrationVM(Student student)
        {
            firstname = student.firstname;
            lastname = student.lastname;
            age = student.age;
            image = student.image;
            DateOfBirth = student.dateOfBirth;
            email = student.email;
            gpa = student.gpa;
        }


        public StudentRegistrationVM()
        {

        }

        [RelayCommand]
        public void UploadImage()
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

        [RelayCommand]
        public void addStudent()
        {
            gpa = validateGPA(gpa);
            dateOfBirth = validateDateOfBirth(dateOfBirth);
            age = validateAge(age);

            student = new Student()
            {
                firstname = Firstname,
                lastname = Lastname,
                age = Age,
                department = Department,
                image = Image,
                email = Email,
                gpa = Gpa
            };

        }

        private double validateGPA(double gpa)
        {
            if (gpa >= 0 && gpa<=4)
            {
                return gpa;
            }
            else
            {
                MessageBox.Show("Invalid GPA! GPA should be between 0 and 4.0");
            }
            return 0;
        }

        private int validateAge(int age)
        {
            if(age>0 && age < 120)
            {
                return age;
            }
            else
            {
                MessageBox.Show("Invalid Age!");
            }
            return 0;
        }

        private String validateDateOfBirth(String dob)
        {
            if (!DateTime.TryParseExact(dob, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Invalid date format. Expected format: yyyy-MM-dd");
            }
            else
            {
                return dob;
            }
            return "";
        }

    }
}
