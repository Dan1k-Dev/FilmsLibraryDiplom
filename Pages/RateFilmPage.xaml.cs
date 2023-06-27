using Frolov_Cinema.Database;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для RateFilmPage.xaml
    /// </summary>
    public partial class RateFilmPage : Window
    {
        DataContext _context = new DataContext();
        public static int n = 1;
        public static int nMin = 1;
        public static int nMax = 5;
        public static int i = 1;

        public RateFilmPage()
        {
            InitializeComponent();
            RateDigital.Text = n.ToString();
        }

        private void RateDownBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(RateDigital.Text) == nMin)
            {
                RateDigital.Text = nMin.ToString();
            }
            else
            {
                i--;
                RateDigital.Text = i.ToString();
            }
        }

        private void RateUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(RateDigital.Text) == nMax)
            {
                RateDigital.Text = nMax.ToString();
            }
            else
            {
                i++;
                RateDigital.Text = i.ToString();
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Filmidd.Content = "14";
            int id = int.Parse(Filmidd.Content.ToString());

            var reqNick = from l in _context.logs //id user
                          orderby l.id descending
                          select l.idUser;
            int curID = reqNick.FirstOrDefault();

            var filmIdScores = _context.Score_Films.Select(x => x.FilmID).ToList();
            foreach (var filmsID in filmIdScores)
            {
                if (filmsID.ToString().Contains(Filmidd.Content.ToString()))
                {
                    var sumScre = _context.Score_Films.Where(x => x.FilmID == id).Single().SumScore;
                    var countScr = _context.Score_Films.Where(x => x.FilmID == id).Single().CountScore;
                    double sumRate = (double)(sumScre + double.Parse(RateDigital.Text));

                    var filmRow = _context.Score_Films.Where(t => t.FilmID == id).FirstOrDefault();
                    filmRow.Score = sumRate / countScr;
                    filmRow.SumScore = sumRate;
                    filmRow.CountScore += 1;
                    _context.SaveChanges();
                }
                else
                {
                    var sumScre = _context.Score_Films.Where(x => x.FilmID == id).Single().SumScore;
                    var countScr = _context.Score_Films.Where(x => x.FilmID == id).Single().CountScore;
                    double sumRate = (double)(sumScre + double.Parse(RateDigital.Text));

                    int n = 0;
                    var req = new Score_Film()
                    {
                        FilmID = id,
                        UserID = curID,
                        SumScore = sumRate,
                        Score = sumRate / countScr,
                        CountScore = n + 0
                    };
                    _context.Score_Films.Add(req);
                    _context.SaveChanges();
                }
            }
            OpenPageFIlm();
        }

        /// <summary>
        /// Открытие страницы фильма
        /// </summary>
        internal void OpenPageFIlm()
        {
            MoviePage lookPage = new MoviePage();

            int id = int.Parse(Filmidd.Content.ToString());
            var filmName = _context.Films.Where(x => x.id == id).Single().FilmName;

            var filmCountryID = _context.Films.Where(x => x.id == id).Single().CountryID;
            var filmCountryTitle = _context.Countries.Where(x => x.id == filmCountryID).Single().CountryName;

            var filmYear = _context.Films.Where(x => x.id == id).Single().DateStart;

            var filmGanreID = _context.Films.Where(x => x.id == id).Single().GanreID;
            var filmGanreTitle = _context.Ganre_Films.Where(x => x.id == filmGanreID).Single().GanreTitle;

            var filmRating = _context.Films.Where(x => x.id == id).Single().Rating;
            var filmAge = _context.Films.Where(x => x.id == id).Single().AgeLimit;

            var mID = _context.Films.Where(x => x.id == id).Single().MetrageID;
            var mTitle = _context.Meterages.Where(x => x.id == mID).Single().MeterageTitle;

            var catgID = _context.Films.Where(x => x.id == id).Single().CategoryID;
            var catg = _context.Category_Films.Where(x => x.id == catgID).Single().Category;

            var q = _context.Films.Where(x => x.id == id).Single().Image;

            lookPage.NameFilm.Text = filmName;
            lookPage.ImgFilm.Source = ByteToImage(q);
            lookPage.Ganree.Text = $"Жанр: {filmGanreTitle}";
            lookPage.Catg.Text = $"Категория: {catg}";
            lookPage.Countryy.Text = $"Страна: {filmCountryTitle}";
            lookPage.DateS.Text = $"Дата выхода: {filmYear}";
            lookPage.Rate.Text = $"Рейтинг: {filmRating}";
            lookPage.Age.Text = $"Возрастное ограничение: {filmAge}+";
            lookPage.Metrage.Text = $"Метраж: {mTitle}";
            lookPage.Show();
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
            BitmapImage bImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.EndInit();

            return (ImageSource)bitmap;
        }
    }
}
