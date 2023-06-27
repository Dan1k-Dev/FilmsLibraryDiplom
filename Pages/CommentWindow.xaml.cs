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
    /// Логика взаимодействия для CommentWindow.xaml
    /// </summary>
    public partial class CommentWindow : Window
    {
        DataContext _context = new DataContext();
        public CommentWindow()
        {
            InitializeComponent();
        }

        private void Comment_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Comment.Text = "";
        }

        /// <summary>
        /// Отправление комментария
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Send_Click(object sender, RoutedEventArgs e)
        {

            var reqNick = from l in _context.logs //id юзера
                          orderby l.id descending
                          select l.idUser.ToString();
            int curID = int.Parse(reqNick.FirstOrDefault());

            var reqComment = new Comment_Film()
            {
                UserID = curID,
                FilmID = int.Parse(idF.Text),
                Comment = Comment.Text
            };
            _context.Comment_Films.Add(reqComment);
            _context.SaveChanges();
            MessageBox.Show("Комментарий отправлен!");
        }
    }
}
