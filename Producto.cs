using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PEDG01T
{
    public class Producto
    {
        //herramientas para la clase
        private static Conexion conexion = new Conexion();
        private static SqlDataAdapter dataAdapter;
        private static SqlDataReader dataReader;
        private static SqlCommand command;

        //campos de la clase
        private int id;
        private string nombre;
        private double precio;
        private string codigo;
        private string descripcion;
        private byte[] photoProducto;

        //propiedades de la clase
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public byte[] PhotoProducto { get => photoProducto; set => photoProducto = value; }

        //--- Métodos de la clase ---//

        //método que extraemo los productos desde la BD
        public static Lista GetProductos()
        {
            Lista productos = new Lista();
            string sql = "SELECT * FROM Productos";

            try
            {
                //iniciamos conexión con DB
                conexion.Conectar();
                dataAdapter = new SqlDataAdapter(sql, conexion.Conn);
                dataReader = dataAdapter.SelectCommand.ExecuteReader();

                //evalua si hay datos
                if (dataReader.HasRows)
                {
                    //bucle para recorrer los datos
                    while (dataReader.Read())
                    {
                        Producto producto = new Producto
                        {
                            Id = Convert.ToInt32(dataReader["idProducto"].ToString()),
                            Nombre = dataReader["nombreProducto"].ToString(),
                            Codigo = dataReader["codigoProducto"].ToString(),
                            Precio = float.Parse(dataReader["precioProducto"].ToString()),
                            Descripcion = dataReader["Descripcion"].ToString(),
                            PhotoProducto = (byte[])dataReader["imgProducto"]
                        };
                        //añadimos el producto a la lista
                        productos.Add(producto);
                        producto = null;
                    }
                }
                else
                    MessageBox.Show("No hay productos en la BD", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                dataReader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Se produjo un error al extraer datos desde la BD, consulte con un administrador: " + err.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //cerramos la conexión
                conexion.Cerrar();
            }
          
            return productos;
        }

        //Método para agregar un nuevo producto
        public bool AddProducto()
        {
            bool agregado = false;
            string sql = "INSERT INTO Productos (nombreProducto, codigoProducto, precioProducto ,Descripcion, imgProducto) ";
            sql += "VALUES (@name, @code, @price, @description, @img)";

            try
            {
                conexion.Conectar();

                //creando codigo de producto
                string cod = CreateCod();

                command = new SqlCommand(sql, conexion.Conn);
                command.Parameters.AddWithValue("@name", Nombre);
                command.Parameters.AddWithValue("@code", cod);
                command.Parameters.AddWithValue("@price", Precio);
                command.Parameters.AddWithValue("@description", Descripcion);
                command.Parameters.Add("@img", SqlDbType.Image).Value = PhotoProducto;
                //evaluamos si se ingreso el producto
                agregado = command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al ingresar producto en la DB, contacte con un administrador: " + err.Message, 
                    "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }

            return agregado;
        }

        //Método que crea codigos de producto
        private string CreateCod()
        {
            Random rand = new Random();
            string cod = "";
            string sqlSelect = "SELECT codigoProducto FROM Productos WHERE codigoProducto = @cod";

            while (true)
            {
                cod = "PR";
                cod += rand.Next(0, 9).ToString();
                cod += rand.Next(0, 9).ToString();
                cod += rand.Next(0, 9).ToString();
                dataAdapter = new SqlDataAdapter(sqlSelect, conexion.Conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@cod", cod);
                dataReader = dataAdapter.SelectCommand.ExecuteReader();

                if (!dataReader.HasRows)
                    break;

                dataAdapter = null;
            }
            dataReader.Close();
            return cod;
        }

        //Método para actualizar
        public bool UpdateProducto()
        {
            bool actualizado = false;
            string sql = "UPDATE Productos SET nombreProducto = @name, codigoProducto = @code, precioProducto = @price, " +
                "Descripcion = @description, imgProducto = @img WHERE idProducto = @id";

            try
            {
                conexion.Conectar();
                command = new SqlCommand(sql, conexion.Conn);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@name", Nombre);
                command.Parameters.AddWithValue("@code", Codigo);
                command.Parameters.AddWithValue("@price", Precio);
                command.Parameters.AddWithValue("@description", Descripcion);
                command.Parameters.Add("@img", SqlDbType.Image).Value = PhotoProducto;

                //evaluamos si se actualizo el producto
                actualizado = command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al actualizar el producto en la DB, contacte con un administrador: " + err.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }

            return actualizado;
        }

        //Método para borrar un producto en la DB
        public static bool DeleteProducto(int idProducto)
        {
            bool borrado = false;
            string sql = "DELETE FROM Productos WHERE idProducto = @id";

            try
            {
                conexion.Conectar();
                command = new SqlCommand(sql, conexion.Conn);
                command.Parameters.AddWithValue("@id", idProducto);

                //evaluamos si se actualizo el producto
                borrado = command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al intentar borrar el producto en la DB, contacte con un administrador: " + err.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }

            return borrado;
        }
    }
}
