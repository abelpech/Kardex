namespace UX1
{
    partial class frmConsultaMaestro
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboEstatus = new System.Windows.Forms.ComboBox();
            this.txtMaestro = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.lbAlumno = new System.Windows.Forms.Label();
            this.lbMatricula = new System.Windows.Forms.Label();
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
            this.gbConsultaCarrera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.gbConsultaCarrera.Controls.Add(this.label1);
            this.gbConsultaCarrera.Controls.Add(this.comboEstatus);
            this.gbConsultaCarrera.Controls.Add(this.txtMaestro);
            this.gbConsultaCarrera.Controls.Add(this.txtMatricula);
            this.gbConsultaCarrera.Controls.Add(this.lbAlumno);
            this.gbConsultaCarrera.Controls.Add(this.lbMatricula);
            this.gbConsultaCarrera.Controls.Add(this.btnConsulta);
            this.gbConsultaCarrera.Controls.Add(this.gbCarrera);
            this.gbConsultaCarrera.Location = new System.Drawing.Point(3, 12);
            this.gbConsultaCarrera.Name = "gbConsultaCarrera";
            this.gbConsultaCarrera.Size = new System.Drawing.Size(1198, 782);
            this.gbConsultaCarrera.TabIndex = 2;
            this.gbConsultaCarrera.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(6, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Estatus: ";
            // 
            // comboEstatus
            // 
            this.comboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstatus.FormattingEnabled = true;
            this.comboEstatus.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboEstatus.Location = new System.Drawing.Point(147, 126);
            this.comboEstatus.Name = "comboEstatus";
            this.comboEstatus.Size = new System.Drawing.Size(769, 44);
            this.comboEstatus.TabIndex = 11;
            // 
            // txtMaestro
            // 
            this.txtMaestro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMaestro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMaestro.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaestro.Location = new System.Drawing.Point(147, 73);
            this.txtMaestro.MaxLength = 250;
            this.txtMaestro.Name = "txtMaestro";
            this.txtMaestro.Size = new System.Drawing.Size(769, 38);
            this.txtMaestro.TabIndex = 3;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(147, 17);
            this.txtMatricula.Multiline = true;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(769, 39);
            this.txtMatricula.TabIndex = 1;
            // 
            // lbAlumno
            // 
            this.lbAlumno.AutoSize = true;
            this.lbAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlumno.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbAlumno.Location = new System.Drawing.Point(6, 76);
            this.lbAlumno.Name = "lbAlumno";
            this.lbAlumno.Size = new System.Drawing.Size(132, 32);
            this.lbAlumno.TabIndex = 6;
            this.lbAlumno.Text = "Maestro: ";
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
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(928, 126);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(244, 46);
            this.btnConsulta.TabIndex = 5;
            this.btnConsulta.Text = "&Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.dgvCarrera);
            this.gbCarrera.Location = new System.Drawing.Point(6, 178);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Size = new System.Drawing.Size(1178, 596);
            this.gbCarrera.TabIndex = 2;
            this.gbCarrera.TabStop = false;
            // 
            // dgvCarrera
            // 
            this.dgvCarrera.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrera.Location = new System.Drawing.Point(8, 21);
            this.dgvCarrera.Name = "dgvCarrera";
            this.dgvCarrera.RowHeadersWidth = 51;
            this.dgvCarrera.RowTemplate.Height = 24;
            this.dgvCarrera.Size = new System.Drawing.Size(1160, 569);
            this.dgvCarrera.TabIndex = 0;
            this.dgvCarrera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrera_CellClick);
            this.dgvCarrera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCarrera_MouseClick);
            // 
            // frmConsultaMaestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1204, 798);
            this.Controls.Add(this.gbConsultaCarrera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaMaestro";
            this.Text = "frmConsultaMaestro";
            this.gbConsultaCarrera.ResumeLayout(false);
            this.gbConsultaCarrera.PerformLayout();
            this.gbCarrera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConsultaCarrera;
        public System.Windows.Forms.TextBox txtMaestro;
        public System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lbAlumno;
        private System.Windows.Forms.Label lbMatricula;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.GroupBox gbCarrera;
        public System.Windows.Forms.DataGridView dgvCarrera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboEstatus;
    }
}