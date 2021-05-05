using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ConexionString
{
    public class ConexionString
    {
        private const string Server = @"DESKTOP-AKCIL0Q\ALEXDEV";
        private const string DataBase = @"ECommerce";
        private const string User = @"sa";
        private const string Password = @"hackingadict";

        public static string CadenaConexion = $"Data Source={Server};" +
            $"Initial Catalog={DataBase};" +
            $"User Id={User};" +
            $"Password={Password};";
    }
}
