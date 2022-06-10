using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Proyecto_Catedra_PEDG01T
{
    public partial class PerfilForm : Form
    {
        private Usuario usuario;

        //delegado para comunicar con el form Inicio
        public delegate void logOut();
        public event logOut CerrarSesion;

        public PerfilForm(Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
            lblmostrarnombre.Text = usuario.Nombre + " " + usuario.Apellido;
            lblmostrarusuario.Text = usuario.User;
            lblmostrarfnaci.Text = usuario.FechaNacimiento.ToShortDateString();
            lblmostrarcorreo.Text = usuario.Email;
            lblmostrartel.Text = usuario.Telefono;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            EditPerfilForm edit = new EditPerfilForm(usuario);
            DialogResult result = edit.ShowDialog();
            if (result == DialogResult.OK)
            {
                CerrarSesion();
            }
        }
    }
}
