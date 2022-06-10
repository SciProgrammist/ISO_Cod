using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PEDG01T
{
    public partial class AddProductoForm : Form
    {
        MemoryStream img;
        bool imgSelected = false;

        public AddProductoForm()
        {
            InitializeComponent();
        }

        //Método que nos ayuda a controlar campos de solo numeros decimales
        private bool ValidarSoloNumeros(KeyPressEventArgs e, TextBox txt)
        {
            bool a;
            Regex punto = new Regex(@"\A([.])\Z");
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                a = true;
                e.Handled = false;
            }
            else if (punto.IsMatch(e.KeyChar.ToString()))
            {
                if (txt.Text.Contains("."))
                {
                    a = false;
                    e.Handled = true;
                }
                else
                {
                    a = true;
                    e.Handled = false;
                }
            }
            else
            {
                a = false;
                e.Handled = true;
            }
            return a;
        }

        private void txtpriceproduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e, (TextBox)sender);
        }

        //Método que valida que los campos esten completos
        private bool Validar()
        {
            bool validado = true;
            if (string.IsNullOrEmpty(txtdescrproduct.Text) || string.IsNullOrEmpty(txtnameproduct.Text) || string.IsNullOrEmpty(txtpriceproduct.Text))
            {
                validado = false;
                MessageBox.Show("No debe dejar campos vacíos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!imgSelected)
            {
                MessageBox.Show("Debe seleccionar una imagen para el producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return validado;
        }

        //Método que limpia el formulario
        private void Limpiar()
        {
            txtnameproduct.Clear();
            txtpriceproduct.Clear();
            txtdescrproduct.Clear();
            btnaddphoto.BackgroundImage = Properties.Resources.add_a_photo;
            img = null;
            imgSelected = false;
        }

        //Evento del btnaddphoto para seleccionar foto
        private void btnaddphoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*JPEG)|*.BMP;*.JPG;*.PNG;*JPEG";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                btnaddphoto.BackgroundImage = Image.FromFile(openFile.FileName);
                imgSelected = true;
            }
        }

        //Cierra el form para añadir productos
        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Limpia y reinicia los campos del form
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //agrega el producto a la DB
        private void btnaddproduct_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                img = new MemoryStream();
                btnaddphoto.BackgroundImage.Save(img, ImageFormat.Jpeg);

                Producto producto = new Producto();
                producto.Nombre = txtnameproduct.Text;
                producto.Precio = Convert.ToDouble(txtpriceproduct.Text);
                producto.Descripcion = txtdescrproduct.Text;
                producto.PhotoProducto = img.GetBuffer();
                //verificamos si se ingreso el registro
                if (producto.AddProducto())
                {
                    Limpiar();
                    MessageBox.Show("El producto fue agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                img = null;
            }
        }

    }
}
