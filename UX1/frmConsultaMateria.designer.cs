namespace UX1
{
    partial class frmConsultaMateria
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
            this.cbTodas = new System.Windows.Forms.CheckBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.gbCarrera = new System.Windows.Forms.GroupBox();
            this.dgvCarrera = new System.Windows.Forms.DataGridView();
            this.txtMateria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbInactivos = new System.Windows.Forms.CheckBox();
            this.gbCarrera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrera)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTodas
            // 
            this.cbTodas.AutoSize = true;
            this.cbTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTodas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbTodas.Location = new System.Drawing.Point(882, 1);
            this.cbTodas.Name = "cbTodas";
            this.cbTodas.Size = new System.Drawing.Size(129, 36);
            this.cbTodas.TabIndex = 2;
            this.cbTodas.Text = "Activos";
            this.cbTodas.UseVisualStyleBackColor = true;
            this.cbTodas.CheckedChanged += new System.EventHandler(this.CbTodas_CheckedChanged);
            this.cbTodas.Click += new System.EventHandler(this.cbTodas_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(1049, 12);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(149, 43);
            this.btnConsulta.TabIndex = 3;
            this.btnConsulta.Text = "&Consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.dgvCarrera);
            this.gbCarrera.Location = new System.Drawing.Point(12, 66);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Size = new System.Drawing.Size(1198, 767);
            this.gbCarrera.TabIndex = 7;
            this.gbCarrera.TabStop = false;
            // 
            // dgvCarrera
            // 
            this.dgvCarrera.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrera.Location = new System.Drawing.Point(4, 11);
            this.dgvCarrera.Name = "dgvCarrera";
            this.dgvCarrera.RowTemplate.Height = 24;
            this.dgvCarrera.Size = new System.Drawing.Size(1188, 750);
            this.dgvCarrera.TabIndex = 0;
            this.dgvCarrera.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrera_CellClick);
            this.dgvCarrera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCarrera_MouseClick);
            // 
            // txtMateria
            // 
            this.txtMateria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMateria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMateria.Location = new System.Drawing.Point(145, 12);
            this.txtMateria.MaxLength = 50;
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(729, 41);
            this.txtMateria.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(30, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Materia: ";
            // 
            // cbInactivos
            // 
            this.cbInactivos.AutoSize = true;
            this.cbInactivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInactivos.ForeColor = System.Drawing.Color.White;
            this.cbInactivos.Location = new System.Drawing.Point(882, 33);
            this.cbInactivos.Name = "cbInactivos";
            this.cbInactivos.Size = new System.Drawing.Size(155, 40);
            this.cbInactivos.TabIndex = 8;
            this.cbInactivos.Text = "Inactivos";
            this.cbInactivos.UseVisualStyleBackColor = true;
            this.cbInactivos.CheckedChanged += new System.EventHandler(this.cbInactivos_CheckedChanged);
            this.cbInactivos.Click += new System.EventHandler(this.cbInactivos_Click);
            // 
            // frmConsultaMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1222, 845);
            this.Controls.Add(this.cbInactivos);
            this.Controls.Add(this.cbTodas);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.gbCarrera);
            this.Controls.Add(this.txtMateria);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaMateria";
            this.Text = "frmConsultaMateria";
            this.Load += new System.EventHandler(this.FrmConsultaMateria_Load);
            this.gbCarrera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbTodas;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.GroupBox gbCarrera;
        public System.Windows.Forms.DataGridView dgvCarrera;
        public System.Windows.Forms.TextBox txtMateria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbInactivos;
    }
}