namespace Proyecto_Catedra_PEDG01T
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnllogologin = new System.Windows.Forms.Panel();
            this.lblderechos = new System.Windows.Forms.Label();
            this.pbxlogo = new System.Windows.Forms.PictureBox();
            this.lblrestaurante = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.lbluserline = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxtypeuser = new System.Windows.Forms.ComboBox();
            this.btntypeuser = new System.Windows.Forms.Button();
            this.pnltypeuser = new System.Windows.Forms.Panel();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.pnllogologin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxlogo)).BeginInit();
            this.pnltypeuser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnllogologin
            // 
            this.pnllogologin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.pnllogologin.Controls.Add(this.lblderechos);
            this.pnllogologin.Controls.Add(this.pbxlogo);
            this.pnllogologin.Controls.Add(this.lblrestaurante);
            this.pnllogologin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnllogologin.Location = new System.Drawing.Point(0, 0);
            this.pnllogologin.Name = "pnllogologin";
            this.pnllogologin.Size = new System.Drawing.Size(550, 640);
            this.pnllogologin.TabIndex = 0;
            // 
            // lblderechos
            // 
            this.lblderechos.AutoSize = true;
            this.lblderechos.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblderechos.ForeColor = System.Drawing.Color.White;
            this.lblderechos.Location = new System.Drawing.Point(129, 613);
            this.lblderechos.Name = "lblderechos";
            this.lblderechos.Size = new System.Drawing.Size(276, 18);
            this.lblderechos.TabIndex = 2;
            this.lblderechos.Text = "Copyright © Derechos reservados 2021";
            // 
            // pbxlogo
            // 
            this.pbxlogo.Image = global::Proyecto_Catedra_PEDG01T.Properties.Resources.Logo;
            this.pbxlogo.Location = new System.Drawing.Point(145, 247);
            this.pbxlogo.Name = "pbxlogo";
            this.pbxlogo.Size = new System.Drawing.Size(235, 223);
            this.pbxlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxlogo.TabIndex = 1;
            this.pbxlogo.TabStop = false;
            // 
            // lblrestaurante
            // 
            this.lblrestaurante.AutoSize = true;
            this.lblrestaurante.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrestaurante.ForeColor = System.Drawing.Color.White;
            this.lblrestaurante.Location = new System.Drawing.Point(81, 118);
            this.lblrestaurante.Name = "lblrestaurante";
            this.lblrestaurante.Size = new System.Drawing.Size(380, 40);
            this.lblrestaurante.TabIndex = 0;
            this.lblrestaurante.Text = "Nombre de Restuarante";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(645, 137);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(60, 18);
            this.lblusuario.TabIndex = 1;
            this.lblusuario.Text = "Usuario";
            // 
            // txtuser
            // 
            this.txtuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuser.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.ForeColor = System.Drawing.Color.White;
            this.txtuser.Location = new System.Drawing.Point(650, 170);
            this.txtuser.Multiline = true;
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(343, 20);
            this.txtuser.TabIndex = 2;
            // 
            // lbluserline
            // 
            this.lbluserline.AutoSize = true;
            this.lbluserline.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.lbluserline.Location = new System.Drawing.Point(645, 179);
            this.lbluserline.Name = "lbluserline";
            this.lbluserline.Size = new System.Drawing.Size(360, 17);
            this.lbluserline.TabIndex = 3;
            this.lbluserline.Text = "____________________________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(645, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "____________________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(645, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de usuario";
            // 
            // cbxtypeuser
            // 
            this.cbxtypeuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbxtypeuser.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxtypeuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxtypeuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxtypeuser.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxtypeuser.ForeColor = System.Drawing.Color.White;
            this.cbxtypeuser.FormattingEnabled = true;
            this.cbxtypeuser.Items.AddRange(new object[] {
            "Administrador",
            "Empleado"});
            this.cbxtypeuser.Location = new System.Drawing.Point(-1, -1);
            this.cbxtypeuser.Name = "cbxtypeuser";
            this.cbxtypeuser.Size = new System.Drawing.Size(344, 23);
            this.cbxtypeuser.TabIndex = 9;
            // 
            // btntypeuser
            // 
            this.btntypeuser.FlatAppearance.BorderSize = 0;
            this.btntypeuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntypeuser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.btntypeuser.Location = new System.Drawing.Point(322, -1);
            this.btntypeuser.Name = "btntypeuser";
            this.btntypeuser.Size = new System.Drawing.Size(33, 23);
            this.btntypeuser.TabIndex = 12;
            this.btntypeuser.Text = "▼";
            this.btntypeuser.UseVisualStyleBackColor = true;
            this.btntypeuser.Click += new System.EventHandler(this.btntypeuser_Click);
            // 
            // pnltypeuser
            // 
            this.pnltypeuser.Controls.Add(this.btntypeuser);
            this.pnltypeuser.Controls.Add(this.cbxtypeuser);
            this.pnltypeuser.Location = new System.Drawing.Point(650, 267);
            this.pnltypeuser.Name = "pnltypeuser";
            this.pnltypeuser.Size = new System.Drawing.Size(355, 21);
            this.pnltypeuser.TabIndex = 13;
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpassword.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.Color.White;
            this.txtpassword.Location = new System.Drawing.Point(650, 364);
            this.txtpassword.Multiline = true;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '•';
            this.txtpassword.Size = new System.Drawing.Size(343, 20);
            this.txtpassword.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.label3.Location = new System.Drawing.Point(645, 373);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "____________________________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(645, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Contraseña";
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.btnlogin.FlatAppearance.BorderSize = 0;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(687, 493);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(120, 36);
            this.btnlogin.TabIndex = 18;
            this.btnlogin.Text = "Iniciar sesión";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.Gray;
            this.btnsalir.FlatAppearance.BorderSize = 0;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.ForeColor = System.Drawing.Color.White;
            this.btnsalir.Location = new System.Drawing.Point(851, 493);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(120, 36);
            this.btnsalir.TabIndex = 19;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackgroundImage = global::Proyecto_Catedra_PEDG01T.Properties.Resources.Round_Close;
            this.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(48)))));
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Location = new System.Drawing.Point(1058, 12);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(30, 30);
            this.btnclose.TabIndex = 20;
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnltypeuser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.lbluserline);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.pnllogologin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnllogologin.ResumeLayout(false);
            this.pnllogologin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxlogo)).EndInit();
            this.pnltypeuser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnllogologin;
        private System.Windows.Forms.Label lblderechos;
        private System.Windows.Forms.PictureBox pbxlogo;
        private System.Windows.Forms.Label lblrestaurante;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label lbluserline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxtypeuser;
        private System.Windows.Forms.Button btntypeuser;
        private System.Windows.Forms.Panel pnltypeuser;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnclose;
    }
}

