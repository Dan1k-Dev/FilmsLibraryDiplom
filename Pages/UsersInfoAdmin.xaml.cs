using Frolov_Cinema.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для UsersInfoAdmin.xaml
    /// </summary>
    public partial class UsersInfoAdmin : Window
    {
        DataContext _context = new DataContext(); 
        public UsersInfoAdmin()
        {
            InitializeComponent();

            var query = _context.Users.Select(x => new
            {
                x.FCs,
                x.Email,
                x.Login,
                x.DateB,
                Access = x.Access_.KeyAccess
            }).ToList();
            DgInfo.ItemsSource = query;
        }

        #region Навигация по окнам
        private void Filmotech_Click(object sender, RoutedEventArgs e)
        {
            ParamAccess.Content = "1";
            FilmsPage films = new FilmsPage();
            films.ParamAccess.Content = "1";
            films.Manage.Visibility = Visibility.Visible;
            films.Show();
            this.Close();
        }

        private void UserCabinet_Click(object sender, RoutedEventArgs e)
        {
            ParamAccess.Content = "1";
            ProfilePage userCabinet = new ProfilePage();
            userCabinet.ParamAccess.Content = "1";
            userCabinet.Manage.Visibility = Visibility.Visible;
            userCabinet.Show();
            this.Close();
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
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

        /// <summary>
        /// Назначение администратором пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminSet_Click(object sender, RoutedEventArgs e)
        {
            if (DgInfo.SelectedItem != null)
            {
                string textName = DgInfo.SelectedItem.ToString().Substring(8);
                string NameUser = textName.Substring(0, textName.IndexOf(','));

                int userId = _context.Users.Where(x => x.FCs.Contains(NameUser)).Single().id;
                var userRow = _context.Users.Where(t => t.id == userId).FirstOrDefault();

                userRow.AccessID = 1;
                _context.SaveChanges();

               MessageEditAccess messageEdit = new MessageEditAccess();
                messageEdit.Show();
                this.Close();
            }
            else { MessageBox.Show("Не выбран ни один пользователь!"); }
        }
    }
}
