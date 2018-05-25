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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Elemento));
            this.real = new System.Windows.Forms.TextBox();
            this.real_label = new System.Windows.Forms.Label();
            this.descuento = new System.Windows.Forms.TextBox();
            this.descuento_label = new System.Windows.Forms.Label();
            this.estimado = new System.Windows.Forms.TextBox();
            this.estimado_label = new System.Windows.Forms.Label();
            this.actualizar = new System.Windows.Forms.Button();
            this.elemento_label = new System.Windows.Forms.Label();
            this.eliminar = new System.Windows.Forms.Button();
            this.elementoText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // real
            // 
            this.real.Location = new System.Drawing.Point(201, 217);
            this.real.Name = "real";
            this.real.Size = new System.Drawing.Size(100, 20);
            this.real.TabIndex = 54;
            this.real.Text = "0";
            // 
            // real_label
            // 
            this.real_label.AutoSize = true;
            this.real_label.Location = new System.Drawing.Point(99, 220);
            this.real_label.Name = "real_label";
            this.real_label.Size = new System.Drawing.Size(32, 13);
            this.real_label.TabIndex = 53;
            this.real_label.Text = "Real:";
            // 
            // descuento
            // 
            this.descuento.Location = new System.Drawing.Point(200, 180);
            this.descuento.Name = "descuento";
            this.descuento.Size = new System.Drawing.Size(100, 20);
            this.descuento.TabIndex = 52;
            this.descuento.Text = "0";
            // 
            // descuento_label
            // 
            this.descuento_label.AutoSize = true;
            this.descuento_label.Location = new System.Drawing.Point(99, 183);
            this.descuento_label.Name = "descuento_label";
            this.descuento_label.Size = new System.Drawing.Size(62, 13);
            this.descuento_label.TabIndex = 51;
            this.descuento_label.Text = "Descuento:";
            // 
            // estimado
            // 
            this.estimado.Location = new System.Drawing.Point(200, 145);
            this.estimado.Name = "estimado";
            this.estimado.Size = new System.Drawing.Size(100, 20);
            this.estimado.TabIndex = 50;
            this.estimado.Text = "0";
            // 
            // estimado_label
            // 
            this.estimado_label.AutoSize = true;
            this.estimado_label.Location = new System.Drawing.Point(98, 148);
            this.estimado_label.Name = "estimado_label";
            this.estimado_label.Size = new System.Drawing.Size(53, 13);
            this.estimado_label.TabIndex = 49;
            this.estimado_label.Text = "Estimado:";
            // 
            // actualizar
            // 
            this.actualizar.Location = new System.Drawing.Point(101, 267);
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
            this.elemento_label.Location = new System.Drawing.Point(98, 110);
            this.elemento_label.Name = "elemento_label";
            this.elemento_label.Size = new System.Drawing.Size(54, 13);
            this.elemento_label.TabIndex = 44;
            this.elemento_label.Text = "Elemento:";
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(226, 267);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(75, 23);
            this.eliminar.TabIndex = 55;
            this.eliminar.Text = "ELIMINAR";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // elementoText
            // 
            this.elementoText.Location = new System.Drawing.Point(200, 107);
            this.elementoText.Name = "elementoText";
            this.elementoText.Size = new System.Drawing.Size(100, 20);
            this.elementoText.TabIndex = 56;
            this.elementoText.Text = "0";
            // 
            // Elemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(503, 450);
            this.Controls.Add(this.elementoText);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.real);
            this.Controls.Add(this.real_label);
            this.Controls.Add(this.descuento);
            this.Controls.Add(this.descuento_label);
            this.Controls.Add(this.estimado);
            this.Controls.Add(this.estimado_label);
            this.Controls.Add(this.actualizar);
            this.Controls.Add(this.elemento_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button actualizar;
        private System.Windows.Forms.Label elemento_label;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.TextBox elementoText;
    }
}