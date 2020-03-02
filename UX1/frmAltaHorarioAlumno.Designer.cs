namespace UX1
{
    partial class frmAltaHorarioAlumno
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
            this.gbCarrera = new System.Windows.Forms.GroupBox();
            this.lbUser = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbMateria = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.dgvHorario = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbCarrera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMateria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.lbUser);
            this.gbCarrera.Controls.Add(this.pictureBox2);
            this.gbCarrera.Controls.Add(this.pictureBox1);
            this.gbCarrera.Controls.Add(this.pbMateria);
            this.gbCarrera.Controls.Add(this.btnEliminar);
            this.gbCarrera.Controls.Add(this.btnAgregar);
            this.gbCarrera.Controls.Add(this.dgvMaterias);
            this.gbCarrera.Controls.Add(this.dgvHorario);
            this.gbCarrera.Controls.Add(this.btnCerrar);
            this.gbCarrera.Controls.Add(this.btnGuardar);
            this.gbCarrera.Location = new System.Drawing.Point(-6, -15);
            this.gbCarrera.Margin = new System.Windows.Forms.Padding(4);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Padding = new System.Windows.Forms.Padding(4);
            this.gbCarrera.Size = new System.Drawing.Size(1213, 828);
            this.gbCarrera.TabIndex = 4;
            this.gbCarrera.TabStop = false;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbUser.Location = new System.Drawing.Point(134, 28);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(385, 46);
            this.lbUser.TabIndex = 15;
            this.lbUser.Text = "Nombre de Usuario";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::UX1.Properties.Resources.Usuario;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(74, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 56);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UX1.Properties.Resources.Horario;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 464);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 56);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pbMateria
            // 
            this.pbMateria.BackgroundImage = global::UX1.Properties.Resources.Materia1;
            this.pbMateria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMateria.Location = new System.Drawing.Point(15, 104);
            this.pbMateria.Name = "pbMateria";
            this.pbMateria.Size = new System.Drawing.Size(53, 56);
            this.pbMateria.TabIndex = 12;
            this.pbMateria.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BackgroundImage = global::UX1.Properties.Resources.Eliminar;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(1125, 464);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(48, 43);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BackgroundImage = global::UX1.Properties.Resources.Agregar1;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(1125, 104);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(48, 43);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.AllowUserToAddRows = false;
            this.dgvMaterias.AllowUserToDeleteRows = false;
            this.dgvMaterias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMaterias.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Location = new System.Drawing.Point(74, 104);
            this.dgvMaterias.MultiSelect = false;
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.RowHeadersWidth = 51;
            this.dgvMaterias.RowTemplate.Height = 24;
            this.dgvMaterias.Size = new System.Drawing.Size(1045, 313);
            this.dgvMaterias.TabIndex = 9;
            this.dgvMaterias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterias_CellClick);
            this.dgvMaterias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterias_CellClick);
            // 
            // dgvHorario
            // 
            this.dgvHorario.AllowUserToAddRows = false;
            this.dgvHorario.AllowUserToDeleteRows = false;
            this.dgvHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHorario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvHorario.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorario.Location = new System.Drawing.Point(74, 464);
            this.dgvHorario.Name = "dgvHorario";
            this.dgvHorario.ReadOnly = true;
            this.dgvHorario.RowHeadersWidth = 51;
            this.dgvHorario.RowTemplate.Height = 24;
            this.dgvHorario.Size = new System.Drawing.Size(1045, 215);
            this.dgvHorario.TabIndex = 8;
            this.dgvHorario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHorario_CellClick);
            this.dgvHorario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHorario_CellClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(808, 704);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(311, 95);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(66, 704);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(332, 95);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmAltaHorarioAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1200, 798);
            this.Controls.Add(this.gbCarrera);
            this.Name = "frmAltaHorarioAlumno";
            this.Text = "frmAltaHorarioAlumno";
            this.gbCarrera.ResumeLayout(false);
            this.gbCarrera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMateria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCarrera;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.DataGridView dgvHorario;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox pbMateria;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbUser;
    }
}