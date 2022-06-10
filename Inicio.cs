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
    public partial class Inicio : Form
    {
        //Objeto de tipo Usuario con los datos del usuario actual
        Usuario usuario;
        public Inicio(Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            if (this.usuario.TipoUsuario == "Administrador")
            {
                btnperfil.Location = new Point(0, 327);
                pnladmin.Visible = true;
                pnladmin.Enabled = true;
                pbxperfil.Location = new Point(12, 334);
                OpenForm<AddProductoForm>();
            }
            else
            {
                OpenFormMenu();
            }
        }


        //-------- Eventos de los botones de la barra horizontal --------
        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            DialogResult = DialogResult.Cancel;
        }

        private void btnWState_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnWState.BackgroundImage = Properties.Resources.Round_Resturar;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnWState.BackgroundImage = Properties.Resources.Round_Max;
            }
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //---------------------------------------------------------------

        #region Eventos de la barra vertical

        private void btnmenu_Click(object sender, EventArgs e)
        {
            OpenFormMenu();
        }

        private void btnpedidos_Click(object sender, EventArgs e)
        {
            OpenFormPedidos();
        }

        private void btnperfil_Click(object sender, EventArgs e)
        {
            OpenFormPerfil();
        }

        private void btnaddproduct_Click(object sender, EventArgs e)
        {
            OpenForm<AddProductoForm>();
        }

        private void btnadmproduct_Click(object sender, EventArgs e)
        {
            OpenForm<AdmProductoForm>();
        }

        private void btnadmuser_Click(object sender, EventArgs e)
        {
            OpenForm<RegEmpForm>();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region métodos del Form Inicio

        private void OpenForm <MiForm>() where MiForm : Form, new(){
            Form form;
            form = pnlcontent.Controls.OfType<MiForm>().FirstOrDefault();

            if (form == null)
            {
                form = new MiForm();
                form.TopLevel = false;
                pnlcontent.Controls.Add(form);
                pnlcontent.Tag = form;
                form.Show();
                form.BringToFront();
                //tamaño del form igual al tamaño del panel
                form.Size = pnlcontent.Size;
            }
            else
            {
                form.BringToFront();
            }
        }

        //Sobrecarga del método OpenForm
        private void OpenFormPerfil()
        {
            PerfilForm form;
            form = pnlcontent.Controls.OfType<PerfilForm>().FirstOrDefault();

            if (form == null)
            {
                form = new PerfilForm(usuario);
                form.TopLevel = false;
                pnlcontent.Controls.Add(form);
                pnlcontent.Tag = form;
                form.CerrarSesion += new PerfilForm.logOut(CloseSession);
                form.Show();
                form.BringToFront();
                //tamaño del form igual al tamaño del panel
                form.Size = pnlcontent.Size;
            }
            else
            {
                form.Close();
                OpenFormPedidos();
            }
        }

        public void CloseSession()
        {
            this.Close();
        }

        //Sobrecarga del método OpenForm
        private void OpenFormPedidos()
        {
            PedidosForm form;
            form = pnlcontent.Controls.OfType<PedidosForm>().FirstOrDefault();

            if (form == null)
            {
                form = new PedidosForm();
                form.TopLevel = false;
                pnlcontent.Controls.Add(form);
                pnlcontent.Tag = form;
                form.VerFactura += new PedidosForm.showFactura(MostrarFactura);
                form.Show();
                form.BringToFront();
                //tamaño del form igual al tamaño del panel
                form.Size = pnlcontent.Size;
            }
            else
            {
                form.Close();
                OpenFormPedidos();
            }
        }

        private void MostrarFactura(Pedido pedido)
        {
            OpenFormFactura(pedido, usuario, true);
        }

        //sobrecarga para OpenForm
        private void OpenFormMenu()
        {
            MenuForm form;
            form = pnlcontent.Controls.OfType<MenuForm>().FirstOrDefault();

            if (form == null)
            {
                form = new MenuForm(usuario);
                form.TopLevel = false;
                pnlcontent.Controls.Add(form);
                pnlcontent.Tag = form;
                form.ConfirmPedido += new MenuForm.showFacturaPedido(ShowFactura);
                form.Show();
                form.BringToFront();
                //tamaño del form igual al tamaño del panel
                form.Size = pnlcontent.Size;
            }
            else
            {
                form.BringToFront();
            }
        }

        private void ShowFactura(Pedido pedido)
        {
            OpenFormFactura(pedido, usuario);
        }

        //sobrecarga para OpenForm
        private void OpenFormFactura(Pedido pedido, Usuario usuario, bool onlyView = false)
        {
            FacturaForm form;
            form = pnlcontent.Controls.OfType<FacturaForm>().FirstOrDefault();

            if (form == null)
            {
                form = new FacturaForm(pedido, usuario, onlyView);
                form.TopLevel = false;
                pnlcontent.Controls.Add(form);
                pnlcontent.Tag = form;
                form.Accion += new FacturaForm.actionFactura(AccionFactura);
                form.Show();
                form.BringToFront();
                pnlmenu.Enabled = false;
                //tamaño del form igual al tamaño del panel
                form.Size = pnlcontent.Size;
            }
            else
            {
                form.Close();
                OpenFormFactura(pedido, usuario);
            }
        }

        public void AccionFactura(bool actn)
        {
            if (actn)
            {
                pnlmenu.Enabled = true;
                OpenFormPedidos();
            }
            else
            {
                pnlmenu.Enabled = true;
                OpenFormMenu();
            }
        }

        #endregion

        private void pnlcontent_Resize(object sender, EventArgs e)
        {
            foreach (Form control in pnlcontent.Controls)
            {
                control.Size = pnlcontent.Size;
            }
        }
    }
}
