using Frolov_Cinema.Pages;
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

namespace Frolov_Cinema
{
    /// <summary>
    /// Логика взаимодействия для MessageDelGreat.xaml
    /// </summary>
    public partial class MessageDelGreat : Window
    {
        public MessageDelGreat()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            OperationFilmsAdmin operationFilmsAdmin = new OperationFilmsAdmin();
            operationFilmsAdmin.Show();
            this.Close();
        }
    }
}
