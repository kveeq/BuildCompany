using BuildCompany.db;
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

namespace BuildCompany.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var us = App.db.User.Where(x => x.Fio == FioTxt.Text || x.Login == LoginTxt.Text).FirstOrDefault();
                if (us != null)
                    throw new Exception("Такой пользователь уже существует");
                User user = new User();
                user.Fio = FioTxt.Text;
                user.Login = LoginTxt.Text;
                user.Password = PassTxt.Password;
                user.IdRole = 2;
                App.db.User.Add(user);
                App.db.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрировались");
                LoginWindow mainWindow = new LoginWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удачная регистрация\n" + ex.Message);
            }
        }
    }
}
