namespace Kardex
{
    partial class frmModificaCalificacion
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
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudUnidad = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudCalificacion = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaestro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMateria = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlumno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCarrera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.txtCarrera);
            this.gbCarrera.Controls.Add(this.label7);
            this.gbCarrera.Controls.Add(this.nudUnidad);
            this.gbCarrera.Controls.Add(this.label6);
            this.gbCarrera.Controls.Add(this.nudCalificacion);
            this.gbCarrera.Controls.Add(this.label4);
            this.gbCarrera.Controls.Add(this.txtPeriodo);
            this.gbCarrera.Controls.Add(this.label3);
            this.gbCarrera.Controls.Add(this.txtMaestro);
            this.gbCarrera.Controls.Add(this.label2);
            this.gbCarrera.Controls.Add(this.txtMateria);
            this.gbCarrera.Controls.Add(this.btnCerrar);
            this.gbCarrera.Controls.Add(this.btnGuardar);
            this.gbCarrera.Controls.Add(this.label5);
            this.gbCarrera.Controls.Add(this.txtAlumno);
            this.gbCarrera.Controls.Add(this.label1);
            this.gbCarrera.Location = new System.Drawing.Point(13, 13);
            this.gbCarrera.Margin = new System.Windows.Forms.Padding(4);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Padding = new System.Windows.Forms.Padding(4);
            this.gbCarrera.Size = new System.Drawing.Size(1196, 819);
            this.gbCarrera.TabIndex = 1;
            this.gbCarrera.TabStop = false;
            // 
            // txtCarrera
            // 
            this.txtCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarrera.Location = new System.Drawing.Point(424, 204);
            this.txtCarrera.Margin = new System.Windows.Forms.Padding(4);
            this.txtCarrera.MaxLength = 50;
            this.txtCarrera.Multiline = true;
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(735, 45);
            this.txtCarrera.TabIndex = 20;
            this.txtCarrera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsLetterOrNumberPressed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(43, 205);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 44);
            this.label7.TabIndex = 19;
            this.label7.Text = "Carrera:";
            // 
            // nudUnidad
            // 
            this.nudUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudUnidad.Location = new System.Drawing.Point(424, 540);
            this.nudUnidad.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudUnidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUnidad.Name = "nudUnidad";
            this.nudUnidad.Size = new System.Drawing.Size(120, 41);
            this.nudUnidad.TabIndex = 18;
            this.nudUnidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUnidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberPressed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(50, 540);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 44);
            this.label6.TabIndex = 17;
            this.label6.Text = "Unidad:";
            // 
            // nudCalificacion
            // 
            this.nudCalificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCalificacion.Location = new System.Drawing.Point(424, 458);
            this.nudCalificacion.Name = "nudCalificacion";
            this.nudCalificacion.Size = new System.Drawing.Size(120, 41);
            this.nudCalificacion.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(50, 458);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 44);
            this.label4.TabIndex = 15;
            this.label4.Text = "Calificacion:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodo.Location = new System.Drawing.Point(424, 371);
            this.txtPeriodo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPeriodo.MaxLength = 50;
            this.txtPeriodo.Multiline = true;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(735, 45);
            this.txtPeriodo.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(43, 372);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 44);
            this.label3.TabIndex = 13;
            this.label3.Text = "Periodo:";
            // 
            // txtMaestro
            // 
            this.txtMaestro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaestro.Location = new System.Drawing.Point(424, 285);
            this.txtMaestro.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaestro.MaxLength = 50;
            this.txtMaestro.Multiline = true;
            this.txtMaestro.Name = "txtMaestro";
            this.txtMaestro.Size = new System.Drawing.Size(735, 45);
            this.txtMaestro.TabIndex = 12;
            this.txtMaestro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsLetterPressed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(43, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 44);
            this.label2.TabIndex = 11;
            this.label2.Text = "Maestro:";
            // 
            // txtMateria
            // 
            this.txtMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMateria.Location = new System.Drawing.Point(424, 134);
            this.txtMateria.Margin = new System.Windows.Forms.Padding(4);
            this.txtMateria.MaxLength = 50;
            this.txtMateria.Multiline = true;
            this.txtMateria.Name = "txtMateria";
            this.txtMateria.Size = new System.Drawing.Size(735, 45);
            this.txtMateria.TabIndex = 10;
            this.txtMateria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsLetterOrNumberPressed);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(794, 686);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(365, 95);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(51, 686);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(365, 95);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(43, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 44);
            this.label5.TabIndex = 9;
            this.label5.Text = "Materia:";
            // 
            // txtAlumno
            // 
            this.txtAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlumno.Location = new System.Drawing.Point(424, 59);
            this.txtAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlumno.MaxLength = 50;
            this.txtAlumno.Multiline = true;
            this.txtAlumno.Name = "txtAlumno";
            this.txtAlumno.Size = new System.Drawing.Size(735, 45);
            this.txtAlumno.TabIndex = 1;
            this.txtAlumno.TextChanged += new System.EventHandler(this.TxtCarrera_TextChanged);
            this.txtAlumno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsLetterPressed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(43, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alumno:";
            // 
            // frmModificaCalificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1222, 845);
            this.Controls.Add(this.gbCarrera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmModificaCalificacion";
            this.Text = "frmAltaCarrera";
            this.gbCarrera.ResumeLayout(false);
            this.gbCarrera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCalificacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCarrera;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlumno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMateria;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaestro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudUnidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudCalificacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.Label label7;
    }
}