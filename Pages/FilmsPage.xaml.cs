using Frolov_Cinema.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

namespace Frolov_Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для FilmsPage.xaml
    /// </summary>
    public partial class FilmsPage : Window
    {
        static DataContext _context = new DataContext();
        public FilmsPage()
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
        /// Вывод информации о фильме
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
        /// Конвертирование байтов изображения в растровую картинку
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        static ImageSource ByteToImage(byte[] imageData)
        {
            var bitmap = new BitmapImage();
            BitmapImage bImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            return (ImageSource)bitmap;
        }

        #region Навигация по окнам
        private void Filmotech_Click(object sender, RoutedEventArgs e)
        {
            //todo
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

        private void SearchBar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SearchBar.Text = "";
        }

        private void CatgCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CatgCb.Text = CatgCb.SelectedItem.ToString();
            SortedCatg();
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
        /// Просмотр страницы фильма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilmsLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoviePage lookPage = new MoviePage();

            ListBoxItem lbi = (ListBoxItem)this.FilmsLB.ItemContainerGenerator.ContainerFromItem(FilmsLB.SelectedItem);
            TextBlock tbActive = FindFirstElementInVisualTree<TextBlock>(lbi);
            tbActive.Text.ToString();
            string filmN = tbActive.Text.Substring(0, tbActive.Text.IndexOf('|'));

            lookPage.NameFilm.Text = filmN;

            var filmName = _context.Films.Where(x => x.FilmName == filmN).Single().id;

            var filmCountryID = _context.Films.Where(x => x.id == filmName).Single().CountryID;
            var filmCountryTitle = _context.Countries.Where(x => x.id == filmCountryID).Single().CountryName;

            var filmYear = _context.Films.Where(x => x.id == filmName).Single().DateStart;

            var filmGanreID = _context.Films.Where(x => x.id == filmName).Single().GanreID;
            var filmGanreTitle = _context.Ganre_Films.Where(x => x.id == filmGanreID).Single().GanreTitle;

            var filmRating = _context.Films.Where(x => x.id == filmName).Single().Rating;
            var filmAge = _context.Films.Where(x => x.id == filmName).Single().AgeLimit;

            var mID = _context.Films.Where(x => x.id == filmName).Single().MetrageID;
            var mTitle = _context.Meterages.Where(x => x.id == mID).Single().MeterageTitle;

            var catgID = _context.Films.Where(x => x.id == filmName).Single().CategoryID;
            var catg = _context.Category_Films.Where(x => x.id == catgID).Single().Category;

            var q = _context.Films.Where(x => x.FilmName == filmN).Single().Image;
            lookPage.ImgFilm.Source = ByteToImage(q);
            lookPage.Ganree.Text = $"Жанр: {filmGanreTitle}";
            lookPage.Catg.Text = $"Категория: {catg}";
            lookPage.Countryy.Text = $"Страна: {filmCountryTitle}";
            lookPage.DateS.Text = $"Дата выхода: {filmYear}";
            lookPage.Rate.Text = $"Рейтинг: {filmRating}";
            lookPage.Age.Text = $"Возрастное ограничение: {filmAge}+";
            lookPage.Metrage.Text = $"Метраж: {mTitle}";
            lookPage.Show();
        }

        /// <summary>
        /// Поиск фильма по названию
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
