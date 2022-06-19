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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Action action;
        public MainWindow()
        {
            InitializeComponent();
            action += Update;
            GetRolePriv();
        } 

        public void GetRolePriv()
        {
            if(App.user.IdRole == 1)
            {
                AddServiceBtn.Visibility = Visibility.Visible;
                EquipmentAddBtn.Visibility = Visibility.Visible;
                AddZakazBtn.Visibility = Visibility.Visible;
                Zayavki.Visibility = Visibility.Visible;
                Zakazi.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddServiceBtn.Visibility = Visibility.Hidden;
                EquipmentAddBtn.Visibility = Visibility.Hidden;
                AddZakazBtn.Visibility = Visibility.Hidden;
                Zayavki.Visibility = Visibility.Collapsed;
                Zakazi.Visibility = Visibility.Visible;
            }
        }

        private void Update()
        {
            HousesLstView1.ItemsSource = App.db.Services.ToList();
            OborudovanieLstView.ItemsSource = App.db.Equipment.ToList();
            ZakazLstView.ItemsSource = App.db.Zakaz.Where(x => x.IdUser == App.user.Id).ToList();
            RentLstView.ItemsSource = App.db.EquipmentRent.Where(x => x.IdUser == App.user.Id).ToList();
            ZayavkiLstView.ItemsSource = App.db.Zakaz.ToList();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(((Button)sender).CommandParameter);
            Zakaz zakaz = new Zakaz();
            zakaz.Date = DateTime.Now;
            zakaz.IdService = id;
            zakaz.IdUser = App.user.Id;
            zakaz.Status = "В обработке";
            zakaz.Statuss = false;
            zakaz.Accept = true;
            App.db.Zakaz.Add(zakaz);
            App.db.SaveChanges();
            Update();
            MessageBox.Show("Вы успешно заказали");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(((Button)sender).CommandParameter);
            EquipmentRent rent = new EquipmentRent();
            rent.DateStart = DateTime.Now;
            rent.IdEquipment = id;
            rent.Statuss = true;
            rent.IdUser = App.user.Id;
            rent.Status = "Арендован";
            App.db.EquipmentRent.Add(rent);
            App.db.SaveChanges();
            Update();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(((Button)sender).CommandParameter);
            var rent = App.db.EquipmentRent.Where(x => x.Id == id).FirstOrDefault();
            rent.Status = "Завершен";
            rent.Statuss = false;
            rent.DateEnd = DateTime.Now;
            App.db.SaveChanges();
            Update();
        }

        private void EquipmentAddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEquipmentWindow addEquipmentWindow = new AddEquipmentWindow();
            addEquipmentWindow.Show();
        }

        private void AddZakazBtn_Click(object sender, RoutedEventArgs e)
        {
            AddZakazWindow addZakazWindow = new AddZakazWindow();
            addZakazWindow.Show();

        }

        private void AddServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow addServiceWindow = new AddServiceWindow();
            addServiceWindow.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(((Button)sender).CommandParameter);
            var zakaz = App.db.Zakaz.Where(x => x.Id == id).FirstOrDefault();
            zakaz.AcceptDate = DateTime.Now;
            zakaz.Status = "Принят (в работе)";
            zakaz.Statuss = true;
            zakaz.Accept = false;
            App.db.SaveChanges();
            Update();
            MessageBox.Show("Вы успешно приняли заказ");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(((Button)sender).CommandParameter);
            var zakaz = App.db.Zakaz.Where(x => x.Id == id).FirstOrDefault();
            zakaz.AcceptDate = DateTime.Now;
            zakaz.ExitDate = DateTime.Now;
            zakaz.Status = "Отклонен";
            zakaz.Statuss = false;
            zakaz.Accept = false;
            App.db.SaveChanges();
            Update();
            MessageBox.Show("Вы успешно отклонили заказ");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(((Button)sender).CommandParameter);
            var zakaz = App.db.Zakaz.Where(x => x.Id == id).FirstOrDefault();
            zakaz.ExitDate = DateTime.Now;
            zakaz.Status = "Завершен";
            zakaz.Statuss = false;
            zakaz.Accept = false;
            App.db.SaveChanges();
            Update();
            MessageBox.Show("Вы успешно отклонили заказ");
        }
    }
}
