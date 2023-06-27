using Frolov_Cinema.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Frolov_Cinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        DataContext _context = new DataContext();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Регистрация аккаунта в системе и сохранение данных пользователя в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "Придумайте логин" || Password.Password == "Пароль" || Name.Text == "Введите свое имя" || Email.Text == "Введите свою почту"
                || SecName.Text == "Введите свою фамилию")
            {
                MessageBox.Show("Введите действительные данные!");
            }
            else
            {
                //Проверка на пустоту полей
                if (Login.Text != "" && Password.Password != "" && Email.Text != "" && DatebTb.Text != "")
                {
                    //Проверка почты на корректность
                    if (Email.Text.Contains('@') && Email.Text.Contains(".com") || Email.Text.Contains('@') && Email.Text.Contains(".ru"))
                    {
                        if (DatebTb.IsMaskFull)
                        {
                            string Fcs = Name.Text + " " + SecName.Text;
                            var saveAcc = new User() //Сохраняем и создаем аккаунт
                            {
                                AccessID = 2,
                                Login = Login.Text,
                                Password = HashPassw(Password.Password),
                                Email = Email.Text,
                                FCs = Fcs,
                                DateB = DatebTb.Text,
                            };
                            _context.Users.Add(saveAcc);
                            _context.SaveChanges();

                            MessageBox.Show("Аккаунт успешно создан!");
                        }
                        else { MessageBox.Show("Данные заполнены не полностью!"); }
                    }
                    //Вывод ошибок при неверно введенных (запрашиваемых) данных
                    else
                    {
                        MessageBox.Show("Почта введена некорректно \n В адресе электронной почты должен содержаться символ: @ \n" +
                            "а также должен содержаться один из доменов: .com или .ru");
                    }
                }
                if (Login.Text == "" && Password.Password == "" && Email.Text == "")
                {
                    MessageBox.Show("Данные не были введены");
                }
            }
        }

        /// <summary>
        /// Шифрование пароля при помощи хэширования
        /// </summary>
        /// <param name="sourceData">Параметр пароля в чистом виде</param>
        /// <returns>Зашифрованный пароль</returns>
        static string HashPassw(string sourceData)
        {
            var tmpSource = UTF8Encoding.UTF8.GetBytes(sourceData);
            byte[] tmpHash;
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return Convert.ToBase64String(tmpHash);
        }

        #region Навигация и очистка полей ввода
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Login_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Login.Text = "";
        }

        private void Name_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Name.Text = "";
        }

        private void SecName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SecName.Text = "";
        }

        private void Password_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Password.Password = "";
        }

        private void Email_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Email.Text = "";
        }

        private void DatebTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DatebTb.Text = "";
        }
#endregion
    }
}
