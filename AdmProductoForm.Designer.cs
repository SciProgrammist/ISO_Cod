namespace Proyecto_Catedra_PEDG01T
{
    partial class AdmProductoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbladmproduct = new System.Windows.Forms.Label();
            this.cbxproductos = new System.Windows.Forms.ComboBox();
            this.lblselecproduct = new System.Windows.Forms.Label();
            this.btneditproduct = new System.Windows.Forms.Button();
            this.btndeleteproduct = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.lblproductos = new System.Windows.Forms.Label();
            this.dgvproductos = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnleditproduct = new System.Windows.Forms.Panel();
            this.btncancelupdate = new System.Windows.Forms.Button();
            this.btnupdateproduct = new System.Windows.Forms.Button();
            this.txtdescrproduct = new System.Windows.Forms.TextBox();
            this.lbldescline = new System.Windows.Forms.Label();
            this.lbldescrproduct = new System.Windows.Forms.Label();
            this.txtpriceproduct = new System.Windows.Forms.TextBox();
            this.lblpriceline = new System.Windows.Forms.Label();
            this.lblpriceproduct = new System.Windows.Forms.Label();
            this.txtnameproduct = new System.Windows.Forms.TextBox();
            this.lblnameline = new System.Windows.Forms.Label();
            this.lblnameproduct = new System.Windows.Forms.Label();
            this.lblimgproduct = new System.Windows.Forms.Label();
            this.btnaddphoto = new System.Windows.Forms.Button();
            this.btnupdateData = new System.Windows.Forms.Button();
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).BeginInit();
            this.pnleditproduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbladmproduct
            // 
            this.lbladmproduct.AutoSize = true;
            this.lbladmproduct.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladmproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lbladmproduct.Location = new System.Drawing.Point(39, 32);
            this.lbladmproduct.Name = "lbladmproduct";
            this.lbladmproduct.Size = new System.Drawing.Size(250, 29);
            this.lbladmproduct.TabIndex = 2;
            this.lbladmproduct.Text = "Administrar productos";
            // 
            // cbxproductos
            // 
            this.cbxproductos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxproductos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxproductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxproductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxproductos.FormattingEnabled = true;
            this.cbxproductos.Location = new System.Drawing.Point(205, 116);
            this.cbxproductos.Name = "cbxproductos";
            this.cbxproductos.Size = new System.Drawing.Size(167, 21);
            this.cbxproductos.TabIndex = 4;
            // 
            // lblselecproduct
            // 
            this.lblselecproduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblselecproduct.AutoSize = true;
            this.lblselecproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblselecproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblselecproduct.Location = new System.Drawing.Point(41, 119);
            this.lblselecproduct.Name = "lblselecproduct";
            this.lblselecproduct.Size = new System.Drawing.Size(152, 16);
            this.lblselecproduct.TabIndex = 3;
            this.lblselecproduct.Text = "Selecciona un producto:";
            // 
            // btneditproduct
            // 
            this.btneditproduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btneditproduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.btneditproduct.FlatAppearance.BorderSize = 0;
            this.btneditproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneditproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneditproduct.ForeColor = System.Drawing.Color.White;
            this.btneditproduct.Location = new System.Drawing.Point(44, 200);
            this.btneditproduct.Name = "btneditproduct";
            this.btneditproduct.Size = new System.Drawing.Size(100, 30);
            this.btneditproduct.TabIndex = 5;
            this.btneditproduct.Text = "Editar producto";
            this.btneditproduct.UseVisualStyleBackColor = false;
            this.btneditproduct.Click += new System.EventHandler(this.btneditproduct_Click);
            // 
            // btndeleteproduct
            // 
            this.btndeleteproduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btndeleteproduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(71)))), ((int)(((byte)(61)))));
            this.btndeleteproduct.FlatAppearance.BorderSize = 0;
            this.btndeleteproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeleteproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeleteproduct.ForeColor = System.Drawing.Color.White;
            this.btndeleteproduct.Location = new System.Drawing.Point(181, 200);
            this.btndeleteproduct.Name = "btndeleteproduct";
            this.btndeleteproduct.Size = new System.Drawing.Size(100, 30);
            this.btndeleteproduct.TabIndex = 6;
            this.btndeleteproduct.Text = "Borrar producto";
            this.btndeleteproduct.UseVisualStyleBackColor = false;
            this.btndeleteproduct.Click += new System.EventHandler(this.btndeleteproduct_Click);
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btncancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(317, 200);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(100, 30);
            this.btncancel.TabIndex = 7;
            this.btncancel.Text = "Cancelar";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // lblproductos
            // 
            this.lblproductos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblproductos.AutoSize = true;
            this.lblproductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblproductos.Location = new System.Drawing.Point(41, 290);
            this.lblproductos.Name = "lblproductos";
            this.lblproductos.Size = new System.Drawing.Size(72, 16);
            this.lblproductos.TabIndex = 8;
            this.lblproductos.Text = "Productos:";
            // 
            // dgvproductos
            // 
            this.dgvproductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cod,
            this.name,
            this.price,
            this.description});
            this.dgvproductos.Location = new System.Drawing.Point(44, 326);
            this.dgvproductos.Name = "dgvproductos";
            this.dgvproductos.Size = new System.Drawing.Size(433, 184);
            this.dgvproductos.TabIndex = 9;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // cod
            // 
            this.cod.HeaderText = "Codigo";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            // 
            // price
            // 
            this.price.HeaderText = "Precio";
            this.price.Name = "price";
            // 
            // description
            // 
            this.description.HeaderText = "Descripción";
            this.description.Name = "description";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.panel1.Location = new System.Drawing.Point(511, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 475);
            this.panel1.TabIndex = 10;
            // 
            // pnleditproduct
            // 
            this.pnleditproduct.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnleditproduct.Controls.Add(this.btncancelupdate);
            this.pnleditproduct.Controls.Add(this.btnupdateproduct);
            this.pnleditproduct.Controls.Add(this.txtdescrproduct);
            this.pnleditproduct.Controls.Add(this.lbldescline);
            this.pnleditproduct.Controls.Add(this.lbldescrproduct);
            this.pnleditproduct.Controls.Add(this.txtpriceproduct);
            this.pnleditproduct.Controls.Add(this.lblpriceline);
            this.pnleditproduct.Controls.Add(this.lblpriceproduct);
            this.pnleditproduct.Controls.Add(this.txtnameproduct);
            this.pnleditproduct.Controls.Add(this.lblnameline);
            this.pnleditproduct.Controls.Add(this.lblnameproduct);
            this.pnleditproduct.Controls.Add(this.lblimgproduct);
            this.pnleditproduct.Controls.Add(this.btnaddphoto);
            this.pnleditproduct.Enabled = false;
            this.pnleditproduct.Location = new System.Drawing.Point(522, 59);
            this.pnleditproduct.Name = "pnleditproduct";
            this.pnleditproduct.Size = new System.Drawing.Size(366, 475);
            this.pnleditproduct.TabIndex = 29;
            // 
            // btncancelupdate
            // 
            this.btncancelupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(71)))), ((int)(((byte)(61)))));
            this.btncancelupdate.FlatAppearance.BorderSize = 0;
            this.btncancelupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancelupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancelupdate.ForeColor = System.Drawing.Color.White;
            this.btncancelupdate.Location = new System.Drawing.Point(223, 419);
            this.btncancelupdate.Name = "btncancelupdate";
            this.btncancelupdate.Size = new System.Drawing.Size(100, 30);
            this.btncancelupdate.TabIndex = 30;
            this.btncancelupdate.Text = "Cancelar edición";
            this.btncancelupdate.UseVisualStyleBackColor = false;
            this.btncancelupdate.Click += new System.EventHandler(this.btncancelupdate_Click);
            // 
            // btnupdateproduct
            // 
            this.btnupdateproduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.btnupdateproduct.FlatAppearance.BorderSize = 0;
            this.btnupdateproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdateproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdateproduct.ForeColor = System.Drawing.Color.White;
            this.btnupdateproduct.Location = new System.Drawing.Point(46, 419);
            this.btnupdateproduct.Name = "btnupdateproduct";
            this.btnupdateproduct.Size = new System.Drawing.Size(100, 30);
            this.btnupdateproduct.TabIndex = 30;
            this.btnupdateproduct.Text = "Actualizar";
            this.btnupdateproduct.UseVisualStyleBackColor = false;
            this.btnupdateproduct.Click += new System.EventHandler(this.btnupdateproduct_Click);
            // 
            // txtdescrproduct
            // 
            this.txtdescrproduct.BackColor = System.Drawing.Color.White;
            this.txtdescrproduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdescrproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescrproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtdescrproduct.Location = new System.Drawing.Point(28, 351);
            this.txtdescrproduct.Multiline = true;
            this.txtdescrproduct.Name = "txtdescrproduct";
            this.txtdescrproduct.Size = new System.Drawing.Size(302, 20);
            this.txtdescrproduct.TabIndex = 38;
            // 
            // lbldescline
            // 
            this.lbldescline.AutoSize = true;
            this.lbldescline.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.lbldescline.Location = new System.Drawing.Point(23, 360);
            this.lbldescline.Name = "lbldescline";
            this.lbldescline.Size = new System.Drawing.Size(320, 17);
            this.lbldescline.TabIndex = 39;
            this.lbldescline.Text = "_______________________________________";
            // 
            // lbldescrproduct
            // 
            this.lbldescrproduct.AutoSize = true;
            this.lbldescrproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescrproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lbldescrproduct.Location = new System.Drawing.Point(23, 325);
            this.lbldescrproduct.Name = "lbldescrproduct";
            this.lbldescrproduct.Size = new System.Drawing.Size(173, 18);
            this.lbldescrproduct.TabIndex = 37;
            this.lbldescrproduct.Text = "Descripción del producto";
            // 
            // txtpriceproduct
            // 
            this.txtpriceproduct.BackColor = System.Drawing.Color.White;
            this.txtpriceproduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpriceproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpriceproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtpriceproduct.Location = new System.Drawing.Point(28, 276);
            this.txtpriceproduct.Multiline = true;
            this.txtpriceproduct.Name = "txtpriceproduct";
            this.txtpriceproduct.Size = new System.Drawing.Size(297, 20);
            this.txtpriceproduct.TabIndex = 35;
            this.txtpriceproduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpriceproduct_KeyPress);
            // 
            // lblpriceline
            // 
            this.lblpriceline.AutoSize = true;
            this.lblpriceline.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpriceline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.lblpriceline.Location = new System.Drawing.Point(23, 285);
            this.lblpriceline.Name = "lblpriceline";
            this.lblpriceline.Size = new System.Drawing.Size(320, 17);
            this.lblpriceline.TabIndex = 36;
            this.lblpriceline.Text = "_______________________________________";
            // 
            // lblpriceproduct
            // 
            this.lblpriceproduct.AutoSize = true;
            this.lblpriceproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpriceproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblpriceproduct.Location = new System.Drawing.Point(23, 250);
            this.lblpriceproduct.Name = "lblpriceproduct";
            this.lblpriceproduct.Size = new System.Drawing.Size(137, 18);
            this.lblpriceproduct.TabIndex = 34;
            this.lblpriceproduct.Text = "Precio del producto";
            // 
            // txtnameproduct
            // 
            this.txtnameproduct.BackColor = System.Drawing.Color.White;
            this.txtnameproduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnameproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnameproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtnameproduct.Location = new System.Drawing.Point(28, 204);
            this.txtnameproduct.Multiline = true;
            this.txtnameproduct.Name = "txtnameproduct";
            this.txtnameproduct.Size = new System.Drawing.Size(302, 20);
            this.txtnameproduct.TabIndex = 32;
            // 
            // lblnameline
            // 
            this.lblnameline.AutoSize = true;
            this.lblnameline.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnameline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.lblnameline.Location = new System.Drawing.Point(23, 213);
            this.lblnameline.Name = "lblnameline";
            this.lblnameline.Size = new System.Drawing.Size(320, 17);
            this.lblnameline.TabIndex = 33;
            this.lblnameline.Text = "_______________________________________";
            // 
            // lblnameproduct
            // 
            this.lblnameproduct.AutoSize = true;
            this.lblnameproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnameproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblnameproduct.Location = new System.Drawing.Point(23, 178);
            this.lblnameproduct.Name = "lblnameproduct";
            this.lblnameproduct.Size = new System.Drawing.Size(148, 18);
            this.lblnameproduct.TabIndex = 31;
            this.lblnameproduct.Text = "Nombre del producto";
            // 
            // lblimgproduct
            // 
            this.lblimgproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimgproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblimgproduct.Location = new System.Drawing.Point(27, 130);
            this.lblimgproduct.Name = "lblimgproduct";
            this.lblimgproduct.Size = new System.Drawing.Size(308, 35);
            this.lblimgproduct.TabIndex = 30;
            this.lblimgproduct.Text = "Imagen del producto";
            this.lblimgproduct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnaddphoto
            // 
            this.btnaddphoto.BackgroundImage = global::Proyecto_Catedra_PEDG01T.Properties.Resources.add_a_photo;
            this.btnaddphoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnaddphoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaddphoto.FlatAppearance.BorderSize = 0;
            this.btnaddphoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddphoto.Location = new System.Drawing.Point(129, 22);
            this.btnaddphoto.Name = "btnaddphoto";
            this.btnaddphoto.Size = new System.Drawing.Size(105, 105);
            this.btnaddphoto.TabIndex = 29;
            this.btnaddphoto.UseVisualStyleBackColor = true;
            this.btnaddphoto.Click += new System.EventHandler(this.btnaddphoto_Click);
            // 
            // btnupdateData
            // 
            this.btnupdateData.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnupdateData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.btnupdateData.FlatAppearance.BorderSize = 0;
            this.btnupdateData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdateData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdateData.ForeColor = System.Drawing.Color.White;
            this.btnupdateData.Location = new System.Drawing.Point(366, 290);
            this.btnupdateData.Name = "btnupdateData";
            this.btnupdateData.Size = new System.Drawing.Size(111, 30);
            this.btnupdateData.TabIndex = 30;
            this.btnupdateData.Text = "Refrescar datos";
            this.btnupdateData.UseVisualStyleBackColor = false;
            this.btnupdateData.Click += new System.EventHandler(this.btnupdateData_Click);
            // 
            // errProvider
            // 
            this.errProvider.ContainerControl = this;
            // 
            // AdmProductoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.btnupdateData);
            this.Controls.Add(this.pnleditproduct);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvproductos);
            this.Controls.Add(this.lblproductos);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btndeleteproduct);
            this.Controls.Add(this.btneditproduct);
            this.Controls.Add(this.cbxproductos);
            this.Controls.Add(this.lblselecproduct);
            this.Controls.Add(this.lbladmproduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdmProductoForm";
            this.Text = "AdmProductoForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvproductos)).EndInit();
            this.pnleditproduct.ResumeLayout(false);
            this.pnleditproduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbladmproduct;
        private System.Windows.Forms.ComboBox cbxproductos;
        private System.Windows.Forms.Label lblselecproduct;
        private System.Windows.Forms.Button btneditproduct;
        private System.Windows.Forms.Button btndeleteproduct;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label lblproductos;
        private System.Windows.Forms.DataGridView dgvproductos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnleditproduct;
        private System.Windows.Forms.Button btncancelupdate;
        private System.Windows.Forms.Button btnupdateproduct;
        private System.Windows.Forms.TextBox txtdescrproduct;
        private System.Windows.Forms.Label lbldescline;
        private System.Windows.Forms.Label lbldescrproduct;
        private System.Windows.Forms.TextBox txtpriceproduct;
        private System.Windows.Forms.Label lblpriceline;
        private System.Windows.Forms.Label lblpriceproduct;
        private System.Windows.Forms.TextBox txtnameproduct;
        private System.Windows.Forms.Label lblnameline;
        private System.Windows.Forms.Label lblnameproduct;
        private System.Windows.Forms.Label lblimgproduct;
        private System.Windows.Forms.Button btnaddphoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Button btnupdateData;
        private System.Windows.Forms.ErrorProvider errProvider;
    }
}