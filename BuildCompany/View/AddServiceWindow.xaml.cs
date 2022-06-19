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
using BuildCompany.db;

namespace BuildCompany.View
{
    /// <summary>
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        public AddServiceWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                Services services = new Services();
                services.Name = NameTxt.Text;
                services.Description = DescriptionTxt.Text;
                services.Price = int.Parse(PriceTxt.Text);
                App.db.Services.Add(services);
                App.db.SaveChanges();
                MainWindow.action?.Invoke();
                MessageBox.Show("Успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что то пошло не так. Обратитесь к программисту!\n" + ex.Message);
            }
        }
    }
}
