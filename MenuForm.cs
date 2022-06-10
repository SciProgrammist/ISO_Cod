using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PEDG01T
{
    public partial class MenuForm : Form
    {
        Lista listPrdt;
        Producto[] productos;
        MemoryStream img;
        private Usuario user;

        //delegado para comunicar con el form Inicio
        public delegate void showFacturaPedido(Pedido pedido);
        public event showFacturaPedido ConfirmPedido;

        public MenuForm(Usuario user)
        {
            InitializeComponent();
            this.user = user;
            CreateCuadrosPrdt();
        }

        //--- MÉTODOS DEL FORMULARIO ---//

        //crea los productos graficamente
        private void CreateProducts(Producto producto, int x, int y)
        {
            //configuramos la imagen
            img = new MemoryStream(producto.PhotoProducto);

            //panel
            Panel panelProducto = new Panel
            {
                Location = new Point(x, y),
                Name = "pnlproducto" + producto.Id,
                Size = new Size(156, 190),
                Anchor = AnchorStyles.Top,
                Tag = 0
            };

            //PictureBox
            PictureBox picProducto = new PictureBox
            {
                Image = Image.FromStream(img),
                Location = new Point(38, 1),
                Name = "pbxproduct",
                Size = new Size(80, 80),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // label nombre del producto
            Label lblNombreProducto = new Label
            {
                Font = new Font("Roboto Bk", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.FromArgb(38, 38, 38),
                Location = new Point(3, 81),
                Name = "lblnameproduct" + producto.Id,
                Size = new Size(150, 23),
                Text = producto.Nombre,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // label precio producto
            Label lblPrecioProducto = new Label
            {
                Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.FromArgb(38, 38, 38),
                Location = new Point(3, 99),
                Name = "lblpriceproduct" + producto.Id,
                Size = new Size(150, 23),
                Text = producto.Precio.ToString(),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // label cantidad producto
            Label lblCantProducto = new Label
            {
                Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.FromArgb(38, 38, 38),
                Location = new Point(48, 123),
                Name = "lblcantproduct" + producto.Id,
                Size = new Size(61, 23),
                Text = "0",
                TextAlign = ContentAlignment.MiddleCenter
            };

            // btn seleccionar producto
            Button btnAddProducto = new Button();
            btnAddProducto.BackColor = Color.FromArgb(255, 135, 48);
            btnAddProducto.FlatAppearance.BorderSize = 0;
            btnAddProducto.FlatStyle = FlatStyle.Flat;
            btnAddProducto.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddProducto.ForeColor = Color.White;
            btnAddProducto.Location = new Point(1, 158);
            btnAddProducto.Name = "btnaddproduct" + producto.Id;
            btnAddProducto.Size = new Size(75, 30);
            btnAddProducto.Text = "Añadir";
            btnAddProducto.Tag = producto.Id;
            btnAddProducto.UseVisualStyleBackColor = false;
            btnAddProducto.Click += btnAdd_Click;

            // btn cancelar selección del producto
            Button btnCancelProducto = new Button();
            btnCancelProducto.BackColor = Color.FromArgb(231, 71, 61);
            btnCancelProducto.FlatAppearance.BorderSize = 0;
            btnCancelProducto.FlatStyle = FlatStyle.Flat;
            btnCancelProducto.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelProducto.ForeColor = Color.White;
            btnCancelProducto.Location = new Point(80, 158);
            btnCancelProducto.Name = "btncancelproduct" + producto.Id;
            btnCancelProducto.Size = new Size(75, 30);
            btnCancelProducto.Text = "Cancelar";
            btnCancelProducto.Tag = producto.Id;
            btnCancelProducto.UseVisualStyleBackColor = false;
            btnCancelProducto.Click += btnCancel_Click;

            //btn quitar producto (unidad)
            Button btnsuprProducto = new Button();
            btnsuprProducto.BackColor = Color.FromArgb(231, 71, 61);
            btnsuprProducto.FlatAppearance.BorderSize = 0;
            btnsuprProducto.FlatStyle = FlatStyle.Flat;
            btnsuprProducto.Font = new Font("Lucida Sans Unicode", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnsuprProducto.ForeColor = Color.White;
            btnsuprProducto.Location = new Point(114, 121);
            btnsuprProducto.Name = "btnsuprproduct" + producto.Id;
            btnsuprProducto.Size = new Size(26, 26);
            btnsuprProducto.Text = "-";
            btnsuprProducto.UseVisualStyleBackColor = false;
            btnsuprProducto.Tag = producto.Id;
            btnsuprProducto.Enabled = false;
            btnsuprProducto.Click += btnsuprProducto_Click;

            //btn insertar producto (unidad)
            Button btnInsertProducto = new Button();
            btnInsertProducto.BackColor = Color.FromArgb(0, 190, 30);
            btnInsertProducto.FlatAppearance.BorderSize = 0;
            btnInsertProducto.FlatStyle = FlatStyle.Flat;
            btnInsertProducto.Font = new Font("Lucida Sans Unicode", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInsertProducto.ForeColor = Color.White;
            btnInsertProducto.Location = new Point(20, 121);
            btnInsertProducto.Name = "btninsrtproduct" + producto.Id;
            btnInsertProducto.Size = new Size(26, 26);
            btnInsertProducto.Text = "+";
            btnInsertProducto.UseVisualStyleBackColor = false;
            btnInsertProducto.Tag = producto.Id;
            btnInsertProducto.Enabled = false;
            btnInsertProducto.Click += btninsrtproduct_Click;

            //Añadiendo los controles al panel
            panelProducto.Controls.Add(picProducto);
            panelProducto.Controls.Add(lblNombreProducto);
            panelProducto.Controls.Add(lblPrecioProducto);
            panelProducto.Controls.Add(lblCantProducto);
            panelProducto.Controls.Add(btnInsertProducto);
            panelProducto.Controls.Add(btnsuprProducto);
            panelProducto.Controls.Add(btnAddProducto);
            panelProducto.Controls.Add(btnCancelProducto);

            //Añadiendo toda la interfaz del producto al panel principal
            pnlProductos.Controls.Add(panelProducto);
        }

        private  void CreateCuadrosPrdt()
        {
            listPrdt = Producto.GetProductos();
            ////llenamos el array con los productos
            productos = new Producto[listPrdt.Count()];
            for (int i = 0; i < listPrdt.Count(); i++)
            {
                productos[i] = (Producto)listPrdt.ElementAtIndex(i);
            }

            //variables para creación de filas y columnas
            int count = 0, columns = 0, rows = 1;
            //variables para posición
            int x = 17, y = 14;

            //recorremos los productos para crear sus controladores y sus cuadros en el interfaz gráfica
            foreach (Producto producto in productos)
            {
                count++;
                columns++;
                CreateProducts(producto, x, y);

                //modificamos el valor de x , y
                x += 229;
                if (columns == 4)
                {
                    rows++;
                    y += 215;
                    x = 17;
                    columns = 0;
                }
            }

        }

        //Método que devuelve una lista de los productos seleccionados
        private void GetSelectedProducts()
        {
            //lista que contendra los detalles del pedido (productos selecionados, cantidad, etc)
            Lista prdtDetails = new Lista();
            int countProducts = 0;
            DetallePedido detallePedido;


            //recorremos los paneles de los productos
            foreach (Panel pnlproducto in pnlProductos.Controls)
            {
                //verificamos si esta seleccionado y cual es
                if (Convert.ToInt32(pnlproducto.Tag) != 0)
                {
                    countProducts++;
                    //recorremos los productos en busca del seleccionado
                    foreach (Producto producto in productos)
                    {
                        if (producto.Id == Convert.ToInt32(pnlproducto.Tag))
                        {
                            //Creamos objeto DetallePedido y lo añadimos a la lista
                            detallePedido = new DetallePedido
                            {
                                IdProducto = producto.Id,
                                CodigoProducto = producto.Codigo,
                                NombreProducto = producto.Nombre,
                                PrecioProducto = producto.Precio,
                                Cantidad = CantProducto(pnlproducto, producto.Id)
                            };
                            detallePedido.PrecioTotalD();
                            prdtDetails.Add(detallePedido);
                            detallePedido = null;
                            break;
                        }
                    }
                }
            }

            if (countProducts == 0)
            {
                MessageBox.Show("Debe selecionar productos para poder crear el pedido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CreatePedido(prdtDetails);
            }
        }

        //Método que crea el objeto pedido
        private void CreatePedido(Lista detallesPedido)
        {
            DateTime date = DateTime.Now;

            Pedido pedido = new Pedido
            {
                EstadoPedido = 0,
                IdUsuario = user.IdUsuario,
                DetallePed = detallesPedido,
                FechaPedido = date.Date.ToShortDateString()
            };
            pedido.calcularTotal();

            //ejecutamos el evento ConfirmPedido para pasar el pedido al Form inicio y despues al Form Factura
            ConfirmPedido(pedido);
            this.Close();
        }

        //Método que extrae la cantidad seleccionada de un producto, el parametro es el panel del producto y el id
        private int CantProducto(Panel producto, int IdProducto)
        {
            Label cantidad = (Label)producto.Controls.Find("lblcantproduct" + IdProducto, false)[0];
            return Convert.ToInt32(cantidad.Text);
        }

        //--- FIN MÉTODOS DEL FORMULARIO ---//

        //--- EVENTOS DEL FORMULARIO ---//

        //evento que limpia el formulario
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            //recorremos los paneles de los productos
            foreach (Panel pnlproducto in pnlProductos.Controls)
            {
                foreach (Producto producto in productos)
                {
                    if (producto.Id == Convert.ToInt32(pnlproducto.Tag))
                    {
                        ((Button)pnlproducto.Controls.Find("btncancelproduct" + producto.Id, false)[0]).PerformClick();
                        break;
                    }
                }
                pnlproducto.Tag = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Button btnAdd = (Button)sender;
            //Buscamos loa botones + y - y los activamos
            btnAdd.Parent.Controls.Find("btninsrtproduct" + btnAdd.Tag.ToString(), false)[0].Enabled = true;
            btnAdd.Parent.Controls.Find("btnsuprproduct" + btnAdd.Tag.ToString(), false)[0].Enabled = true;

            //Iniciamos el cantador de cantidad con almenos 1
            Label lblcant = (Label)btnAdd.Parent.Controls.Find("lblcantproduct" + btnAdd.Tag.ToString(), false)[0];
            lblcant.Text = (Convert.ToInt32(lblcant.Text) + 1).ToString();

            //Pasamos el id del producto a la porpiedad tag del panel, esto es para saber que el producto si selecciono y especificar cual es
            btnAdd.Parent.Tag = Convert.ToInt32(btnAdd.Tag); //btnAdd.Tag contiene el id del producto
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Button btnCancel = (Button)sender;
            //Buscamos loa botones + y - y los desactivamos
            btnCancel.Parent.Controls.Find("btninsrtproduct" + btnCancel.Tag.ToString(), false)[0].Enabled = false;
            btnCancel.Parent.Controls.Find("btnsuprproduct" + btnCancel.Tag.ToString(), false)[0].Enabled = false;

            //ponemos la cantidad en 0
            Label lblcant = (Label)btnCancel.Parent.Controls.Find("lblcantproduct" + btnCancel.Tag.ToString(), false)[0];
            lblcant.Text = "0";
        }

        //evento para botones +
        private void btninsrtproduct_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //accedemos al panel (btn.parent) y buscamos el label con la cantidad, lo buscamos por nombrelabel + codigoProducto
            Label lblcant = (Label)btn.Parent.Controls.Find("lblcantproduct" + btn.Tag.ToString(), false)[0];
            lblcant.Text = (Convert.ToInt32(lblcant.Text) + 1).ToString();
        }

        //evento para botones -
        private void btnsuprProducto_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //accedemos al panel (btn.parent) y buscamos el label con la cantidad, lo buscamos por nombrelabel + codigoProducto
            Label lblcant = (Label)btn.Parent.Controls.Find("lblcantproduct" + btn.Tag.ToString(), false)[0];
            //validamos para que la cantidad no sea menor que 1
            if (Convert.ToInt32(lblcant.Text) > 1)
            {
                lblcant.Text = (Convert.ToInt32(lblcant.Text) - 1).ToString();
            }
        }

        private void btncrearpedido_Click(object sender, EventArgs e)
        {
            GetSelectedProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //recorremos los paneles de los productos
            foreach (Panel pnlproducto in pnlProductos.Controls)
            {
                foreach (Producto producto in productos)
                {
                    if (producto.Id == Convert.ToInt32(pnlproducto.Tag))
                    {
                        ((Button)pnlproducto.Controls.Find("btncancelproduct" + producto.Id, false)[0]).PerformClick();
                        break;
                    }
                }
                pnlproducto.Tag = 0;
            }
        }

        //--- FIN EVENTOS DEL FORMULARIO ---//
    }
}
