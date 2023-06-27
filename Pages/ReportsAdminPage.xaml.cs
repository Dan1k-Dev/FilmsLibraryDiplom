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
using Excel = Microsoft.Office.Interop.Excel;

namespace Frolov_Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportsAdminPage.xaml
    /// </summary>
    public partial class ReportsAdminPage : Window
    {
        DataContext _context = new DataContext();
        public ReportsAdminPage()
        {
            InitializeComponent();

            var reqCatgCb = _context.Category_Films.Select(x => x.Category).ToList(); //Категории
            foreach (var catg in reqCatgCb)
            {
                CatgCb.Items.Add(catg);
                CatgCb.SelectedIndex = 3;
            }

            var query = _context.Films.Select(x => new
            {
                x.FilmName,
                Ganree = x.Ganre_.GanreTitle,
                x.DateStart,
                x.Director,
                CountryID = x.Country_.CountryName,
                CategoryID = x.Category_.Category,
                x.Rating,
                x.AgeLimit,
                MetrageID = x.Meterage_.MeterageTitle
            }).ToList();
            DataReps.ItemsSource = query;
        }

        /// <summary>
        /// Печать в Microsoft Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintRep_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.SheetsInNewWorkbook = 1;
            Excel.Workbook workBook = excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            workSheet.Name = "Отчет";
            workSheet.Cells[1, 1] = "";
            workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, DataReps.Columns.Count]].Merge();

            for (int i = 1; i <= DataReps.Columns.Count; i++)
                workSheet.Cells[3, i] = DataReps.Columns[i - 1].Header;

            List<dynamic> itemsSource = new List<dynamic>();//Берем данные из datagrid
            foreach (var item in DataReps.Items)
            {
                itemsSource.Add(item);
            }

            List<string> headers = new List<string>();
            foreach (DataGridTextColumn c in DataReps.Columns)
            {
                headers.Add((c.Binding as Binding).Path.Path);
            }

            for (int i = 0; i < DataReps.Items.Count; i++)
            {
                for (int j = 0; j < headers.Count; j++)
                {
                    string cellContent = " " + itemsSource[i].GetType().GetProperty(headers[j]).GetValue(itemsSource[i], null).ToString();
                    workSheet.Cells[i + 4, j + 1] = cellContent;
                }
            }

            workSheet.Range[workSheet.Columns[1], workSheet.Columns[DataReps.Columns.Count]].AutoFit();

            excelApp.Visible = true;
            excelApp.DisplayAlerts = false;
        }

        /// <summary>
        /// Сортировка данных
        /// </summary>
        public void DataUpdate()
        {
            if (CatgCb.Text == "Все")
            {
                var query = _context.Films.Select(x => new
                {
                    x.FilmName,
                    Ganree = x.Ganre_.GanreTitle,
                    x.DateStart,
                    x.Director,
                    CountryID = x.Country_.CountryName,
                    CategoryID = x.Category_.Category.ToString(),
                    x.Rating,
                    x.AgeLimit,
                    MetrageID = x.Meterage_.MeterageTitle
                }).ToList();
                DataReps.ItemsSource = query;
            }
            else
            {
                var catgID = _context.Category_Films.Where(x => x.Category == CatgCb.Text).Single().id;
                var req = from f in _context.Films
                          where f.CategoryID == catgID
                          select f.id;
                int[] films = req.ToArray();

                foreach (var filmId in films)
                {
                    var query = _context.Films.Where(x => x.id == filmId).Select(x => new
                    {
                        x.FilmName,
                        Ganree = x.Ganre_.GanreTitle,
                        x.DateStart,
                        x.Director,
                        CountryID = x.Country_.CountryName,
                        CategoryID = x.Category_.Category,
                        x.Rating,
                        x.AgeLimit,
                        MetrageID = x.Meterage_.MeterageTitle
                    }).ToList();
                    DataReps.ItemsSource = query;
                }
            }
        }

        private void CatgCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CatgCb.Text = CatgCb.SelectedItem.ToString();
            DataUpdate();
        }
    }
}
