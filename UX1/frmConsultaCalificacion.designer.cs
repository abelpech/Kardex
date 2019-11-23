namespace UX1
{
    partial class frmConsultaCalificacion
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.comboEstatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.txtAlumno = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lbAlumno = new System.Windows.Forms.Label();
            this.lbMatricula = new System.Windows.Forms.Label();
            this.lbCarrera = new System.Windows.Forms.Label();
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
            this.gbConsultaCarrera.Controls.Add(this.btnLimpiar);
            this.gbConsultaCarrera.Controls.Add(this.comboEstatus);
            this.gbConsultaCarrera.Controls.Add(this.label1);
            this.gbConsultaCarrera.Controls.Add(this.txtPeriodo);
            this.gbConsultaCarrera.Controls.Add(this.txtAlumno);
            this.gbConsultaCarrera.Controls.Add(this.txtMatricula);
            this.gbConsultaCarrera.Controls.Add(this.lbAlumno);
            this.gbConsultaCarrera.Controls.Add(this.lbMatricula);
            this.gbConsultaCarrera.Controls.Add(this.lbCarrera);
            this.gbConsultaCarrera.Controls.Add(this.btnConsulta);
            this.gbConsultaCarrera.Controls.Add(this.gbCarrera);
            this.gbConsultaCarrera.Location = new System.Drawing.Point(12, 12);
            this.gbConsultaCarrera.Name = "gbConsultaCarrera";
            this.gbConsultaCarrera.Size = new System.Drawing.Size(1198, 821);
            this.gbConsultaCarrera.TabIndex = 1;
            this.gbConsultaCarrera.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(1033, 93);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 60);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboEstatus
            // 
            this.comboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstatus.FormattingEnabled = true;
            this.comboEstatus.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboEstatus.Location = new System.Drawing.Point(888, 21);
            this.comboEstatus.Name = "comboEstatus";
            this.comboEstatus.Size = new System.Drawing.Size(284, 44);
            this.comboEstatus.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(660, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Estatus Alumno:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPeriodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.Location = new System.Drawing.Point(147, 126);
            this.txtPeriodo.MaxLength = 50;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(479, 38);
            this.txtPeriodo.TabIndex = 4;
            // 
            // txtAlumno
            // 
            this.txtAlumno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAlumno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlumno.Location = new System.Drawing.Point(147, 69);
            this.txtAlumno.MaxLength = 250;
            this.txtAlumno.Name = "txtAlumno";
            this.txtAlumno.Size = new System.Drawing.Size(479, 41);
            this.txtAlumno.TabIndex = 3;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Enabled = false;
            this.txtMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(147, 17);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(479, 39);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatricula_KeyDown);
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // lbAlumno
            // 
            this.lbAlumno.AutoSize = true;
            this.lbAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlumno.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbAlumno.Location = new System.Drawing.Point(14, 69);
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
            this.lbMatricula.Location = new System.Drawing.Point(14, 18);
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
            this.lbCarrera.Location = new System.Drawing.Point(12, 126);
            this.lbCarrera.Name = "lbCarrera";
            this.lbCarrera.Size = new System.Drawing.Size(122, 32);
            this.lbCarrera.TabIndex = 4;
            this.lbCarrera.Text = "Periodo:";
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(691, 93);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(269, 60);
            this.btnConsulta.TabIndex = 5;
            this.btnConsulta.Text = "&Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.dgvCarrera);
            this.gbCarrera.Location = new System.Drawing.Point(6, 177);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Size = new System.Drawing.Size(1178, 632);
            this.gbCarrera.TabIndex = 2;
            this.gbCarrera.TabStop = false;
            // 
            // dgvCarrera
            // 
            this.dgvCarrera.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrera.Location = new System.Drawing.Point(6, 21);
            this.dgvCarrera.Name = "dgvCarrera";
            this.dgvCarrera.RowHeadersWidth = 51;
            this.dgvCarrera.RowTemplate.Height = 24;
            this.dgvCarrera.Size = new System.Drawing.Size(1160, 605);
            this.dgvCarrera.TabIndex = 0;
            this.dgvCarrera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrera_CellClick);
            this.dgvCarrera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCarrera_MouseClick);
            // 
            // frmConsultaCalificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1222, 845);
            this.Controls.Add(this.gbConsultaCarrera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaCalificacion";
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
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.GroupBox gbCarrera;
        public System.Windows.Forms.DataGridView dgvCarrera;
        public System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lbAlumno;
        public System.Windows.Forms.TextBox txtAlumno;
        private System.Windows.Forms.ComboBox comboEstatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMatricula;
        private System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label lbCarrera;
    }
}