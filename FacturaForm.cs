using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PEDG01T
{
    public partial class FacturaForm : Form
    {
        Usuario usua;
        Pedido pedido;
        DetallePedido[] Dproductos;

        //delegado para comunicar con el form Inicio
        public delegate void actionFactura(bool actn);
        public event actionFactura Accion;

        public FacturaForm(Pedido pedido, Usuario usua, bool onlyView = false)
        {
            InitializeComponent();
            this.usua = usua;
            this.pedido = pedido;

            if (onlyView)
            {
                btnagregar.Visible = false;
                btnimprimir.Visible = false;
                btncancelar.Visible = false;
                btnpedidos.Visible = true;
            }
            else
            {
                btnagregar.Visible = true;
                btnimprimir.Visible = true;
                btncancelar.Visible = true;
                btnpedidos.Visible = false;
            }

            Dproductos = new DetallePedido[pedido.DetallePed.Count()];
            for (int i = 0; i < pedido.DetallePed.Count(); i++)
            {
                Dproductos[i] = (DetallePedido)pedido.DetallePed.ElementAtIndex(i);
            }
        }

        private void FacturaForm_Load(object sender, EventArgs e)
        {
            Usuario[] usuarios = new Usuario[1];
            usuarios[0] = usua;
            Pedido[] pedidos = new Pedido[1];
            pedidos[0] = pedido;

            this.report1.LocalReport.ReportEmbeddedResource = "Proyecto_Catedra_PEDG01T.Report1.rdlc";
            this.report1.LocalReport.DataSources.Clear();
            ReportDataSource fpedido = new ReportDataSource("FacturaPedido", pedidos);
            ReportDataSource datos = new ReportDataSource("FacturaUsuario", usuarios);
            ReportDataSource fdetalle = new ReportDataSource("FacturaDetalle", Dproductos);
            this.report1.LocalReport.DataSources.Add(datos);
            this.report1.LocalReport.DataSources.Add(fpedido);
            this.report1.LocalReport.DataSources.Add(fdetalle);

            this.report1.RefreshReport();
        }

        private void btnimprimir_Click_1(object sender, EventArgs e)
        {
            this.report1.PrintDialog();
        }

        private void btnagregar_Click_1(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("¿Desea ingresar este pedido?", "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //true significa que el pedido se aprobo y se ingreso
                pedido.CreatePedido();
                Accion(true);
                this.Close();
            }
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("¿Realmente desea cancelar la creación de este pedido?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //Indica que se cancelo la creación de este pedido
                Accion(false);
                this.Close();
            }
        }

        private void btnpedidos_Click(object sender, EventArgs e)
        {
            Accion(true);
            this.Close();
        }
    }
}
