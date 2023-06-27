using Frolov_Cinema.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Security.Principal;
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
    /// Логика взаимодействия для EditProfilePage.xaml
    /// </summary>
    public partial class EditProfilePage : Window
    {
        DataContext _context = new DataContext();
        public EditProfilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Okay_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();

            if (Email.Text != "" && Nickname.Text != "" && Password.Text != "") //Проверка на пустоту
            {
                //Проверка на корректность почты
                if (Email.Text.Contains('@') && Email.Text.Contains(".com") || Email.Text.Contains('@') && Email.Text.Contains(".ru"))
                {
                    string userNick = profilePage.LoginN.Text;

                    int userId = _context.Users.Where(x => x.Login.Contains(userNick)).Single().id;
                    var userRow = _context.Users.Where(t => t.id == userId).FirstOrDefault();

                    var userName = _context.Users.Where(t => t.id == userId).FirstOrDefault().Login;
                    var userPassw = _context.Users.Where(p => p.id == userId).FirstOrDefault().Password;

                    userRow.Email = Email.Text;
                    userRow.Login = Nickname.Text;

                    string sourceData1, hashData;
                    sourceData1 = Password.Text;
                    var tmpSource = UTF8Encoding.UTF8.GetBytes(sourceData1);
                    byte[] tmpHash;
                    tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                    hashData = Convert.ToBase64String(tmpHash); // пароль в хэше

                    userRow.Password = hashData;
                    _context.SaveChanges(); //Сохраняем данные

                    MessageEditGreat messageEdit = new MessageEditGreat();
                    messageEdit.Show();
                    this.Close();

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

                    EditLog();
                }
                else
                {
                    MessageBox.Show("Почта введена некорректно!");
                }
            }
            else
            {
                MessageBox.Show("Данные заполнены не полностью!");
            }
        }

        /// <summary>
        /// Меняем логин не только в таблице Users, но и в логах
        /// </summary>
        internal void EditLog()
        {
            string date = DateTime.Now.ToString("dd/M/yyyy");

            var userId = _context.Users.Where(x => x.Login == Nickname.Text).Single().id;
            var reqLog = new Logs()
            {
                idUser = userId,
                Datee = date,
            };
            _context.logs.Add(reqLog);
            _context.SaveChanges();
        }

        #region Навигация по окнам и очистка полей ввода
        private void Nickname_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Nickname.Text = "";
        }

        private void Email_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Email.Text = "";
        }

        private void Password_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Password.Text = "";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
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
        #endregion
    }
}
