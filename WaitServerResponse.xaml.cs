using Frolov_Cinema.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Frolov_Cinema
{
    /// <summary>
    /// Логика взаимодействия для WaitServerResponse.xaml
    /// </summary>
    public partial class WaitServerResponse : Window
    {
        public WaitServerResponse()
        {
            InitializeComponent();
            Response();
        }

        /// <summary>
        /// Ожидание загрузки данных с сервера
        /// </summary>
        async void Response()
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(3));
            DoubleAnimation doubleAnimation = new DoubleAnimation(100, duration);
            ProgBar.BeginAnimation(ProgressBar.ValueProperty, doubleAnimation);
            for (int i = 0; i < 101; i++)
            {
                await Task.Delay(1000);
                ProgBar.Value ++;
                FilmsPageOpenFromRole();
                break;
            }
        }

        /// <summary>
        /// Открытие фильмотеки в зависимости от роли пользователя
        /// </summary>
        void FilmsPageOpenFromRole()
        {
            if (ParamAccess.Content.ToString() == "1")
            {
                FilmsPage filmsPage = new FilmsPage();
                filmsPage.ParamAccess.Content = "1";
                filmsPage.Show();
                this.Close();
            }
            if (ParamAccess.Content.ToString() == "2")
            {
                FilmsPage filmsPage = new FilmsPage();
                filmsPage.Manage.Visibility = Visibility.Hidden;
                filmsPage.ParamAccess.Content = "2";
                filmsPage.Show();
                this.Close();
            }
        }
    }
}
