using Frolov_Cinema.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using Xceed.Wpf.Toolkit;

namespace Frolov_Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для MoviePage.xaml
    /// </summary>
    public partial class MoviePage : Window
    {
        DataContext _context = new DataContext();
        public MoviePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Просмотр фильма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LookBtn_Click(object sender, RoutedEventArgs e)
        {
            var siteFilm = _context.Films.Where(x => x.FilmName == NameFilm.Text).Single().Site;
            Process.Start(siteFilm);
            try
            {
                SendEmail();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Во время отправки сообщения на электронную почту \n" +
                    "произошла ошибка сервера");
            }
            HistoryFilm();
            LogsLooks();
        }

        public void HistoryFilm()
        {
            var reqNick = from l in _context.logs //id юзера
                          orderby l.id descending
                          select l.idUser;
            int curID = reqNick.FirstOrDefault();

            var hist = _context.Histories.Where(x => x.idUser == curID).Select(x => x.id).ToList();
            foreach (var h in hist)
            {
                var film = _context.Histories.Where(x => x.id == h).Single().CountView;

                if (film >= 1)
                {
                    var histRow = _context.Histories.Where(x => x.id == h).FirstOrDefault();
                    int n = 0;
                    histRow.Date = DateTime.Now.ToString("dd/M/yyyy");
                    histRow.CountView = n + 1;
                    _context.SaveChanges();
                }
                if (film < 1)
                {
                    int n = 0;
                    var req = new History()
                    {
                        Date = DateTime.Now.ToString("dd/M/yyyy"),
                        FilmID = h,
                        idUser = curID,
                        CountView = n + 1
                    };
                    _context.Histories.Add(req);
                    _context.SaveChanges();
                }
            }
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
            message.To.Add(new MailAddress(mailUser));
            message.Subject = "Kinolenta";
            message.Body = $"Здравствуйте, {name}!\n" +
                $"Сегодня ({date}) вы посмотрели фильм {NameFilm.Text}. Как бы вы его оценили?\n" +
                $"Вы можете оставить свой отзыв в комментариях к фильму. Для этого необходимо:\n" +
                $"1. Открыть страницу фильма\n" +
                $"2. Нажать кнопку +Комментарий\n" +
                $"3. Ввести комментарий и нажать отправить\n" +
                $"Своим комментарием вы сможете помочь нам улучшить фильмотеку. Заранее приносим вам свои благодарности";
            client.Send(message);
        }

        /// <summary>
        /// Просмотр комментариев к фильму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommsLook_Click(object sender, RoutedEventArgs e)
        {
            LooksCommentsPage looksCommentsPage = new LooksCommentsPage();
            var fId = _context.Films.Where(x => x.FilmName == NameFilm.Text).Single().id;
            var commID = _context.Comment_Films.Where(x => x.FilmID == fId).Select(x => x.id).ToList();
            var coms = commID.Distinct();
            foreach (var coment in coms)
            {
                var comm = _context.Comment_Films.Where(x => x.id == coment).Single().Comment;
                var uID = _context.Comment_Films.Where(x => x.id == coment).Single().UserID;
                var userName = _context.Users.Where(x => x.id == uID).Single().Login;
                looksCommentsPage.CommsSlb.Items.Add(looksCommentsPage.Comms.Text = $"{userName}\nКомментарий: {comm}");
            }
            looksCommentsPage.Show();
        }

        /// <summary>
        /// Оставить комментарий к фильму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Comm_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow comment = new CommentWindow();
            var filmid = _context.Films.Where(x => x.FilmName == NameFilm.Text).Single().id;
            comment.idF.Text = filmid.ToString();
            comment.Show();
        }

        /// <summary>
        /// Запись логов для истории просмотра
        /// </summary>
        public void LogsLooks()
        {
            var reqNick = from l in _context.logs //id юзера
                          orderby l.id descending
                          select l.idUser.ToString();
            string curID = reqNick.FirstOrDefault();
            var filmId = _context.Films.Where(x => x.FilmName == NameFilm.Text).Single().id;

            int n = 0;
            string date = DateTime.Now.ToString("dd/M/yyyy");

            var req = new History()
            {
                idUser = int.Parse(curID),
                Date = date,
                FilmID = filmId,
                CountView = n + 1
            };
            _context.Histories.Add(req);
            _context.SaveChanges();
        }

        private void RateFilm_Click(object sender, RoutedEventArgs e)
        {
            string filmN = NameFilm.Text;
            var fId = _context.Films.Where(x => x.FilmName == filmN).Single().id;
            RateFilmPage rateFilm = new RateFilmPage();
            rateFilm.Filmidd.Content = fId.ToString();
            rateFilm.Show();
            this.Close();
        }
    }
}
