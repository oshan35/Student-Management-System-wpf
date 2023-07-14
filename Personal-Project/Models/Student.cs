using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Personal_Project.Models
{
    public class Student
    {

        public String firstname { get; set; }
        public String lastname { get; set; }
        public BitmapImage image { get; set; }

        public int age { get; set; }

        public string department { get; set; }
        public String dateOfBirth { get; set; }

        public String email { get; set; }
        public double gpa { get; set; }
        
        // Empty constructor 
        public Student() { }

        //Overloaded constructor
        public Student(String fname, String lname,int age, string department,BitmapImage image, String dateOfBirth, double gpa, string email)
        {
            this.firstname = fname;
            this.lastname = lname;
            this.age = age;
            this.department = department;
            this.image = image;
            this.dateOfBirth = dateOfBirth;
            this.gpa = gpa;
            this.email = email;
          
        }


    }
}
