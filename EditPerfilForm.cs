using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PEDG01T
{
    public partial class EditPerfilForm : Form
    {
        private Usuario usuario;
        public EditPerfilForm(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            dtpFechaNacimiento.CustomFormat = "yyyy-MM-dd";

            //llenamos los campos
            txtnombre.Text = usuario.Nombre;
            txtapellido.Text = usuario.Apellido;
            txtusuario.Text = usuario.User;
            txtcorreo.Text = usuario.Email;
            txttelefono.Text = usuario.Telefono;
            dtpFechaNacimiento.Value = usuario.FechaNacimiento;
            txtcontra.Text = usuario.Contrasena;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //Función para validar el formato del telefono
        public static bool Validartelefono(string tel)
        {
            string ex = "[0-9]{8}";
            if (Regex.IsMatch(tel, ex))
            {
                if (Regex.Replace(tel, ex, string.Empty).Length == 0)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }

        private void txttelefono_Leave(object sender, EventArgs e)
        {
            if (Validartelefono(txttelefono.Text))
            {
                MessageBox.Show("El formato de telefono es incorrecto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Función para validar el formato del correo
        public static bool ValidarcorreoE(string correo)
        {
            string ex = "^([da-z_.-]+)@([da-z.-]+).([a-z.]{2,6})$";
            if (Regex.IsMatch(correo, ex))
            {
                if (Regex.Replace(correo, ex, string.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void txtcorreo_Leave(object sender, EventArgs e)
        {
            if (ValidarcorreoE(txtcorreo.Text))
            {
                MessageBox.Show("El formato del email es incorrecto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void only_letters(object sender, KeyPressEventArgs ex)
        {
            if (char.IsLetter(ex.KeyChar))
            {
                ex.Handled = false;
            }
            else if (char.IsControl(ex.KeyChar))
            {
                ex.Handled = false;
            }
            else if (char.IsSeparator(ex.KeyChar))
            {
                ex.Handled = false;
            }
            else
            {
                ex.Handled = true;
                MessageBox.Show("Este campo solo admite letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //validando todos los campos
        public bool Validar()
        {
            bool validado = true;
            errprv.Clear();

            if (string.IsNullOrEmpty(txtnombre.Text))
            {
                errprv.SetError(txtnombre, "Debe completar este campo.");
                validado = false;
            }
            if (string.IsNullOrEmpty(txtapellido.Text))
            {
                errprv.SetError(txtapellido, "Debe completar este campo.");
                validado = false;
            }
            if (string.IsNullOrEmpty(txtusuario.Text))
            {
                errprv.SetError(txtusuario, "Debe completar este campo.");
                validado = false;
            }
            if (string.IsNullOrEmpty(txtcorreo.Text))
            {
                errprv.SetError(txtcorreo, "Debe completar este campo.");
                validado = false;
            }
            if (string.IsNullOrEmpty(txttelefono.Text))
            {
                errprv.SetError(txttelefono, "Debe completar este campo.");
                validado = false;
            }
            if (string.IsNullOrEmpty(txtcontra.Text))
            {
                errprv.SetError(txtcontra, "Debe completar este campo.");
                validado = false;
            }
            if (string.IsNullOrEmpty(txtccontra.Text))
            {
                errprv.SetError(txtccontra, "Debe completar este campo.");
                validado = false;
            }
            if (txtcontra.Text != txtccontra.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden, asegurese de ingresarlas correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                validado = false;
            }

            return validado;
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                usuario.Nombre = txtnombre.Text;
                usuario.Apellido = txtapellido.Text;
                usuario.User = txtusuario.Text;
                usuario.Email = txtcorreo.Text;
                usuario.FechaNacimiento = dtpFechaNacimiento.Value;
                usuario.Telefono = txttelefono.Text;
                usuario.Contrasena = txtcontra.Text;
                if (usuario.UpdateUser())
                {
                    MessageBox.Show("Se actualizo exitosamente su información, vuelva a inicie sesión para actualizar los cambios.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                    DialogResult = DialogResult.No;

                this.Close();
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtusuario.Clear();
            txtcontra.Clear();
            txtccontra.Clear();
            txtcorreo.Clear();
            txttelefono.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
        }
    }
}
