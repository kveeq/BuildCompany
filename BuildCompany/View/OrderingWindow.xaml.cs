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
    /// Логика взаимодействия для OrderingWindow.xaml
    /// </summary>
    public partial class OrderingWindow : Window
    {
        List<Button> buttons;
        Services service;
        int equipment1;
        int employee1;
        bool state;
        public OrderingWindow(Services services, int employee)
        {
            InitializeComponent();
            service = services;
            employee1 = employee;
            state = false;
            
            int k = DateTime.Now.Month;
            if (k == 4 || k == 6 || k == 9 || k == 11)
            {
                N31Btn.Content = "31";
                N31Btn.IsHitTestVisible = false;
            }
            else if (k == 2)
            {
                N30Btn.Content = "30";
                N29Btn.Content = "29";
                N31Btn.Content = "31";
                N31Btn.IsHitTestVisible = false;
                N30Btn.IsHitTestVisible = false;
                N29Btn.IsHitTestVisible = false;
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                {
                    N29Btn.Content = "29";
                    N29Btn.IsHitTestVisible = true;
                }
            }
            buttons = new List<Button>() { N1Btn, N2Btn, N3Btn, N4Btn, N5Btn, N6Btn, N7Btn, N8Btn, N9Btn, N10Btn, N11Btn, N12Btn, N13Btn, N14Btn, N15Btn, N16Btn, N17Btn, N18Btn, N19Btn, N20Btn, N21Btn, N22Btn, N23Btn, N24Btn, N25Btn, N26Btn, N27Btn, N28Btn, N29Btn, N30Btn, N31Btn, };

            btnGet();

        }

        private void btnGet()
        {
            foreach(Button button in buttons)
            {
                if (button.Content.ToString() == "6" || button.Content.ToString() == "7" || button.Content.ToString() == "13" || button.Content.ToString() == "14" || button.Content.ToString() == "21" || button.Content.ToString() == "20" || button.Content.ToString() == "27" || button.Content.ToString() == "28")
                {

                }
                else
                {
                    button.Background = new SolidColorBrush(Color.FromArgb(255,103,58,183));
                }
            }

            int k = DateTime.Now.Month;
            List<Zakaz> zakazs = App.db.Zakaz.Where(x => x.IdEmployee == employee1 && ((DateTime)x.Date).Month == k && x.Statuss == true).ToList();
            bool state1 = false;
            foreach (var item in zakazs)
            {
                foreach (var btn in buttons)
                {
                    if (state1)
                    {
                        if (int.Parse(btn.Content.ToString()) == Convert.ToDateTime(item.ExitDate).Day)
                        {
                            state1 = false;
                            btn.Background = new SolidColorBrush(Colors.Red);
                            btn.IsHitTestVisible = false;
                            continue;
                        }
                        btn.Background = new SolidColorBrush(Colors.Red);
                        btn.IsHitTestVisible = false;
                    }
                    else
                    {
                        if (int.Parse(btn.Content.ToString()) == Convert.ToDateTime(item.Date).Day)
                        {
                            state1 = true;
                            btn.Background = new SolidColorBrush(Colors.Red);
                            btn.IsHitTestVisible = false;
                        }
                    }
                }
            }
        }
        public OrderingWindow(int employee)
        {
            InitializeComponent();
            equipment1 = employee;
            state = true;
            grd.Visibility = Visibility.Collapsed;
      
        }

        bool isFirst = false;
        DateTime dateStart = DateTime.Now;
        DateTime dateEnd = DateTime.Now;
        
        public void Btn_Click(object sender, RoutedEventArgs e)
        {
            buttons = new List<Button>() { N1Btn, N2Btn, N3Btn, N4Btn, N5Btn, N6Btn, N7Btn, N8Btn, N9Btn, N10Btn, N11Btn, N12Btn, N13Btn, N14Btn, N15Btn, N16Btn, N17Btn, N18Btn, N19Btn, N20Btn, N21Btn, N22Btn, N23Btn, N24Btn, N25Btn, N26Btn, N27Btn, N28Btn, N29Btn, N30Btn, N31Btn, };
            var btn = (Button)sender;
            isFirst = !isFirst;
            if (isFirst)
            {
                btnGet();
                string a = btn.Content.ToString() + '.' + DateTime.Now.Month + '.' + DateTime.Now.Year;
                dateStart = Convert.ToDateTime(a);
                btn.IsHitTestVisible = false;
            }
            else
            {
                bool b = false;
                if(dateEnd.Day > dateStart.Day)
                {
                    if (DateTime.Now.Month == 12)
                    {
                        dateEnd = Convert.ToDateTime(btn.Content.ToString() + '.' + 01 + '.' + DateTime.Now.Year + 1);
                    }
                    else
                    {
                        dateEnd = Convert.ToDateTime(btn.Content.ToString() + '.' + (DateTime.Now.Month + 1) + '.' + DateTime.Now.Year);
                    }
                    b = true;
                }
                else
                {
                    dateEnd = Convert.ToDateTime(btn.Content.ToString() + '.' + DateTime.Now.Month + '.' + DateTime.Now.Year);
                }

                bool state3 = false;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if(Convert.ToInt32(buttons[i].Content.ToString()) >= dateStart.Day && Convert.ToInt32(buttons[i].Content.ToString()) <= dateEnd.Day)
                    {
                        buttons[i].IsHitTestVisible = false;
                        buttons[i].Background = new SolidColorBrush(Colors.Red);
                    }

                    //if (b == true &&)
                    //{

                    //}
                }
            }
            Employee employee = App.db.Employee.Where(x => x.Id == employee1).FirstOrDefault();
            MessageBox.Show(((Button)sender).Content.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (state)
            {
                try
                {
                    User user = new User();
                    user.Fio = FioTxt.Text;
                    user.Adres = AddressTxt.Text;
                    user.PassportSeria = SeriaTxt.Text;
                    user.PassportNumber = NumberTxt.Text;
                    user.TelNumber = TelNumberTxt.Text;
                    App.db.User.Add(user);
                    App.db.SaveChanges();
                    EquipmentRent rent = new EquipmentRent();
                    rent.DateStart = DateTime.Now;
                    rent.IdEquipment = equipment1;
                    rent.Statuss = true;
                    rent.IdUser = user.Id;
                    rent.Status = "Арендован";
                    App.db.EquipmentRent.Add(rent);
                    App.db.SaveChanges();
                    MainWindow.action?.Invoke();
                    MessageBox.Show("Вы успешно заказали");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Что то пошло не так! Обратитесь к программисту!");
                }
            }
            else
            {
                try
                {
                    User user = new User();
                    user.Fio = FioTxt.Text;
                    user.Adres = AddressTxt.Text;
                    user.PassportSeria = SeriaTxt.Text;
                    user.PassportNumber = NumberTxt.Text;
                    user.TelNumber = TelNumberTxt.Text;
                    App.db.User.Add(user);
                    App.db.SaveChanges();
                    Zakaz zakaz = new Zakaz();
                    zakaz.Date = dateStart;
                    zakaz.ExitDate = dateEnd;
                    zakaz.IdService = service.Id;
                    zakaz.IdUser = user.Id;
                    zakaz.Status = "В обработке";
                    zakaz.Statuss = false;
                    zakaz.IdEmployee = employee1;
                    zakaz.Accept = true;
                    App.db.Zakaz.Add(zakaz);
                    App.db.SaveChanges();
                    MainWindow.action?.Invoke();
                    MessageBox.Show("Вы успешно заказали");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Что то пошло не так! Обратитесь к программисту!");
                }
            }
        }
    }
}
