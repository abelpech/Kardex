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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPeriodoUnidad = new System.Windows.Forms.NumericUpDown();
            this.nudPeriodoAnio = new System.Windows.Forms.NumericUpDown();
            this.btnAltaPeriodo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoUnidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Periodo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(204, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // nudPeriodoUnidad
            // 
            this.nudPeriodoUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPeriodoUnidad.Location = new System.Drawing.Point(230, 38);
            this.nudPeriodoUnidad.Name = "nudPeriodoUnidad";
            this.nudPeriodoUnidad.Size = new System.Drawing.Size(71, 30);
            this.nudPeriodoUnidad.TabIndex = 3;
            // 
            // nudPeriodoAnio
            // 
            this.nudPeriodoAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPeriodoAnio.Location = new System.Drawing.Point(104, 37);
            this.nudPeriodoAnio.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPeriodoAnio.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.nudPeriodoAnio.Name = "nudPeriodoAnio";
            this.nudPeriodoAnio.Size = new System.Drawing.Size(93, 30);
            this.nudPeriodoAnio.TabIndex = 4;
            this.nudPeriodoAnio.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // btnAltaPeriodo
            // 
            this.btnAltaPeriodo.Location = new System.Drawing.Point(81, 133);
            this.btnAltaPeriodo.Name = "btnAltaPeriodo";
            this.btnAltaPeriodo.Size = new System.Drawing.Size(182, 38);
            this.btnAltaPeriodo.TabIndex = 5;
            this.btnAltaPeriodo.Text = "Dar de Alta";
            this.btnAltaPeriodo.UseVisualStyleBackColor = true;
            this.btnAltaPeriodo.Click += new System.EventHandler(this.BtnAltaPeriodo_Click);
            // 
            // frmAltaPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1222, 845);
            this.Controls.Add(this.btnAltaPeriodo);
            this.Controls.Add(this.nudPeriodoAnio);
            this.Controls.Add(this.nudPeriodoUnidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAltaPeriodo";
            this.Text = "frmAltaPeriodo";
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoUnidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPeriodoUnidad;
        private System.Windows.Forms.NumericUpDown nudPeriodoAnio;
        private System.Windows.Forms.Button btnAltaPeriodo;
    }
}