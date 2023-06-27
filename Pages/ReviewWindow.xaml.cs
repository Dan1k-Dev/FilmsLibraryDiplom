using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using Frolov_Cinema.Database;

namespace Frolov_Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReviewWindow.xaml
    /// </summary>
    public partial class ReviewWindow : Window
    {
        DataContext _context = new DataContext();
        public ReviewWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отправка сообщения на электронную почту
        /// </summary>
        public void SendEmail()
        {
            var reqNick = from l in _context.logs //id юзера
                          orderby l.id descending
                          select l.idUser;
            int curID = reqNick.FirstOrDefault();

            var user = _context.Users.Where(x => x.id == curID).Single().FCs;
            string name = user.Substring(0, user.IndexOf(' '));
            var mailUser = _context.Users.Where(x => x.id == curID).Single().Email;

            string date = DateTime.Now.ToString("dd/M/yyyy");

            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("Dev1lq1@yandex.ru", "nhupnfpmlbrqqtjq");
            client.Host = "smtp.yandex.ru";
            client.Port = 587;
            client.EnableSsl = true;
            MailMessage message = new MailMessage();
            message.From = new MailAddress("Dev1lq1@yandex.ru");
            message.To.Add(new MailAddress("itsforother209@gmail.com"));
            message.Subject = $"Сообщение пользователя {name} от {date}";
            message.Body = Comment.Text;
            client.Send(message);
        }

        private void Comment_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Comment.Text = "";
        }

        /// <summary>
        /// Логика взаимодействия метода SendEmail с событием нажатия на кнопку "Отправить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (Comment.Text != "")
            {
                try
                {
                    SendEmail();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Ошибка сервера, попробуйте совершить запрос позже");
                }
            }
            else
            {
                MessageBox.Show("Поле отзыва не должно быть пустым!");
            }
        }
    }
}
