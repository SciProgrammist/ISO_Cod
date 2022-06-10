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
    public partial class AdmProductoForm : Form
    {
        Producto[] productos;
        Producto prdEdit;
        MemoryStream img;

        public AdmProductoForm()
        {
            InitializeComponent();
            UpdateControls();
        }

        #region Métodos del formulario

        //Método que actualiza la información de los controles
        public void UpdateControls()
        {
            //Limpiamos controles para evitar duplicidad
            dgvproductos.Rows.Clear();
            cbxproductos.Items.Clear();


            this.Cursor = Cursors.WaitCursor;
            //Extraemos la lista de productos
            Lista listaProductos = Producto.GetProductos();
            //inicializamos array para productos;
            productos = new Producto[listaProductos.Count()];

            //recorremos la lista para llenar el array
            for (int i = 0; i < listaProductos.Count(); i++)
            {
                productos[i] = (Producto)listaProductos.ElementAtIndex(i);    
            }

            //recorremos el array para llenar los controles
            foreach (Producto item in productos)
            {
                dgvproductos.Rows.Add(item.Id, item.Codigo, item.Nombre, item.Precio, item.Descripcion);
                cbxproductos.Items.Add(item.Codigo);
            }
            this.Cursor = Cursors.Default;
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

        //Método que limpia los texboxs y otros controles
        private void Limpiar()
        {
            txtnameproduct.Clear();
            txtpriceproduct.Clear();
            txtdescrproduct.Clear();
            cbxproductos.SelectedIndex = -1;
            btnaddphoto.BackgroundImage = Properties.Resources.add_a_photo;
        }

        //Método para validar los campos al editar productos
        private bool Validar()
        {
            bool validado = true;
            errProvider.Clear();

            if (string.IsNullOrEmpty(txtnameproduct.Text))
            {
                validado = false;
                errProvider.SetError(txtnameproduct, "Debe completar este campo");
            }

            if (string.IsNullOrEmpty(txtpriceproduct.Text))
            {
                validado = false;
                errProvider.SetError(txtpriceproduct, "Debe completar este campo");
            }

            if (string.IsNullOrEmpty(txtdescrproduct.Text))
            {
                validado = false;
                errProvider.SetError(txtdescrproduct, "Debe completar este campo");
            }

            return validado;
        }

        #endregion Fin métodos del formulario

        #region Eventos del formulario

        //evento que se encarga de actualizar los datos en el form
        private void btnupdateData_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        //evento para comenzar edición de un producto
        private void btneditproduct_Click(object sender, EventArgs e)
        {
            if (cbxproductos.SelectedIndex != -1)
            {
                //instancia Producto que contendra el objeto a editar
                prdEdit = new Producto();
                foreach (Producto producto in productos)
                {
                    if (producto.Codigo == cbxproductos.SelectedItem.ToString())
                        prdEdit = producto;
                }

                //llenamos un Stream con el buffer PhotoProducto para después crear la imagen
                img = new MemoryStream(prdEdit.PhotoProducto);

                //Habilitamos el panel de edición
                pnleditproduct.Enabled = true;

                //Colocamos los datos a actualizar en los controles
                btnaddphoto.BackgroundImage = Image.FromStream(img);
                txtnameproduct.Text = prdEdit.Nombre;
                txtpriceproduct.Text = prdEdit.Precio.ToString();
                txtdescrproduct.Text = prdEdit.Descripcion;

                //borramos instancia de stream
                img = null;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //evento keypress para control de campo de solo números
        private void txtpriceproduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarSoloNumeros(e, (TextBox)sender);
        }

        //evento para borrar producto
        private void btndeleteproduct_Click(object sender, EventArgs e)
        {
            if (cbxproductos.SelectedIndex != -1)
            {
                foreach (Producto producto in productos)
                {
                    if (producto.Codigo == cbxproductos.SelectedItem.ToString())
                    {
                        DialogResult result = MessageBox.Show("¿Realmente desea eliminar el registro de este producto?", 
                            "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            if (Producto.DeleteProducto(producto.Id))
                            {
                                MessageBox.Show("El producto fue borrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UpdateControls();
                                Limpiar();
                                pnleditproduct.Enabled = false;
                            }
                        }
                        break;
                    }
                }
            }
        }

        //evento para cancelar la selección de un producto
        private void btncancel_Click(object sender, EventArgs e)
        {
            Limpiar();
            pnleditproduct.Enabled = false;
            prdEdit = null;
        }

        //evento para actualizar producto
        private void btnupdateproduct_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (prdEdit != null)
                {
                    //Extraemos imagen
                    img = new MemoryStream();
                    btnaddphoto.BackgroundImage.Save(img, ImageFormat.Jpeg);

                    //actualizamos los datos en el objeto
                    prdEdit.Nombre = txtnameproduct.Text;
                    prdEdit.Precio = Convert.ToDouble(txtpriceproduct.Text);
                    prdEdit.Descripcion = txtdescrproduct.Text;
                    prdEdit.PhotoProducto = img.GetBuffer();

                    //Actualizamos en la DB
                    if (prdEdit.UpdateProducto())
                    {
                        MessageBox.Show("Registro actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateControls();
                        Limpiar();
                        pnleditproduct.Enabled = false;
                    }

                    img = null;
                }
                else
                    MessageBox.Show("No esta editando ningún registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //evento para cancelar edición
        private void btncancelupdate_Click(object sender, EventArgs e)
        {
            Limpiar();
            pnleditproduct.Enabled = false;
            prdEdit = null;
        }
        //evento para selección de foto
        private void btnaddphoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*JPEG)|*.BMP;*.JPG;*.PNG;*JPEG";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                btnaddphoto.BackgroundImage = Image.FromFile(openFile.FileName);
            }
        }

        #endregion Fin eventos del formulario

        

       
    }
}
