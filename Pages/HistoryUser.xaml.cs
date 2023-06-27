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
    /// Логика взаимодействия для HistoryUser.xaml
    /// </summary>
    public partial class HistoryUser : Window
    {
        DataContext _context = new DataContext();
        public HistoryUser()
        {
            InitializeComponent();
            InfoHist();
        }

        /// <summary>
        /// Вывод истории просмотров
        /// </summary>
        public void InfoHist()
        {
            var reqNick = from l in _context.logs //id юзера
                          orderby l.id descending
                          select l.idUser;
            int curID = reqNick.FirstOrDefault();

            var req = _context.Histories.Where(x => x.idUser == curID).Select(x => new
            {
                x.Date,
                FilmID = x.Film_.FilmName,
                x.CountView
            }).ToList();
            DataH.ItemsSource = req;
        }

        #region Навигация
        private void History_Click(object sender, RoutedEventArgs e)
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

        private void UserCabinet_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            if (ParamAccess.Content.ToString() == "1")
            {
                profilePage.ParamAccess.Content = "1";
                profilePage.Manage.Visibility = Visibility.Visible;
                profilePage.Show();
                this.Close();
            }
            if (ParamAccess.Content.ToString() == "2")
            {
                profilePage.ParamAccess.Content = "2";
                profilePage.Manage.Visibility = Visibility.Hidden;
                profilePage.Show();
                this.Close();
            }
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.ParamAccess.Content = "1";
            adminPage.Show();
            this.Close();
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

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            ReviewWindow review = new ReviewWindow();
            review.Show();
            MessageBox.Show("Здесь вы можете оставить свои отзыв и пожелания");
        }
        #endregion
    }
}
