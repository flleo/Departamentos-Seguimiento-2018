namespace Departamentos_Seguimiento_2018
{
    partial class Elemento
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
            this.real = new System.Windows.Forms.TextBox();
            this.real_label = new System.Windows.Forms.Label();
            this.descuento = new System.Windows.Forms.TextBox();
            this.descuento_label = new System.Windows.Forms.Label();
            this.estimado = new System.Windows.Forms.TextBox();
            this.estimado_label = new System.Windows.Forms.Label();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.actualizar = new System.Windows.Forms.Button();
            this.elemento_label = new System.Windows.Forms.Label();
            this.concepto_label = new System.Windows.Forms.Label();
            this.area_label = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.introduzcaFecha = new System.Windows.Forms.Label();
            this.eliminar = new System.Windows.Forms.Button();
            this.elementoText = new System.Windows.Forms.TextBox();
            this.concepto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // real
            // 
            this.real.Location = new System.Drawing.Point(201, 306);
            this.real.Name = "real";
            this.real.Size = new System.Drawing.Size(100, 20);
            this.real.TabIndex = 54;
            this.real.Text = "0";
            // 
            // real_label
            // 
            this.real_label.AutoSize = true;
            this.real_label.Location = new System.Drawing.Point(99, 309);
            this.real_label.Name = "real_label";
            this.real_label.Size = new System.Drawing.Size(32, 13);
            this.real_label.TabIndex = 53;
            this.real_label.Text = "Real:";
            // 
            // descuento
            // 
            this.descuento.Location = new System.Drawing.Point(200, 269);
            this.descuento.Name = "descuento";
            this.descuento.Size = new System.Drawing.Size(100, 20);
            this.descuento.TabIndex = 52;
            this.descuento.Text = "0";
            // 
            // descuento_label
            // 
            this.descuento_label.AutoSize = true;
            this.descuento_label.Location = new System.Drawing.Point(99, 272);
            this.descuento_label.Name = "descuento_label";
            this.descuento_label.Size = new System.Drawing.Size(62, 13);
            this.descuento_label.TabIndex = 51;
            this.descuento_label.Text = "Descuento:";
            // 
            // estimado
            // 
            this.estimado.Location = new System.Drawing.Point(200, 234);
            this.estimado.Name = "estimado";
            this.estimado.Size = new System.Drawing.Size(100, 20);
            this.estimado.TabIndex = 50;
            this.estimado.Text = "0";
            // 
            // estimado_label
            // 
            this.estimado_label.AutoSize = true;
            this.estimado_label.Location = new System.Drawing.Point(98, 237);
            this.estimado_label.Name = "estimado_label";
            this.estimado_label.Size = new System.Drawing.Size(53, 13);
            this.estimado_label.TabIndex = 49;
            this.estimado_label.Text = "Estimado:";
            // 
            // comboArea
            // 
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(200, 189);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(121, 21);
            this.comboArea.TabIndex = 48;
            // 
            // actualizar
            // 
            this.actualizar.Location = new System.Drawing.Point(101, 356);
            this.actualizar.Name = "actualizar";
            this.actualizar.Size = new System.Drawing.Size(90, 23);
            this.actualizar.TabIndex = 45;
            this.actualizar.Text = "ACTUALIZAR";
            this.actualizar.UseVisualStyleBackColor = true;
            this.actualizar.Click += new System.EventHandler(this.actualizar_Click);
            // 
            // elemento_label
            // 
            this.elemento_label.AutoSize = true;
            this.elemento_label.Location = new System.Drawing.Point(98, 151);
            this.elemento_label.Name = "elemento_label";
            this.elemento_label.Size = new System.Drawing.Size(54, 13);
            this.elemento_label.TabIndex = 44;
            this.elemento_label.Text = "Elemento:";
            // 
            // concepto_label
            // 
            this.concepto_label.AutoSize = true;
            this.concepto_label.Location = new System.Drawing.Point(98, 115);
            this.concepto_label.Name = "concepto_label";
            this.concepto_label.Size = new System.Drawing.Size(56, 13);
            this.concepto_label.TabIndex = 43;
            this.concepto_label.Text = "Concepto:";
            // 
            // area_label
            // 
            this.area_label.AutoSize = true;
            this.area_label.Location = new System.Drawing.Point(98, 192);
            this.area_label.Name = "area_label";
            this.area_label.Size = new System.Drawing.Size(35, 13);
            this.area_label.TabIndex = 42;
            this.area_label.Text = "Area: ";
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(200, 71);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 41;
            // 
            // introduzcaFecha
            // 
            this.introduzcaFecha.AutoSize = true;
            this.introduzcaFecha.Location = new System.Drawing.Point(98, 77);
            this.introduzcaFecha.Name = "introduzcaFecha";
            this.introduzcaFecha.Size = new System.Drawing.Size(93, 13);
            this.introduzcaFecha.TabIndex = 40;
            this.introduzcaFecha.Text = "Introduzca fecha: ";
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(226, 356);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(75, 23);
            this.eliminar.TabIndex = 55;
            this.eliminar.Text = "ELIMINAR";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // elementoText
            // 
            this.elementoText.Location = new System.Drawing.Point(200, 148);
            this.elementoText.Name = "elementoText";
            this.elementoText.ReadOnly = true;
            this.elementoText.Size = new System.Drawing.Size(100, 20);
            this.elementoText.TabIndex = 56;
            this.elementoText.Text = "0";
            // 
            // concepto
            // 
            this.concepto.Location = new System.Drawing.Point(201, 112);
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            this.concepto.Size = new System.Drawing.Size(100, 20);
            this.concepto.TabIndex = 57;
            this.concepto.Text = "0";
            // 
            // Elemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 450);
            this.Controls.Add(this.concepto);
            this.Controls.Add(this.elementoText);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.real);
            this.Controls.Add(this.real_label);
            this.Controls.Add(this.descuento);
            this.Controls.Add(this.descuento_label);
            this.Controls.Add(this.estimado);
            this.Controls.Add(this.estimado_label);
            this.Controls.Add(this.comboArea);
            this.Controls.Add(this.actualizar);
            this.Controls.Add(this.elemento_label);
            this.Controls.Add(this.concepto_label);
            this.Controls.Add(this.area_label);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.introduzcaFecha);
            this.Name = "Elemento";
            this.Text = "Departamentos Seguimiento 2018  - Elemento";
            this.Load += new System.EventHandler(this.Elemento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox real;
        private System.Windows.Forms.Label real_label;
        private System.Windows.Forms.TextBox descuento;
        private System.Windows.Forms.Label descuento_label;
        private System.Windows.Forms.TextBox estimado;
        private System.Windows.Forms.Label estimado_label;
        private System.Windows.Forms.ComboBox comboArea;
        private System.Windows.Forms.Button actualizar;
        private System.Windows.Forms.Label elemento_label;
        private System.Windows.Forms.Label concepto_label;
        private System.Windows.Forms.Label area_label;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label introduzcaFecha;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.TextBox elementoText;
        private System.Windows.Forms.TextBox concepto;
    }
}