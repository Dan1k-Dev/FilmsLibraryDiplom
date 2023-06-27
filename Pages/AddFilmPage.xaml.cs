using Frolov_Cinema.Database;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для AddFilmPage.xaml
    /// </summary>
    public partial class AddFilmPage : Window
    {
        DataContext _context = new DataContext();
        public AddFilmPage()
        {
            InitializeComponent();
            CbInfo();
        }

        /// <summary>
        /// Заполнение combobox данными
        /// </summary>
        public void CbInfo()
        {
            var reqCatgCb = from c in _context.Category_Films
                            where c.Category != "Все"
                            select c.Category.ToString();//Категории
            foreach (var catg in reqCatgCb)
            {
                CategoryCB.Items.Add(catg);
            }

            var reqMetragCb = _context.Meterages.Select(x => x.MeterageTitle).ToList(); //Метражи
            foreach (var metrag in reqMetragCb)
            {
                MetrageCb.Items.Add(metrag);
            }
        }

        /// <summary>
        /// Открытие диалогового окна для выбора фотографии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opF = new OpenFileDialog();
            opF.Title = "Выберите картинку..";
            opF.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (opF.ShowDialog() == true)
            {
                phto.Source = new BitmapImage(new Uri(opF.FileName));
                byte[] image_bytes = File.ReadAllBytes(opF.FileName);
                bytesPict.Content = image_bytes;
            }
        }

        /// <summary>
        /// Добавление фильма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SiteTb.Text != "" && FilmNameTB.Text != "" && DateTb.Text != "" && DirectorTb.Text != "" && CountryTB.Text != ""
                && CategoryCB.Text != "" && AgeLimitCb.Text != "" && GanreTB.Text != "" && MetrageCb.Text != "")
            {
                if (DateTb.IsMaskFull)
                {
                    if (bytesPict.Content.ToString() != "")
                    {
                        AddRecordsNewData();
                        Thread.Sleep(200);
                        AddRecordsFilms();
                        MessageBox.Show("Фильм успешно сохранен!");
                        OperationFilmsAdmin operationFilms = new OperationFilmsAdmin();
                        operationFilms.Show();
                        this.Close();
                    }
                    else { MessageBox.Show("Фото не было выбрано!"); }
                }
                else { MessageBox.Show("Дата заполнена не полонстью!"); }
            }
            else { MessageBox.Show("Данные заполнены не полностью!"); }
        }

        /// <summary>
        /// Запись данных нового фильма в БД
        /// </summary>
        public void AddRecordsFilms()
        {
            var catgID = _context.Category_Films.Where(x => x.Category == CategoryCB.Text).FirstOrDefault().id;
            var countryID = _context.Countries.Where(x => x.CountryName == CountryTB.Text).FirstOrDefault().id;
            var metragID = _context.Meterages.Where(x => x.MeterageTitle == MetrageCb.Text).Single().id;
            var ganreID = _context.Ganre_Films.Where(x => x.GanreTitle == GanreTB.Text).FirstOrDefault().id;

            var req = new Film()
            {
                FilmName = FilmNameTB.Text,
                DateStart = DateTb.Text,
                Director = DirectorTb.Text,
                CountryID = countryID,
                CategoryID = catgID,
                AgeLimit = int.Parse(AgeLimitCb.Text.TrimEnd('+')),
                GanreID = ganreID,
                MetrageID = metragID,
                Image = (byte[])bytesPict.Content,
                Site = SiteTb.Text,
            };
            _context.Films.Add(req);
            _context.SaveChanges();
        }

        /// <summary>
        /// Добавление новых данных в таблицы
        /// </summary>
        public void AddRecordsNewData()
        {
            var reqCountry = new Country()
            {
                CountryName= CountryTB.Text
            };
            _context.Countries.Add(reqCountry);
            _context.SaveChanges();

            var reqGanre = new Ganre_Film()
            {
                GanreTitle = GanreTB.Text
            };
            _context.Ganre_Films.Add(reqGanre);
            _context.SaveChanges();
        }

        #region Навигация по окнам и очистка полей ввода
        private void FilmNameTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            FilmNameTB.Text = "";
        }

        private void DateTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DateTb.Text = "";
        }

        private void DirectorTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DirectorTb.Text = "";
        }

        private void ExitPage_Click(object sender, RoutedEventArgs e)
        {
            OperationFilmsAdmin operationFilms = new OperationFilmsAdmin();
            if (ParamAccess.Content.ToString() == "1")
            {
                operationFilms.ParamAccess.Content = "1";
                operationFilms.Manage.Visibility = Visibility.Visible;
                operationFilms.Show();
                this.Close();
            }
            if (ParamAccess.Content.ToString() == "2")
            {
                operationFilms.ParamAccess.Content = "2";
                operationFilms.Manage.Visibility = Visibility.Hidden;
                operationFilms.Show();
                this.Close();
            }
        }

        private void SiteTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SiteTb.Text = "";
        }
        #endregion

        private void GanreTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            GanreTB.Text = "";
        }

        private void CountryTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            CountryTB.Text = "";
        }
    }
}
