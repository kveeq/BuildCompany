using System;
using System.Collections.Generic;
using System.Configuration;
using BuildCompany.db;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BuildCompany
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BuildCompanyEntities1 db = new BuildCompanyEntities1();
        public static User user;
    }
}
