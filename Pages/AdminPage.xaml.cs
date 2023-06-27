using Frolov_Cinema.Database;
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

namespace Frolov_Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        DataContext _context = new DataContext();
        public AdminPage()
        {
            InitializeComponent();
        }

        #region Навигация по окнам
        private void Filmotech_Click(object sender, RoutedEventArgs e)
        {       
            ParamAccess.Content = "1";
            FilmsPage films = new FilmsPage();
            films.ParamAccess.Content= "1";
            films.Manage.Visibility= Visibility.Visible;
            films.Show();
            this.Close();
        }

        private void UserCabinet_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.ParamAccess.Content= "1";
            profilePage.Manage.Visibility = Visibility.Visible;
            profilePage.Show();
            this.Close();
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите выйти из системы?", "", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            if (res == MessageBoxResult.No)
            {
                //todo
            }
        }

        private void ManageFilms_Click(object sender, RoutedEventArgs e)
        {
            OperationFilmsAdmin operationFilms = new OperationFilmsAdmin();
            operationFilms.ParamAccess.Content= "1";
            operationFilms.Show();
            this.Close();
        }

        private void UsersInfo_Click(object sender, RoutedEventArgs e)
        {
            UsersInfoAdmin usersInfo = new UsersInfoAdmin();
            usersInfo.ParamAccess.Content = "1";
            usersInfo.Show();
            this.Close();
        }

        private void FilmsReports_Click(object sender, RoutedEventArgs e)
        {
            ReportsAdminPage reportsAdmin = new ReportsAdminPage();
            reportsAdmin.Show();
        }
        #endregion

        private void History_Click(object sender, RoutedEventArgs e)
        {
            HistoryUser history = new HistoryUser();
            if (ParamAccess.Content.ToString() == "1")
            {
                history.ParamAccess.Content = "1";
                history.Manage.Visibility = Visibility.Visible;
                history.Show();
                this.Close();
            }
            if (ParamAccess.Content.ToString() == "2")
            {
                history.ParamAccess.Content = "2";
                history.Manage.Visibility = Visibility.Hidden;
                history.Show();
                this.Close();
            }
        }

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            ReviewWindow review = new ReviewWindow();
            review.Show();
            MessageBox.Show("Здесь вы можете оставить свои отзыв и пожелания");
        }
    }
}
