using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_List_3888.Model;
using Microsoft.Win32;
using Student_List_3888;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Student_List_3888
{
    public partial class Add_UserVM : ObservableObject

    {


        [ObservableProperty]
        public BitmapImage selectedImage;

        [ObservableProperty]
        public string regno;


        [ObservableProperty]
        public string firstname;


        [ObservableProperty]
        public string lastname;

        

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public double gpa;



        



        [ObservableProperty]
        public string title;

       



        public Add_UserVM(User Person)
        {
            Student = Person;

            regno = Student.RegNo;

            selectedImage = Student.Image;

            firstname = Student.FirstName;

            lastname = Student.LastName;

            dateofbirth = Student.DateOfBirth;

            gpa = Student.GPA;

            age = Student.Age;

           

            

        }
        public Add_UserVM()
        {

        }


        
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files |  *.jpg; *.png";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }






        public User Student { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {



            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value not valid range", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Student == null)
            {

                Student = new User()
                {
                    Image = selectedImage,

                    RegNo=regno,

                    FirstName = firstname,

                    LastName = lastname,

                    Age = age,

                    DateOfBirth = dateofbirth,



                    GPA = gpa

                };


            }
            else
            {

                Student.Image = selectedImage;

                Student.RegNo =regno;

                Student.FirstName = firstname;

                Student.LastName = lastname;

                Student.Age = age;

                Student.GPA = gpa;

                

                Student.DateOfBirth = dateofbirth;



            }

            if (Student.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();


        }
    }
}
