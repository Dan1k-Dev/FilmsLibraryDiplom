using Frolov_Cinema.Database;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.WebRequestMethods;

namespace Frolov_Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для OperationFilmsAdmin.xaml
    /// </summary>
    public partial class OperationFilmsAdmin : Window
    {
        DataContext _context = new DataContext();
        public OperationFilmsAdmin()
        {
            InitializeComponent();

            var reqCatgCb = _context.Category_Films.Select(x => x.Category).ToList(); //Категории
            foreach (var catg in reqCatgCb)
            {
                CatgCb.Items.Add(catg);
                CatgCb.SelectedIndex = 3;
            }
        }

        /// <summary>
        /// Информация о фильме
        /// </summary>
        public void InfoFilm()
        {
            var reqNick = from l in _context.logs //id юзера
                          orderby l.id descending
                          select l.idUser;
            int curID = reqNick.FirstOrDefault();

            var dateStr = _context.Users.Where(x => x.id == curID).Single().DateB; //Дата рождения юзера
            DateTime someDate = DateTime.Parse(dateStr);
            int diff = DateTime.Now.Year - someDate.Year; //Разница в годах между сегодняшней датой и датой пользователя

            var fID = _context.Films.Where(x => x.AgeLimit <= diff).Select(x => x.id).ToList(); //Находим фильмы с учтом возрастной категории
            var fidgr = fID.Distinct();

            List<ClassGetData> list = new List<ClassGetData>();

            foreach (var f in fidgr)
            {
                var filmName = _context.Films.Where(x => x.id == f).Single().FilmName;

                var filmCountryID = _context.Films.Where(x => x.id == f).Single().CountryID;
                var filmCountryTitle = _context.Countries.Where(x => x.id == filmCountryID).Single().CountryName;

                var filmYear = _context.Films.Where(x => x.id == f).Single().DateStart;

                var filmGanreID = _context.Films.Where(x => x.id == f).Single().GanreID;
                var filmGanreTitle = _context.Ganre_Films.Where(x => x.id == filmGanreID).Single().GanreTitle;

                var filmRating = _context.Films.Where(x => x.id == f).Single().Rating;

                var filmCatg = _context.Films.Where(x => x.id == f).Single().CategoryID;
                var catg = _context.Category_Films.Where(x => x.id == filmCatg).Single().Category;

                var img = _context.Films.Where(x => x.id == f).Single().Image;

                var IMAGEGET = ByteToImage(img);
                var TEXTGET = string.Format("{0} | {1} \n{2}| {3}| {4}\n", filmName, catg, filmRating, filmCountryTitle, filmGanreTitle, filmYear);

                list.Add(new ClassGetData { Imagge = IMAGEGET, Name = TEXTGET });
            }
            FilmsLB.ItemsSource = list;
        }

        /// <summary>
        /// Получение дочернего элемента из DataTemplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parentElement"></param>
        /// <returns></returns>
        private T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0)
                return null;

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);

                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindFirstElementInVisualTree<T>(child);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        /// <summary>
        /// Редактирование фильма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilmsLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditFilmPage editFilmPage = new EditFilmPage();

            string nameFilm = FilmsLB.SelectedItem.ToString();
            ListBoxItem lbi = (ListBoxItem)this.FilmsLB.ItemContainerGenerator.ContainerFromItem(FilmsLB.SelectedItem);
            TextBlock tbActive = FindFirstElementInVisualTree<TextBlock>(lbi);
            tbActive.Text.ToString();
            string nameF = tbActive.Text.Substring(0, tbActive.Text.IndexOf('|'));

            var q = _context.Films.Where(x => x.FilmName == nameF).Single().Image;
            editFilmPage.phto.Source = ByteToImage(q);
            editFilmPage.asdd.Content = nameF;

            editFilmPage.Show();
            this.Close();
        }

        /// <summary>
        /// Конвертирование байтов изображения в растровую картинку
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        static ImageSource ByteToImage(byte[] imageData)
        {
            var bitmap = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            return (ImageSource)bitmap;
        }

        #region Навигация по окнам
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

        /// <summary>
        /// Добавление нового фильма в фильмотеку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFilm_Click(object sender, RoutedEventArgs e)
        {
            AddFilmPage addFilm = new AddFilmPage();
            addFilm.ParamAccess.Content = "1";
            addFilm.Show();
            this.Close();
        }

        private void CatgCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CatgCb.Text = CatgCb.SelectedItem.ToString();
            SortedCatg();
        }

        private void SearchBar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SearchBar.Text = "";
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
        /// Удаление фильма из фильмотеки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelFilm_Click(object sender, RoutedEventArgs e)
        {
            string nameFilm = FilmsLB.SelectedItem.ToString();
            ListBoxItem lbi = (ListBoxItem)this.FilmsLB.ItemContainerGenerator.ContainerFromItem(FilmsLB.SelectedItem);
            TextBlock tbActive = FindFirstElementInVisualTree<TextBlock>(lbi);
            tbActive.Text.ToString();
            string reqFilm = tbActive.Text.Substring(0, tbActive.Text.IndexOf('|'));

            var reqFID = _context.Films.Where(x => x.FilmName == reqFilm).Single().id;

            var reqFilmID = from f in _context.Films
                            where f.id == reqFID
                            select f.id;
            var reqCurFilm = reqFilmID.FirstOrDefault();

            var filmToRemove = _context.Films.SingleOrDefault(x => x.id == reqCurFilm); 
            if (filmToRemove != null)
            {
                MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить этот фильм?", "", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    _context.Films.Remove(filmToRemove);
                    _context.SaveChanges();

                    MessageDelGreat messageDelGreat = new MessageDelGreat();
                    messageDelGreat.Show();
                    this.Close();
                }
                if (res == MessageBoxResult.No) { }
            }
            else
            {
                MessageBox.Show("Не был выбран ни один фильм!");
            }
        }

        /// <summary>
        /// Поиск по названию фильма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            InfoFilm();
            var filmName = _context.Films.Select(x => x.FilmName).ToList();
            if (!string.IsNullOrWhiteSpace(SearchBar.Text))
            {
                filmName = filmName.Where(x => x.ToLower().Contains(SearchBar.Text.ToLower())).ToList();

                var reqNick = from l in _context.logs //id юзера
                              orderby l.id descending
                              select l.idUser;
                int curID = reqNick.FirstOrDefault();

                var dateStr = _context.Users.Where(x => x.id == curID).Single().DateB;
                DateTime someDate = DateTime.Parse(dateStr);
                int diff = DateTime.Now.Year - someDate.Year;

                List<ClassGetData> list = new List<ClassGetData>();

                foreach (var f in filmName)
                {
                    var reqFilm = from g in _context.Films
                                  where g.FilmName == f
                                  where g.AgeLimit <= diff
                                  select g.id;
                    int[] films = reqFilm.ToArray();

                    foreach (var film in films)
                    {
                        var filmN = _context.Films.Where(x => x.id == film).Single().FilmName;

                        var filmCountryID = _context.Films.Where(x => x.id == film).Single().CountryID;
                        var filmCountryTitle = _context.Countries.Where(x => x.id == filmCountryID).Single().CountryName;

                        var filmYear = _context.Films.Where(x => x.id == film).Single().DateStart;

                        var filmGanreID = _context.Films.Where(x => x.id == film).Single().GanreID;
                        var filmGanreTitle = _context.Ganre_Films.Where(x => x.id == filmGanreID).Single().GanreTitle;

                        var filmRating = _context.Films.Where(x => x.id == film).Single().Rating;

                        var filmCatg = _context.Films.Where(x => x.id == film).Single().CategoryID;
                        var catg = _context.Category_Films.Where(x => x.id == filmCatg).Single().Category;

                        var img = _context.Films.Where(x => x.id == film).Single().Image;
                        var IMAGEGET = ByteToImage(img);
                        var TEXTGET = string.Format("{0} | {1} \n{2}| {3}| {4}\n", filmN, catg, filmRating, filmCountryTitle, filmGanreTitle, filmYear);

                        list.Add(new ClassGetData { Imagge = IMAGEGET, Name = TEXTGET });
                        FilmsLB.ItemsSource = list.ToList();
                    }
                }
            }
            if (FilmsLB.Items.Count == 0) { MessageBox.Show("Поиск не дал результатов"); }
        }

        /// <summary>
        /// Сортировка по категориям
        /// </summary>
        public void SortedCatg()
        {
            var reqNick = from l in _context.logs //id юзера
                          orderby l.id descending
                          select l.idUser;
            int curID = reqNick.FirstOrDefault();
            var dateStr = _context.Users.Where(x => x.id == curID).Single().DateB;
            DateTime someDate = DateTime.Parse(dateStr);
            int diff = DateTime.Now.Year - someDate.Year;

            if (CatgCb.SelectedItem.ToString() == "Все")
            {
                InfoFilm();
            }
            else
            {
                var reqCatgID = _context.Category_Films.Where(x => x.Category == CatgCb.Text).Single().id;
                var reqFilm = from g in _context.Films
                              where g.CategoryID == reqCatgID
                              where g.AgeLimit <= diff
                              select g.id;
                int[] films = reqFilm.ToArray();

                List<ClassGetData> list = new List<ClassGetData>();

                foreach (var film in films)
                {
                    var filmN = _context.Films.Where(x => x.id == film).Single().FilmName;

                    var filmCountryID = _context.Films.Where(x => x.id == film).Single().CountryID;
                    var filmCountryTitle = _context.Countries.Where(x => x.id == filmCountryID).Single().CountryName;

                    var filmYear = _context.Films.Where(x => x.id == film).Single().DateStart;

                    var filmGanreID = _context.Films.Where(x => x.id == film).Single().GanreID;
                    var filmGanreTitle = _context.Ganre_Films.Where(x => x.id == filmGanreID).Single().GanreTitle;

                    var filmRating = _context.Films.Where(x => x.id == film).Single().Rating;

                    var filmCatg = _context.Films.Where(x => x.id == film).Single().CategoryID;
                    var catg = _context.Category_Films.Where(x => x.id == filmCatg).Single().Category;

                    var img = _context.Films.Where(x => x.id == film).Single().Image;

                    var IMAGEGET = ByteToImage(img);
                    var TEXTGET = string.Format("{0} | {1} \n{2}| {3}| {4}\n", filmN, catg, filmRating, filmCountryTitle, filmGanreTitle, filmYear);

                    list.Add(new ClassGetData { Imagge = IMAGEGET, Name = TEXTGET });
                }
                FilmsLB.ItemsSource = list;
            }
        }
    }
}
