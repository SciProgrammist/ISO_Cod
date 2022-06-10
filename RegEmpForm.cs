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
using System.Text.RegularExpressions;

namespace Proyecto_Catedra_PEDG01T
{
    public partial class RegEmpForm : Form
    {
        public RegEmpForm()
        {
            InitializeComponent();
            dtpFechaNacimiento.CustomFormat = "yyyy-MM-dd";
        }

        private void btntypeuser_Click(object sender, EventArgs e)
        {
            cbxtypeuser.DroppedDown = !cbxtypeuser.DroppedDown;
        }

        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            if(txtnombre.Text != "")
            {
                if(txtApellido.Text != "")
                {
                    if (txtusuario.Text != "")
                    {
                        if (txtcontrasena.Text != "")
                        {
                            if (txtverificar.Text != "")
                            {
                                if (txtcontrasena.Text == txtverificar.Text)
                                {
                                    if (txtemail.Text != "")
                                    {
                                        if (txttelefono.Text != "")
                                        {
                                            if (cbxtypeuser.SelectedIndex > -1)
                                            {
                                                Usuario objUsuario = new Usuario();
                                                objUsuario.Nombre = txtnombre.Text;
                                                objUsuario.Apellido = txtApellido.Text;
                                                objUsuario.User = txtusuario.Text;
                                                objUsuario.Contrasena = txtcontrasena.Text;
                                                objUsuario.Email = txtemail.Text;
                                                objUsuario.Telefono = txttelefono.Text;
                                                objUsuario.IdtypeUser = obtenerId();
                                                objUsuario.FechaNacimiento = dtpFechaNacimiento.Value;
                                                objUsuario.SaveUserInDB();
                                                Limpiar();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Debe de seleccionar tipo de usuario", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Debe de ingresar teléfono", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe de ingresar correo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Las contraseñas no coinciden", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe de ingresar verificaciónd de contraseña", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe de ingresar contraseña", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de ingresar usuario", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar apellido", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                   
            }
            else
            {
                MessageBox.Show("Debe de ingresar nombre", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string obtenerId()
        {
            if(cbxtypeuser.SelectedItem.ToString() == "Administrador")
            {
                return "1";
            }
            
            if(cbxtypeuser.SelectedItem.ToString() == "Empleado")
            {
                return "2";
            }

            return "0";
        }

        public void Limpiar()
        {
            txtnombre.Clear();
            txtApellido.Clear();
            txtusuario.Clear();
            txtcontrasena.Clear();
            txtemail.Clear();
            txtverificar.Clear();
            txttelefono.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            cbxtypeuser.SelectedIndex = -1;
        }
        
        
        private void txtnombre_KeyPress(object sender, KeyPressEventArgs ex)
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
                MessageBox.Show("Solo se admiten letras en el campo de Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs ex)
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
                MessageBox.Show("Solo se admiten letras en este campo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //Función para validar el formato del correo
        public static bool ValidarcorreoE(string correo)
        {
            string ex = "^([da-z_.-]+)@([da-z.-]+).([a-z.]{2,6})$";
            if (Regex.IsMatch(correo, ex))
            {
                if (Regex.Replace(correo, ex, string.Empty).Length == 0) 
                { 
                    return true; 
                
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Función para validar el formato del telefono
        public static bool Validartelefono(string tel)
        {
            string ex = "[0-9]{8}";
            if (Regex.IsMatch(tel, ex))
            {
                if (Regex.Replace(tel, ex, string.Empty).Length == 0)
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (ValidarcorreoE(txtemail.Text)==false)
            {
                MessageBox.Show("El formato del correo electrónico no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtemail.Focus();
            }
        }

        private void txttelefono_Leave(object sender, EventArgs e)
        {
            if (Validartelefono(txttelefono.Text)==false) { }
            else
            {
                MessageBox.Show("El formato del teléfono no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txttelefono.Focus();

            }

        }
    }
}
