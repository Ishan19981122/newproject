using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_List_3888.Model;
using Student_List_3888;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Student_List_3888
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser = null;

        

        //*****************************output main window***********************

        public MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Image/2.png", UriKind.Relative));
            users.Add(new User("EG/2020/3888","Ishan", "Devinda", "22/11/1998", 24, 1, image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Image/7.png", UriKind.Relative));
            users.Add(new User("EG/2020/3889", "Emily", "D'Attilio", "2/05/2000", 22, 2, image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Image/1.png", UriKind.Relative));
            users.Add(new User("EG/2020/3898", "Tom", "Brown", "02/5/2005", 40, 3, image3));
            BitmapImage image4 = new BitmapImage(new Uri("/Image/6.png", UriKind.Relative));
            users.Add(new User("EG/2020/4000", "Anne", "Black", "1/8/2003", 30, 3.5, image4));
            BitmapImage image5 = new BitmapImage(new Uri("/Image/4.png", UriKind.Relative));
            users.Add(new User("EG/2020/3988", "Jimmy", "White", "22/10/1995", 15, 2.5, image5));
            BitmapImage image6 = new BitmapImage(new Uri("/Image/3.png", UriKind.Relative));
            users.Add(new User("EG/2020/4100", "Ann", "Pink", "2/10/1996", 18, 1.5, image6));
            BitmapImage image7 = new BitmapImage(new Uri("/Image/8.png", UriKind.Relative));
            users.Add(new User("EG/2020/4200", "Tim", "Blue", "22/10/1999", 16, 1, image7));
            BitmapImage image8 = new BitmapImage(new Uri("/Image/9.png", UriKind.Relative));
            users.Add(new User("EG/2020/4150", "Jimmyii", "White", "22/10/1995", 60, 2, image8));
            BitmapImage image9 = new BitmapImage(new Uri("/Image/10.png", UriKind.Relative));
            users.Add(new User("EG/2020/4160", "Annii", "Pink", "2/10/1996", 12, 3, image9));
            BitmapImage image10 = new BitmapImage(new Uri("/Image/5.png", UriKind.Relative));
            users.Add(new User("EG/2020/4170", "Jimmy", "White", "22/10/2010", 20, 4, image10));


        }



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }



        //******************Addstudent*************************************
       

        [RelayCommand]
        public void AddStudent()
        {
            var Adding = new Add_UserVM();
            Adding.title = "New USER ADD";
            Add_User_Window window = new Add_User_Window(Adding);
            window.ShowDialog();

            if (Adding.Student.FirstName != null)
            {
                users.Add(Adding.Student);
            }
        }


        //******************************DeleteStudent***********************************

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show( "  Successfuly........"," congrats", MessageBoxButton.OK,MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error",MessageBoxButton.OK,MessageBoxImage.Error);


            }
        }



        [RelayCommand]
        public void Alert()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value not valid range", "GPA Error..........",MessageBoxButton.OK,MessageBoxImage.Error);
        }




        //************************EditStdudent*******************************

        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var Editing = new Add_UserVM(selectedUser);
                Editing.title = " USER DETAILS EDIT";
                var window = new Add_User_Window(Editing);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, Editing.Student);



            }
            else
            {
                MessageBox.Show("student Select the first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}