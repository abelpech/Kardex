namespace UX1
{
    partial class frmConsultaAlumno
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
            this.gbConsultaCarrera = new System.Windows.Forms.GroupBox();
            this.cbInactivos = new System.Windows.Forms.CheckBox();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.txtAlumno = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lbAlumno = new System.Windows.Forms.Label();
            this.lbMatricula = new System.Windows.Forms.Label();
            this.lbCarrera = new System.Windows.Forms.Label();
            this.cbTodos = new System.Windows.Forms.CheckBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.gbCarrera = new System.Windows.Forms.GroupBox();
            this.dgvCarrera = new System.Windows.Forms.DataGridView();
            this.gbConsultaCarrera.SuspendLayout();
            this.gbCarrera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrera)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConsultaCarrera
            // 
            this.gbConsultaCarrera.Controls.Add(this.cbInactivos);
            this.gbConsultaCarrera.Controls.Add(this.txtCarrera);
            this.gbConsultaCarrera.Controls.Add(this.txtAlumno);
            this.gbConsultaCarrera.Controls.Add(this.txtMatricula);
            this.gbConsultaCarrera.Controls.Add(this.lbAlumno);
            this.gbConsultaCarrera.Controls.Add(this.lbMatricula);
            this.gbConsultaCarrera.Controls.Add(this.lbCarrera);
            this.gbConsultaCarrera.Controls.Add(this.cbTodos);
            this.gbConsultaCarrera.Controls.Add(this.btnConsulta);
            this.gbConsultaCarrera.Controls.Add(this.gbCarrera);
            this.gbConsultaCarrera.Location = new System.Drawing.Point(12, 12);
            this.gbConsultaCarrera.Name = "gbConsultaCarrera";
            this.gbConsultaCarrera.Size = new System.Drawing.Size(1198, 821);
            this.gbConsultaCarrera.TabIndex = 1;
            this.gbConsultaCarrera.TabStop = false;
            // 
            // cbInactivos
            // 
            this.cbInactivos.AutoSize = true;
            this.cbInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInactivos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbInactivos.Location = new System.Drawing.Point(670, 38);
            this.cbInactivos.Name = "cbInactivos";
            this.cbInactivos.Size = new System.Drawing.Size(128, 33);
            this.cbInactivos.TabIndex = 7;
            this.cbInactivos.Text = "Inactivos";
            this.cbInactivos.UseVisualStyleBackColor = true;
            this.cbInactivos.CheckedChanged += new System.EventHandler(this.CbInactivos_CheckedChanged);
            this.cbInactivos.Click += new System.EventHandler(this.cbInactivos_Click);
            // 
            // txtCarrera
            // 
            this.txtCarrera.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCarrera.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarrera.Location = new System.Drawing.Point(670, 76);
            this.txtCarrera.MaxLength = 50;
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(514, 38);
            this.txtCarrera.TabIndex = 4;
            // 
            // txtAlumno
            // 
            this.txtAlumno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAlumno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlumno.Location = new System.Drawing.Point(129, 76);
            this.txtAlumno.MaxLength = 250;
            this.txtAlumno.Name = "txtAlumno";
            this.txtAlumno.Size = new System.Drawing.Size(400, 38);
            this.txtAlumno.TabIndex = 3;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(147, 17);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(501, 39);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatricula_KeyDown);
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // lbAlumno
            // 
            this.lbAlumno.AutoSize = true;
            this.lbAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlumno.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbAlumno.Location = new System.Drawing.Point(6, 76);
            this.lbAlumno.Name = "lbAlumno";
            this.lbAlumno.Size = new System.Drawing.Size(127, 32);
            this.lbAlumno.TabIndex = 6;
            this.lbAlumno.Text = "Alumno: ";
            // 
            // lbMatricula
            // 
            this.lbMatricula.AutoSize = true;
            this.lbMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatricula.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbMatricula.Location = new System.Drawing.Point(6, 17);
            this.lbMatricula.Name = "lbMatricula";
            this.lbMatricula.Size = new System.Drawing.Size(146, 32);
            this.lbMatricula.TabIndex = 0;
            this.lbMatricula.Text = "Matricula: ";
            // 
            // lbCarrera
            // 
            this.lbCarrera.AutoSize = true;
            this.lbCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCarrera.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbCarrera.Location = new System.Drawing.Point(553, 76);
            this.lbCarrera.Name = "lbCarrera";
            this.lbCarrera.Size = new System.Drawing.Size(125, 32);
            this.lbCarrera.TabIndex = 4;
            this.lbCarrera.Text = "Carrera: ";
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTodos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbTodos.Location = new System.Drawing.Point(670, 10);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.Size = new System.Drawing.Size(176, 33);
            this.cbTodos.TabIndex = 2;
            this.cbTodos.Text = "Por matricula";
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.CheckedChanged += new System.EventHandler(this.CbTodos_CheckedChanged);
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(940, 18);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(244, 40);
            this.btnConsulta.TabIndex = 5;
            this.btnConsulta.Text = "&Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.dgvCarrera);
            this.gbCarrera.Location = new System.Drawing.Point(6, 134);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Size = new System.Drawing.Size(1178, 675);
            this.gbCarrera.TabIndex = 2;
            this.gbCarrera.TabStop = false;
            // 
            // dgvCarrera
            // 
            this.dgvCarrera.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrera.Location = new System.Drawing.Point(6, 21);
            this.dgvCarrera.Name = "dgvCarrera";
            this.dgvCarrera.RowTemplate.Height = 24;
            this.dgvCarrera.Size = new System.Drawing.Size(1160, 648);
            this.dgvCarrera.TabIndex = 0;
            this.dgvCarrera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrera_CellClick);
            this.dgvCarrera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCarrera_MouseClick);
            // 
            // frmConsultaAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1222, 845);
            this.Controls.Add(this.gbConsultaCarrera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaAlumno";
            this.Text = "frmConsultaAlumno";
            this.Load += new System.EventHandler(this.FrmConsultaAlumno_Load);
            this.gbConsultaCarrera.ResumeLayout(false);
            this.gbConsultaCarrera.PerformLayout();
            this.gbCarrera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConsultaCarrera;
        private System.Windows.Forms.CheckBox cbTodos;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.GroupBox gbCarrera;
        public System.Windows.Forms.DataGridView dgvCarrera;
        public System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lbMatricula;
        private System.Windows.Forms.Label lbAlumno;
        private System.Windows.Forms.Label lbCarrera;
        public System.Windows.Forms.TextBox txtCarrera;
        public System.Windows.Forms.TextBox txtAlumno;
        private System.Windows.Forms.CheckBox cbInactivos;
    }
}