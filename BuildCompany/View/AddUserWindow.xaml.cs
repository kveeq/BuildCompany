using BuildCompany.db;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace BuildCompany.View
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
            cmb.ItemsSource = App.db.Services.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var serv = (Services)cmb.SelectedItem;
            Employee employee = new Employee();
            employee.Fio = Fiotxt.Text;
            employee.TelNumber = Teltxt.Text;
            try
            {
                var stream = File.ReadAllBytes(link);
                employee.Photo = stream;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка\n" + ex.Message);
            }
            App.db.Employee.Add(employee);
            Timetable timetable = new Timetable();
            timetable.IdService = serv.Id;
            timetable.IdEmoloyee = employee.Id;
            App.db.Timetable.Add(timetable);
            App.db.SaveChanges();
            MessageBox.Show("Успешно!");
        }

        string link = "";
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var OFD = new OpenFileDialog();

            if (OFD.ShowDialog() == true)
            {
                link = OFD.FileName;
                var stream = File.ReadAllBytes(link);
                using (Bitmap bmp = new Bitmap(link))
                {
                    img.Source = bmp.BitmapToImageSource();
                }
            }
        }
    }
    public static class Extensions
    {
        public static BitmapImage BitmapToImageSource(this Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }
    }
}
