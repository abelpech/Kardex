﻿namespace UX1
{
    partial class frmAltaAlumno
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
            this.components = new System.ComponentModel.Container();
            this.epTelefono = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbCarrera = new System.Windows.Forms.GroupBox();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAlumno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefono)).BeginInit();
            this.gbCarrera.SuspendLayout();
            this.SuspendLayout();
            // 
            // epTelefono
            // 
            this.epTelefono.ContainerControl = this;
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.txtCarrera);
            this.gbCarrera.Controls.Add(this.txtTelefono);
            this.gbCarrera.Controls.Add(this.label4);
            this.gbCarrera.Controls.Add(this.txtDireccion);
            this.gbCarrera.Controls.Add(this.label2);
            this.gbCarrera.Controls.Add(this.btnCerrar);
            this.gbCarrera.Controls.Add(this.btnGuardar);
            this.gbCarrera.Controls.Add(this.label5);
            this.gbCarrera.Controls.Add(this.dtpFechaAlta);
            this.gbCarrera.Controls.Add(this.label3);
            this.gbCarrera.Controls.Add(this.txtAlumno);
            this.gbCarrera.Controls.Add(this.label1);
            this.gbCarrera.Location = new System.Drawing.Point(1, -1);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Size = new System.Drawing.Size(916, 687);
            this.gbCarrera.TabIndex = 2;
            this.gbCarrera.TabStop = false;
            // 
            // txtCarrera
            // 
            this.txtCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarrera.Location = new System.Drawing.Point(322, 349);
            this.txtCarrera.MaxLength = 50;
            this.txtCarrera.Multiline = true;
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(552, 37);
            this.txtCarrera.TabIndex = 5;
            this.txtCarrera.TextChanged += new System.EventHandler(this.TxtCarrera_TextChanged);
            this.txtCarrera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsLetterOrNumberPressed);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(322, 207);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Multiline = true;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(552, 37);
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.TextChanged += new System.EventHandler(this.TxtTelefono_TextChanged);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumberPressed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(22, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 36);
            this.label4.TabIndex = 14;
            this.label4.Text = "Telefono:";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(322, 128);
            this.txtDireccion.MaxLength = 250;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(552, 37);
            this.txtDireccion.TabIndex = 2;
            this.txtDireccion.TextChanged += new System.EventHandler(this.TxtDireccion_TextChanged);
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsLetterOrNumberPressed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(22, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 36);
            this.label2.TabIndex = 12;
            this.label2.Text = "Direccion:";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(600, 572);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(274, 77);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(28, 572);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(274, 77);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(22, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 36);
            this.label5.TabIndex = 9;
            this.label5.Text = "Carrera:";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaAlta.Location = new System.Drawing.Point(322, 280);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(552, 41);
            this.dtpFechaAlta.TabIndex = 4;
            this.dtpFechaAlta.ValueChanged += new System.EventHandler(this.DtpFechaAlta_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(22, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 36);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de nacimiento";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // txtAlumno
            // 
            this.txtAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlumno.Location = new System.Drawing.Point(322, 52);
            this.txtAlumno.MaxLength = 250;
            this.txtAlumno.Multiline = true;
            this.txtAlumno.Name = "txtAlumno";
            this.txtAlumno.Size = new System.Drawing.Size(552, 37);
            this.txtAlumno.TabIndex = 1;
            this.txtAlumno.TextChanged += new System.EventHandler(this.TxtAlumno_TextChanged);
            this.txtAlumno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsLetterPressed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alumno:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // frmAltaAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(916, 687);
            this.Controls.Add(this.gbCarrera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAltaAlumno";
            this.Text = "frmAltaAlumno";
            ((System.ComponentModel.ISupportInitialize)(this.epTelefono)).EndInit();
            this.gbCarrera.ResumeLayout(false);
            this.gbCarrera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epTelefono;
        private System.Windows.Forms.GroupBox gbCarrera;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaAlta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAlumno;
        private System.Windows.Forms.Label label1;
    }
}