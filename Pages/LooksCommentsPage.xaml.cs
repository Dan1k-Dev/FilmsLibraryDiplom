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
    /// Логика взаимодействия для LooksCommentsPage.xaml
    /// </summary>
    public partial class LooksCommentsPage : Window
    {
        DataContext _context = new DataContext();
        public LooksCommentsPage()
        {
            InitializeComponent();
        }
    }
}
