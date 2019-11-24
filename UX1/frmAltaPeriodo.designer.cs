namespace Kardex
{
    partial class frmAltaPeriodo
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
            this.label2 = new System.Windows.Forms.Label();
            this.nudPeriodoUnidad = new System.Windows.Forms.NumericUpDown();
            this.nudPeriodoAnio = new System.Windows.Forms.NumericUpDown();
            this.btnAltaPeriodo = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEstatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoUnidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(498, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // nudPeriodoUnidad
            // 
            this.nudPeriodoUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPeriodoUnidad.Location = new System.Drawing.Point(558, 123);
            this.nudPeriodoUnidad.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudPeriodoUnidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPeriodoUnidad.Name = "nudPeriodoUnidad";
            this.nudPeriodoUnidad.Size = new System.Drawing.Size(71, 45);
            this.nudPeriodoUnidad.TabIndex = 3;
            this.nudPeriodoUnidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPeriodoUnidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberPressed);
            // 
            // nudPeriodoAnio
            // 
            this.nudPeriodoAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPeriodoAnio.Location = new System.Drawing.Point(345, 123);
            this.nudPeriodoAnio.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPeriodoAnio.Minimum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.nudPeriodoAnio.Name = "nudPeriodoAnio";
            this.nudPeriodoAnio.Size = new System.Drawing.Size(122, 45);
            this.nudPeriodoAnio.TabIndex = 4;
            this.nudPeriodoAnio.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.nudPeriodoAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberPressed);
            // 
            // btnAltaPeriodo
            // 
            this.btnAltaPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaPeriodo.Location = new System.Drawing.Point(142, 580);
            this.btnAltaPeriodo.Name = "btnAltaPeriodo";
            this.btnAltaPeriodo.Size = new System.Drawing.Size(365, 95);
            this.btnAltaPeriodo.TabIndex = 5;
            this.btnAltaPeriodo.Text = "Guardar";
            this.btnAltaPeriodo.UseVisualStyleBackColor = true;
            this.btnAltaPeriodo.Click += new System.EventHandler(this.BtnAltaPeriodo_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(734, 580);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(365, 95);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(141, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 44);
            this.label3.TabIndex = 7;
            this.label3.Text = "Periodo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(141, 240);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 44);
            this.label1.TabIndex = 8;
            this.label1.Text = "Estatus:";
            // 
            // cbEstatus
            // 
            this.cbEstatus.AutoCompleteCustomSource.AddRange(new string[] {
            "Seleccione"});
            this.cbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstatus.FormattingEnabled = true;
            this.cbEstatus.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbEstatus.Location = new System.Drawing.Point(345, 238);
            this.cbEstatus.Margin = new System.Windows.Forms.Padding(4);
            this.cbEstatus.Name = "cbEstatus";
            this.cbEstatus.Size = new System.Drawing.Size(735, 46);
            this.cbEstatus.TabIndex = 9;
            // 
            // frmAltaPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1222, 845);
            this.Controls.Add(this.cbEstatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnAltaPeriodo);
            this.Controls.Add(this.nudPeriodoAnio);
            this.Controls.Add(this.nudPeriodoUnidad);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAltaPeriodo";
            this.Text = "frmAltaPeriodo";
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoUnidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPeriodoUnidad;
        private System.Windows.Forms.NumericUpDown nudPeriodoAnio;
        private System.Windows.Forms.Button btnAltaPeriodo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEstatus;
    }
}