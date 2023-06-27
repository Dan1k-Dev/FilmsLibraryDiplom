using Frolov_Cinema.Database;
using Microsoft.Win32;
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
    /// Логика взаимодействия для EditFilmPage.xaml
    /// </summary>
    public partial class EditFilmPage : Window
    {
        DataContext _context = new DataContext();
        public EditFilmPage()
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
                CategoryCb.Items.Add(catg);
            }

            var reqGanreCb = _context.Ganre_Films.Select(x => x.GanreTitle).Distinct().ToList(); //Жанры
            foreach (var ganre in reqGanreCb)
            {
                GanreCb.Items.Add(ganre);
            }

            var reqMetragCb = _context.Meterages.Select(x => x.MeterageTitle).ToList(); //Метражи
            foreach (var metrag in reqMetragCb)
            {
                MetrageCb.Items.Add(metrag);
            }

            var reqCountryCb = _context.Countries.Select(x => x.CountryName).Distinct().ToList(); //Метражи
            foreach (var country in reqCountryCb)
            {
                CountryCb.Items.Add(country);
            }
        }

        /// <summary>
        /// Редактирование фильма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SiteTb.Text != "" && DateTb.Text != "" && DirectorTb.Text != "" && CountryCb.Text != ""
                && CategoryCb.Text != "" && AgeLimitCb.Text != "" && GanreCb.Text != "" && MetrageCb.Text != "")
            {
                if (DateTb.IsMaskFull)
                {
                    if (bytesPict.Content.ToString() != "")
                    {
                        EditRecordsFilms();
                        MessageBox.Show("Фильм успешно отредактирован!");
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
        /// Сохранение изменений в БД
        /// </summary>
        public void EditRecordsFilms()
        {
            var catgID = _context.Category_Films.Where(x => x.Category == CategoryCb.Text).Single().id;
            var countryID = _context.Countries.Where(x => x.CountryName == CountryCb.Text).Single().id;
            var metragID = _context.Meterages.Where(x => x.MeterageTitle == MetrageCb.Text).Single().id;
            var ganreID = _context.Ganre_Films.Where(x => x.GanreTitle == GanreCb.Text).Single().id;
            var fID = _context.Films.Where(x => x.FilmName == asdd.Content.ToString()).Single().id;

            var filmRow = _context.Films.Where(x => x.id == fID).FirstOrDefault();

            filmRow.GanreID = ganreID;
            filmRow.CountryID = countryID;
            filmRow.CategoryID = catgID;
            filmRow.MetrageID = metragID;
            filmRow.AgeLimit = int.Parse(AgeLimitCb.Text.TrimEnd('+'));
            filmRow.DateStart = DateTb.Text;
            filmRow.Director = DirectorTb.Text;
            filmRow.Image = (byte[])bytesPict.Content;
            filmRow.Site = SiteTb.Text;
            _context.SaveChanges();
        }

        #region Навигация по окнам и очистка полей ввода
        private void DirectorTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DirectorTb.Text = "";
        }

        private void DateTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DateTb.Text = "";
        }

        private void ExitPage_Click(object sender, RoutedEventArgs e)
        {
            OperationFilmsAdmin operationFilms = new OperationFilmsAdmin();
            operationFilms.Show();
            this.Close();
        }

        private void SiteTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SiteTb.Text = "";
        }
        #endregion

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
    }
}
