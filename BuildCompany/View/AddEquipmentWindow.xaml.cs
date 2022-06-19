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
    /// Логика взаимодействия для AddEquipmentWindow.xaml
    /// </summary>
    public partial class AddEquipmentWindow : Window
    {
        public AddEquipmentWindow()
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
                Equipment equipment = new Equipment();
                equipment.Name = NameTxt.Text;
                equipment.Description = DescriptionTxt.Text;
                App.db.Equipment.Add(equipment);
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
