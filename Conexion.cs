using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proyecto_Catedra_PEDG01T
{
    class Conexion
    {
        private static string cadenaCon = "server=Localhost\\SQLEXPRESS; database=Proyecto; Integrated Security=yes";
        //private static string cadenaCon = "server=FABIOLA\\SQLEXPRESS; database=Proyecto; Integrated Security=yes";

        private SqlConnection conn = new SqlConnection(cadenaCon);

        public SqlConnection Conn { get => conn; }

        public void Conectar()
        {
            Conn.Open();
        }

        public void Cerrar()
        {
            Conn.Close();
        }
    }
}
