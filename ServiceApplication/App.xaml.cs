using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceApplication
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Entities.CarServiceDbEntities _context;
        private static Entities.User _user;

        public static Entities.CarServiceDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new Entities.CarServiceDbEntities();
            }
            return _context;
        }

        public static Entities.User GetUser()
        {
            if (_user == null)
            {
                return null;
            }
            return _user;
        }

        public static bool LoginUser(string login, string password)
        {
            _user = GetContext().Users.FirstOrDefault(x => x.login == login && x.password == password);
            return _user != null;
        }

        public static void LogoutUser() {
            _user = null;
        }
    }
}

