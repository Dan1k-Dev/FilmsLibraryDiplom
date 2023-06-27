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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Frolov_Cinema.Pages;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;
using System.Net.Mail;
using System.Net;
using MimeKit;
using System.IO;

namespace Frolov_Cinema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataContext _context = new DataContext();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Авторизация в системе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            var userLogin = Login.Text;
            var userPassw = Passw.Password;

            string sourceData1, hashData;
            sourceData1 = userPassw;
            var tmpSource = UTF8Encoding.UTF8.GetBytes(sourceData1);
            byte[] tmpHash;
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            hashData = Convert.ToBase64String(tmpHash); // пароль в хэше

            var dataLogin = _context.Users.Where(l => l.Login == userLogin).FirstOrDefault();
            var dataPassw = _context.Users.Where(p => p.Password == hashData).FirstOrDefault();

            if (dataLogin != null && dataPassw != null)
            {
                if (Login.Text == dataLogin.Login && hashData == dataPassw.Password)
                {
                    if (dataLogin.AccessID == 1)
                    {
                        RecLog();
                        WaitServerResponse serverResponse = new WaitServerResponse();
                        serverResponse.ParamAccess.Content = "1";
                        serverResponse.Show();
                        this.Close();
                    }
                    if (dataLogin.AccessID == 2)
                    {
                        RecLog();
                        WaitServerResponse serverResponse = new WaitServerResponse();
                        serverResponse.ParamAccess.Content = "2";
                        serverResponse.Show();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Такого пользователя не существует!");
            }
            else
                MessageBox.Show("Данные заполнены не полностью!");
        }

        #region Навигация и очистка полей ввода
        private void RegShow_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
            this.Close();
        }

        private void Passw_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Passw.Password = "";
        }

        private void Login_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Login.Text = "";
        }
        #endregion

        /// <summary>
        /// Сохранение логов
        /// </summary>
        internal void RecLog()
        {
            var userLogId = _context.Users.Where(x => x.Login == Login.Text).Single().id;
            string date = DateTime.Now.ToString("dd.M.yyyy");

            var req = new Logs()
            {
                idUser = userLogId,
                Datee = date
            };
            _context.logs.Add(req);
            _context.SaveChanges();
        }
    }
}
