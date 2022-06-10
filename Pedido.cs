using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace Proyecto_Catedra_PEDG01T
{
    public class Pedido
    {
        //herramientas para la clase
        private static Conexion conexion = new Conexion();
        private static SqlDataAdapter dataAdapter;
        private static SqlDataReader dataReader;
        private static SqlCommand command;

        //campos de la clase
        private int idPedido;
        private string fechaPedido;
        private int estadoPedido;
        private string idUsuario;
        private double total;
        private Lista detallePed = new Lista();

        //propiedades de la clase
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string FechaPedido { get => fechaPedido; set => fechaPedido = value; }
        public int EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public double Total { get => total; set => total = value; }
        public Lista DetallePed { get => detallePed; set => detallePed = value; }

        //--- Métodos de clase ---//

        //total de todos los productos
        public void calcularTotal()
        {
            double total = 0;

            for (int i = 0; i < DetallePed.Count(); i++)
            {
                total += ((DetallePedido)DetallePed.ElementAtIndex(i)).PrecioTotalDetalle;
            }

            Total = total;
        }

        //Método que ingresa el pedido a la DB
        public bool CreatePedido()
        {
            bool creado = false;
            string sql = "INSERT INTO Pedido (idUsuario, estadoPedido, totalPedido) VALUES (@idUser, @estdP, @total)";

            try
            {
                conexion.Conectar();
                command = new SqlCommand(sql, conexion.Conn);
                command.Parameters.AddWithValue("@idUser", IdUsuario);
                command.Parameters.AddWithValue("@total", Total);
                command.Parameters.AddWithValue("@estdP", EstadoPedido);
                creado = command.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al crear pedido en la DB: " + err.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }

            SaveDetails();

            return creado;
        }

        //Método que inserta los detalles del pedido en la DB
        private bool SaveDetails()
        {
            bool guardado = false;
            int idped;
            string sql = "INSERT INTO Detalle_pedido (idProducto, cantidadProducto, precioDetalle, idPedido) " +
                "VALUES (@idPrdt, @cantidad, @precio, @idPd)";
            string sql2 = "SELECT TOP 1 idPedido FROM Pedido ORDER BY idPedido DESC";

            try
            {
                conexion.Conectar();

                //Primero extraemos el id del pedido
                dataAdapter = new SqlDataAdapter(sql2, conexion.Conn);
                dataReader = dataAdapter.SelectCommand.ExecuteReader();
                if (!dataReader.HasRows)
                    throw new Exception("Error al extraer id del pedido");
                dataReader.Read();
                idped = Convert.ToInt32(dataReader[0]);
                dataReader.Close();

                //Insertamos los detalles del pedido con ayuda de un bucle
                command = new SqlCommand(sql, conexion.Conn);
                command.Parameters.AddWithValue("@idPd", idped);
                command.Parameters.Add("@idPrdt", System.Data.SqlDbType.Int);
                command.Parameters.Add("@cantidad", System.Data.SqlDbType.Int);
                command.Parameters.Add("@precio", System.Data.SqlDbType.Float);
                ///
                DetallePedido detallePedido;
                for (int i = 0; i < DetallePed.Count(); i++)
                {
                    detallePedido = (DetallePedido)DetallePed.ElementAtIndex(i);
                    command.Parameters["@idPrdt"].Value = detallePedido.IdProducto;
                    command.Parameters["@cantidad"].Value = detallePedido.Cantidad;
                    command.Parameters["@precio"].Value = detallePedido.PrecioTotalDetalle;
                    guardado = command.ExecuteNonQuery() > 0 ? true : false;
                    detallePedido = null;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al guardar los detalles del pedido en la DB: " + err.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataReader.Close();
                conexion.Cerrar();
            }

            return guardado;
        }

        public static Lista MostrarPedidio()
        {
            Lista listPedidos = new Lista();
            string sql = "SELECT * FROM Pedido WHERE estadoPedido = 0 ORDER BY fechaPedido ASC;";
            try
            {
                conexion.Conectar();
                dataAdapter = new SqlDataAdapter(sql, conexion.Conn);
                dataReader = dataAdapter.SelectCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //creamos el objeto pedido
                        Pedido pedido = new Pedido();
                        pedido.IdPedido = Convert.ToInt32(dataReader["idPedido"].ToString());
                        pedido.idUsuario = dataReader["idUsuario"].ToString();
                        pedido.fechaPedido = dataReader["fechaPedido"].ToString();
                        pedido.EstadoPedido = Convert.ToInt32(dataReader["estadoPedido"].ToString());
                        pedido.Total = Convert.ToDouble(dataReader["totalPedido"].ToString());

                        //lo añadimos a la lista
                        listPedidos.Add(pedido);
                        //reseteamos el objeto pedido
                        pedido = null;
                    }
                    dataReader.Close();
                }
                else
                {

                    MessageBox.Show("No hay pedidos que mostrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataReader.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los pedidos " +
                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                //cerramos la conexión
                conexion.Cerrar();
            }

            return listPedidos;
        }

        public void buscarPedidos(int idPedido)
        {

            conexion.Conectar();
            try
            {
                
                int id = idPedido;
                String sql = "SELECT P.idPedido as Id,nombreProducto as Producto, cantidadProducto as Cantidad, fechaPedido from Pedido as P inner join Detalle_pedido as DP on P.idPedido = DP.idPedido inner join Productos as PR on DP.idProducto = PR.idProducto  WHERE estadoPedido = 0 AND P.idPedido = @idPedido";
                dataAdapter = new SqlDataAdapter(sql, conexion.Conn);
                SqlParameter prm = new SqlParameter("@idPedido", SqlDbType.Int);
                prm.Value = id;
                dataAdapter.SelectCommand.Parameters.Add(prm);
                dataReader = dataAdapter.SelectCommand.ExecuteReader();
                while (dataReader.Read())
                {
                   
                }
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            } 
            if (dataReader != null)
            {
                dataReader.Close();
            }
        }

        public void UpdateEstado()
        {
            int rowsAffected = 0;
            try
            {
                conexion.Conectar();
                command = new SqlCommand("UPDATE  Pedido set estadoPedido = 1 where idPedido = @idPedido", conexion.Conn);
                command.Parameters.AddWithValue("@idPedido", IdPedido);
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al actualizar el estado del pedido en la DB: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }

            if (rowsAffected != 0)
                MessageBox.Show("Se ha entregado el pedido con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Hubo un inconveniente al cambiar estado entregado a este pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void DeletePedido()
        {
            int rowsAffected = 0;
            try
            {
                conexion.Conectar();
                command = new SqlCommand("DELETE FROM Pedido WHERE idPedido = @id");
                command.Parameters.AddWithValue("@id", IdPedido);
                rowsAffected = command.ExecuteNonQuery();
            }catch (Exception err)
            {
                MessageBox.Show("Error al eliminar el pedido en la DB: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rowsAffected != 0)
                    MessageBox.Show("Se ha eliminado el pedido con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Hubo un inconveniente al eliminar este pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
