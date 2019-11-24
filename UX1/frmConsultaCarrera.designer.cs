namespace Kardex
{
    partial class frmConsultaCarrera
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.gbCarrera = new System.Windows.Forms.GroupBox();
            this.dgvCarrera = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.gbConsultaCarrera.SuspendLayout();
            this.gbCarrera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrera)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConsultaCarrera
            // 
            this.gbConsultaCarrera.Controls.Add(this.btnLimpiar);
            this.gbConsultaCarrera.Controls.Add(this.comboEstatus);
            this.gbConsultaCarrera.Controls.Add(this.label2);
            this.gbConsultaCarrera.Controls.Add(this.txtCarrera);
            this.gbConsultaCarrera.Controls.Add(this.btnConsulta);
            this.gbConsultaCarrera.Controls.Add(this.gbCarrera);
            this.gbConsultaCarrera.Controls.Add(this.label1);
            this.gbConsultaCarrera.Location = new System.Drawing.Point(13, 13);
            this.gbConsultaCarrera.Name = "gbConsultaCarrera";
            this.gbConsultaCarrera.Size = new System.Drawing.Size(1197, 820);
            this.gbConsultaCarrera.TabIndex = 0;
            this.gbConsultaCarrera.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(945, 98);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(159, 40);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboEstatus
            // 
            this.comboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEstatus.FormattingEnabled = true;
            this.comboEstatus.Items.AddRange(new object[] {
            "Activos",
            "Inactivos"});
            this.comboEstatus.Location = new System.Drawing.Point(137, 72);
            this.comboEstatus.Name = "comboEstatus";
            this.comboEstatus.Size = new System.Drawing.Size(694, 44);
            this.comboEstatus.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Estatus:";
            // 
            // txtCarrera
            // 
            this.txtCarrera.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCarrera.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarrera.Location = new System.Drawing.Point(137, 11);
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(694, 41);
            this.txtCarrera.TabIndex = 1;
            this.txtCarrera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsLetterPressed);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(890, 31);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(269, 60);
            this.btnConsulta.TabIndex = 3;
            this.btnConsulta.Text = "&Consultar";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.BtnConsulta_Click);
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.dgvCarrera);
            this.gbCarrera.Location = new System.Drawing.Point(6, 144);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Size = new System.Drawing.Size(1185, 670);
            this.gbCarrera.TabIndex = 2;
            this.gbCarrera.TabStop = false;
            // 
            // dgvCarrera
            // 
            this.dgvCarrera.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrera.Location = new System.Drawing.Point(6, 14);
            this.dgvCarrera.Name = "dgvCarrera";
            this.dgvCarrera.ReadOnly = true;
            this.dgvCarrera.RowHeadersWidth = 51;
            this.dgvCarrera.RowTemplate.Height = 24;
            this.dgvCarrera.Size = new System.Drawing.Size(1173, 646);
            this.dgvCarrera.TabIndex = 0;
            this.dgvCarrera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrera_CellClick);
            this.dgvCarrera.SelectionChanged += new System.EventHandler(this.dgvCarrera_SelectionChanged);
            this.dgvCarrera.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCarrera_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carrera: ";
            // 
            // frmConsultaCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1222, 845);
            this.Controls.Add(this.gbConsultaCarrera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaCarrera";
            this.Text = "frmConsultaCarrera";
            this.Load += new System.EventHandler(this.FrmConsultaCarrera_Load);
            this.TextChanged += new System.EventHandler(this.frmConsultaCarrera_TextChanged);
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
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvCarrera;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.ComboBox comboEstatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiar;
    }
}