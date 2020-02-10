namespace UX1
{
    partial class frmAltaHorario
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
            this.cbFAHMateria = new System.Windows.Forms.ComboBox();
            this.cbFAHCarrera = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFAHDia1 = new System.Windows.Forms.ComboBox();
            this.cbFAHDia2 = new System.Windows.Forms.ComboBox();
            this.gbCarrera.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCarrera
            // 
            this.gbCarrera.Controls.Add(this.cbFAHDia2);
            this.gbCarrera.Controls.Add(this.cbFAHDia1);
            this.gbCarrera.Controls.Add(this.cbFAHMateria);
            this.gbCarrera.Controls.Add(this.cbFAHCarrera);
            this.gbCarrera.Controls.Add(this.label4);
            this.gbCarrera.Controls.Add(this.label2);
            this.gbCarrera.Controls.Add(this.btnCerrar);
            this.gbCarrera.Controls.Add(this.btnGuardar);
            this.gbCarrera.Controls.Add(this.label5);
            this.gbCarrera.Controls.Add(this.label3);
            this.gbCarrera.Controls.Add(this.label1);
            this.gbCarrera.Location = new System.Drawing.Point(-11, -25);
            this.gbCarrera.Name = "gbCarrera";
            this.gbCarrera.Size = new System.Drawing.Size(910, 673);
            this.gbCarrera.TabIndex = 3;
            this.gbCarrera.TabStop = false;
            // 
            // cbFAHMateria
            // 
            this.cbFAHMateria.DropDownHeight = 200;
            this.cbFAHMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFAHMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFAHMateria.FormattingEnabled = true;
            this.cbFAHMateria.IntegralHeight = false;
            this.cbFAHMateria.Location = new System.Drawing.Point(322, 132);
            this.cbFAHMateria.Name = "cbFAHMateria";
            this.cbFAHMateria.Size = new System.Drawing.Size(552, 41);
            this.cbFAHMateria.TabIndex = 16;
            // 
            // cbFAHCarrera
            // 
            this.cbFAHCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFAHCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFAHCarrera.FormattingEnabled = true;
            this.cbFAHCarrera.Location = new System.Drawing.Point(322, 53);
            this.cbFAHCarrera.Name = "cbFAHCarrera";
            this.cbFAHCarrera.Size = new System.Drawing.Size(552, 41);
            this.cbFAHCarrera.TabIndex = 15;
            this.cbFAHCarrera.TextChanged += new System.EventHandler(this.cbFAHCarrera_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(22, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 36);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dia 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(22, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 36);
            this.label2.TabIndex = 12;
            this.label2.Text = "Materia:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(600, 572);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(274, 77);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(28, 572);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(274, 77);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(22, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 36);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dia 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carrera:";
            // 
            // cbFAHDia1
            // 
            this.cbFAHDia1.DropDownHeight = 200;
            this.cbFAHDia1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFAHDia1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFAHDia1.FormattingEnabled = true;
            this.cbFAHDia1.IntegralHeight = false;
            this.cbFAHDia1.Location = new System.Drawing.Point(322, 203);
            this.cbFAHDia1.Name = "cbFAHDia1";
            this.cbFAHDia1.Size = new System.Drawing.Size(552, 41);
            this.cbFAHDia1.TabIndex = 17;
            // 
            // cbFAHDia2
            // 
            this.cbFAHDia2.DropDownHeight = 200;
            this.cbFAHDia2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFAHDia2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFAHDia2.FormattingEnabled = true;
            this.cbFAHDia2.IntegralHeight = false;
            this.cbFAHDia2.Location = new System.Drawing.Point(322, 283);
            this.cbFAHDia2.Name = "cbFAHDia2";
            this.cbFAHDia2.Size = new System.Drawing.Size(552, 41);
            this.cbFAHDia2.TabIndex = 18;
            // 
            // frmAltaHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(900, 648);
            this.Controls.Add(this.gbCarrera);
            this.Name = "frmAltaHorario";
            this.Text = "AltaHorario";
            this.gbCarrera.ResumeLayout(false);
            this.gbCarrera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCarrera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFAHCarrera;
        private System.Windows.Forms.ComboBox cbFAHMateria;
        private System.Windows.Forms.ComboBox cbFAHDia2;
        private System.Windows.Forms.ComboBox cbFAHDia1;
    }
}