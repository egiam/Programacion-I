namespace TUP_PI_Parcial1
{
    partial class frmViajes
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegistrarViaje = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroViaje = new System.Windows.Forms.TextBox();
            this.txtLugarDestino = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegistrarEstudiante = new System.Windows.Forms.Button();
            this.rbtFemenino = new System.Windows.Forms.RadioButton();
            this.rbtMasculino = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCostoTotal = new System.Windows.Forms.Button();
            this.btnPorcentaje = new System.Windows.Forms.Button();
            this.lblCostoTotal = new System.Windows.Forms.Label();
            this.lblPorcentajeMayor = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistrarViaje
            // 
            this.btnRegistrarViaje.Location = new System.Drawing.Point(53, 173);
            this.btnRegistrarViaje.Name = "btnRegistrarViaje";
            this.btnRegistrarViaje.Size = new System.Drawing.Size(133, 23);
            this.btnRegistrarViaje.TabIndex = 0;
            this.btnRegistrarViaje.Text = "Registrar Viaje";
            this.btnRegistrarViaje.UseVisualStyleBackColor = true;
            this.btnRegistrarViaje.Click += new System.EventHandler(this.btnRegistrarViaje_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número Viaje";
            // 
            // txtNumeroViaje
            // 
            this.txtNumeroViaje.Location = new System.Drawing.Point(86, 28);
            this.txtNumeroViaje.Name = "txtNumeroViaje";
            this.txtNumeroViaje.Size = new System.Drawing.Size(64, 20);
            this.txtNumeroViaje.TabIndex = 2;
            // 
            // txtLugarDestino
            // 
            this.txtLugarDestino.Location = new System.Drawing.Point(86, 73);
            this.txtLugarDestino.Name = "txtLugarDestino";
            this.txtLugarDestino.Size = new System.Drawing.Size(144, 20);
            this.txtLugarDestino.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lugar Destino";
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.Location = new System.Drawing.Point(86, 121);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.Size = new System.Drawing.Size(64, 20);
            this.txtCostoUnitario.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Costo Unitario";
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(70, 77);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(47, 20);
            this.txtEdad.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Edad";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(70, 51);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(144, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nombre";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(70, 25);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(78, 20);
            this.txtLegajo.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Legajo";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRegistrarEstudiante);
            this.groupBox1.Controls.Add(this.rbtFemenino);
            this.groupBox1.Controls.Add(this.rbtMasculino);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPromedio);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtEdad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLegajo);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(255, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 206);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estudiante";
            // 
            // btnRegistrarEstudiante
            // 
            this.btnRegistrarEstudiante.Location = new System.Drawing.Point(31, 173);
            this.btnRegistrarEstudiante.Name = "btnRegistrarEstudiante";
            this.btnRegistrarEstudiante.Size = new System.Drawing.Size(133, 23);
            this.btnRegistrarEstudiante.TabIndex = 18;
            this.btnRegistrarEstudiante.Text = "Registrar Estudiante";
            this.btnRegistrarEstudiante.UseVisualStyleBackColor = true;
            this.btnRegistrarEstudiante.Click += new System.EventHandler(this.btnRegistrarEstudiante_Click);
            // 
            // rbtFemenino
            // 
            this.rbtFemenino.AutoSize = true;
            this.rbtFemenino.Location = new System.Drawing.Point(70, 124);
            this.rbtFemenino.Name = "rbtFemenino";
            this.rbtFemenino.Size = new System.Drawing.Size(71, 17);
            this.rbtFemenino.TabIndex = 17;
            this.rbtFemenino.TabStop = true;
            this.rbtFemenino.Text = "Femenino";
            this.rbtFemenino.UseVisualStyleBackColor = true;
            // 
            // rbtMasculino
            // 
            this.rbtMasculino.AutoSize = true;
            this.rbtMasculino.Location = new System.Drawing.Point(70, 104);
            this.rbtMasculino.Name = "rbtMasculino";
            this.rbtMasculino.Size = new System.Drawing.Size(73, 17);
            this.rbtMasculino.TabIndex = 16;
            this.rbtMasculino.TabStop = true;
            this.rbtMasculino.Text = "Masculino";
            this.rbtMasculino.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Sexo";
            // 
            // txtPromedio
            // 
            this.txtPromedio.Location = new System.Drawing.Point(70, 147);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.Size = new System.Drawing.Size(47, 20);
            this.txtPromedio.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Promedio";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRegistrarViaje);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCostoUnitario);
            this.groupBox2.Controls.Add(this.txtNumeroViaje);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtLugarDestino);
            this.groupBox2.Location = new System.Drawing.Point(5, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 206);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Viaje";
            // 
            // btnCostoTotal
            // 
            this.btnCostoTotal.Location = new System.Drawing.Point(58, 224);
            this.btnCostoTotal.Name = "btnCostoTotal";
            this.btnCostoTotal.Size = new System.Drawing.Size(133, 23);
            this.btnCostoTotal.TabIndex = 15;
            this.btnCostoTotal.Text = "Calcular Costo Total";
            this.btnCostoTotal.UseVisualStyleBackColor = true;
            this.btnCostoTotal.Click += new System.EventHandler(this.btnCostoTotal_Click);
            // 
            // btnPorcentaje
            // 
            this.btnPorcentaje.Location = new System.Drawing.Point(286, 224);
            this.btnPorcentaje.Name = "btnPorcentaje";
            this.btnPorcentaje.Size = new System.Drawing.Size(133, 23);
            this.btnPorcentaje.TabIndex = 16;
            this.btnPorcentaje.Text = "Calcular Porcentaje";
            this.btnPorcentaje.UseVisualStyleBackColor = true;
            this.btnPorcentaje.Click += new System.EventHandler(this.btnPorcentaje_Click);
            // 
            // lblCostoTotal
            // 
            this.lblCostoTotal.AutoSize = true;
            this.lblCostoTotal.Location = new System.Drawing.Point(88, 255);
            this.lblCostoTotal.Name = "lblCostoTotal";
            this.lblCostoTotal.Size = new System.Drawing.Size(13, 13);
            this.lblCostoTotal.TabIndex = 17;
            this.lblCostoTotal.Text = "$";
            // 
            // lblPorcentajeMayor
            // 
            this.lblPorcentajeMayor.AutoSize = true;
            this.lblPorcentajeMayor.Location = new System.Drawing.Point(372, 255);
            this.lblPorcentajeMayor.Name = "lblPorcentajeMayor";
            this.lblPorcentajeMayor.Size = new System.Drawing.Size(15, 13);
            this.lblPorcentajeMayor.TabIndex = 19;
            this.lblPorcentajeMayor.Text = "%";
            // 
            // frmViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 287);
            this.Controls.Add(this.lblPorcentajeMayor);
            this.Controls.Add(this.lblCostoTotal);
            this.Controls.Add(this.btnPorcentaje);
            this.Controls.Add(this.btnCostoTotal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmViajes";
            this.Text = "Agencia de Viajes";
            this.Load += new System.EventHandler(this.frmViajes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarViaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroViaje;
        private System.Windows.Forms.TextBox txtLugarDestino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRegistrarEstudiante;
        private System.Windows.Forms.RadioButton rbtFemenino;
        private System.Windows.Forms.RadioButton rbtMasculino;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPromedio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCostoTotal;
        private System.Windows.Forms.Button btnPorcentaje;
        private System.Windows.Forms.Label lblCostoTotal;
        private System.Windows.Forms.Label lblPorcentajeMayor;
    }
}

