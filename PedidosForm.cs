using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto_Catedra_PEDG01T
{
    public partial class PedidosForm : Form
    {
        //delegado para comunicar con el form Inicio para abrir la factura
        public delegate void showFactura(Pedido pedido);
        public event showFactura VerFactura;

        public PedidosForm()
        {
            InitializeComponent();
            //se crean las columnas del dgv
            dgvpedidos.Columns.Add("idPedido", "ID Pedido");
            dgvpedidos.Columns.Add("fecha", "Fecha");
            dgvpedidos.Columns.Add("estado", "Estado");
            dgvpedidos.Columns.Add("cantidad", "Cantidad");
            dgvpedidos.Columns.Add("totalPedido", "Monto Total");
            dgvpedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private Lista listaPedidos;
        private Cola objCola = new Cola();
        private Pedido[] arrPedidos;
        private Pedido objPedido;

        private void llenarDataGrid()
        {
            //se convierte la cola a un array para ser mostrado y manipulado
            arrPedidos = objCola.QueueToArray();
            foreach (Pedido pedido in arrPedidos)
            {
                if (pedido.EstadoPedido == 0)
                {
                    dgvpedidos.Rows.Add(pedido.IdPedido, pedido.FechaPedido, "Pendiente", pedido.DetallePed.Count(), pedido.Total);
                }
            }
        }

        private void PedidosForm_Load(object sender, EventArgs e)
        {
            //extraemos los pedidos y los almacenamos en una lista
            listaPedidos = Pedido.MostrarPedidio();
            Pedido pedidoTemp;
            //recorremos los pedidos para extraer sus detalles y guardarlos en la cola
            for (int i = 0; i < listaPedidos.Count(); i++)
            {
                pedidoTemp = (Pedido)listaPedidos.ElementAtIndex(i);
                pedidoTemp.DetallePed = DetallePedido.GetDetails(pedidoTemp.IdPedido);
                objCola.Encolar(pedidoTemp);
                pedidoTemp = null;
            }

            llenarDataGrid();
        }

        private void btnentregar_Click(object sender, EventArgs e)
        {
            objPedido = objCola.Desencolar();
            objPedido.UpdateEstado();
            dgvpedidos.Rows.Clear();
            llenarDataGrid();
        }

        private void btnfactura_Click(object sender, EventArgs e)
        {
            facutar();
        }

        public void facutar()
        {
            VerFactura(arrPedidos[0]);
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            objPedido = objCola.Desencolar();
            objPedido.DeletePedido();
            dgvpedidos.Rows.Clear();
            llenarDataGrid();
        }
    }
}
