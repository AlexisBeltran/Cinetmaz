using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Datos
{
    public abstract class DConexion
    {
        private readonly string conexionMysql;

        public DConexion()
        {
            conexionMysql = "datasource = 127.0.0.1; port = 3307; username = root; password =; DATABASE = cinetmaz; Integrated Security = true;";
        }

        protected MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(conexionMysql);
        }
    }
}
