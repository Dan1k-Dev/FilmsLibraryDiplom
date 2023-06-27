using Frolov_Cinema.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Window
    {
        DataContext _context = new DataContext();
        public ProfilePage()
        {
            InitializeComponent();

            var reqNick = from l in _context.logs //id юзера
                          orderby l.id descending
                          select l.idUser.ToString();
            string curID = reqNick.FirstOrDefault();

            var reqLogin = _context.Users.Where(x => x.id.ToString() == curID).Single().Login; //Логин
            var reqFcs = _context.Users.Where(x => x.id.ToString() == curID).Single().FCs; //ФИО
            var reqEmail = _context.Users.Where(x => x.id.ToString() == curID).Single().Email; //Почта
            var reqDateBorn = _context.Users.Where(x => x.id.ToString() == curID).Single().DateB; //Дата рождения

            LoginN.Text = $"Здравствуйте, {reqLogin}!";
            FcsN.Text = $"{reqFcs}";
            EmailAddr.Text = $"Электронная почта: \n{reqEmail}";
            DateBorn.Text = $"Дата рождения: \n{reqDateBorn}";
        }

        #region Навигация по окнам
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

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Close();
        }

        private void UserCabinet_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void Filmotech_Click(object sender, RoutedEventArgs e)
        {
            if (ParamAccess.Content.ToString() == "1")
            {
                FilmsPage filmsPage = new FilmsPage();
                filmsPage.ParamAccess.Content = "1";
                filmsPage.Manage.Visibility = Visibility.Visible;
                filmsPage.Show();
                this.Close();
            }
            if (ParamAccess.Content.ToString() == "2")
            {
                FilmsPage filmsPage = new FilmsPage();
                filmsPage.ParamAccess.Content = "2";
                filmsPage.Manage.Visibility = Visibility.Hidden;
                filmsPage.Show();
                this.Close();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ParamAccess.Content.ToString() == "1")
            {
                EditProfilePage editProfile = new EditProfilePage();
                editProfile.ParamAccess.Content = "1";
                editProfile.Show();
                this.Close();
            }
            if (ParamAccess.Content.ToString() == "2")
            {
                EditProfilePage editProfile = new EditProfilePage();
                editProfile.ParamAccess.Content = "2";
                editProfile.Show();
                this.Close();
            }
        }

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
        #endregion
    }
}
