using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Student_List_3888.Model
{
    public class User
    {
        public BitmapImage Image { get; set; }

        public string RegNo { get; set; }

        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        

        public string DateOfBirth { get; set; }
        public double GPA { get; set; }

        public String ImagePath
        {
            get { return $"/Image/{Image}"; }
        }

        public User(string regno,string firstName, string lastName, string dateOfBirth, int age, double gpa, BitmapImage image)
        {
            RegNo = regno ;
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = image;
            GPA = gpa;
        }

        public User()
        {
        }
    }
}
