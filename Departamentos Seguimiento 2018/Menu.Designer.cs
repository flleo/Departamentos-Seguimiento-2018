namespace Departamentos_Seguimiento_2018
{
    partial class Menu
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
            this.abrir = new System.Windows.Forms.Button();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.introduzcaFecha = new System.Windows.Forms.Label();
            this.nuevoAsiento = new System.Windows.Forms.Button();
            this.grabarAsiento = new System.Windows.Forms.Button();
            this.elemento_label = new System.Windows.Forms.Label();
            this.concepto_label = new System.Windows.Forms.Label();
            this.area_label = new System.Windows.Forms.Label();
            this.comboConcepto = new System.Windows.Forms.ComboBox();
            this.nuevoElemento = new System.Windows.Forms.Button();
            this.nuevaArea = new System.Windows.Forms.Button();
            this.comboConceptoE = new System.Windows.Forms.ComboBox();
            this.elemento = new System.Windows.Forms.TextBox();
            this.elemento_labelE = new System.Windows.Forms.Label();
            this.concepto_labelE = new System.Windows.Forms.Label();
            this.grabarElemento = new System.Windows.Forms.Button();
            this.area = new System.Windows.Forms.TextBox();
            this.area_labelA = new System.Windows.Forms.Label();
            this.comboElemento = new System.Windows.Forms.ComboBox();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.grabarArea = new System.Windows.Forms.Button();
            this.estimado_label = new System.Windows.Forms.Label();
            this.estimado = new System.Windows.Forms.TextBox();
            this.descuento = new System.Windows.Forms.TextBox();
            this.descuento_label = new System.Windows.Forms.Label();
            this.real = new System.Windows.Forms.TextBox();
            this.real_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // abrir
            // 
            this.abrir.Cursor = System.Windows.Forms.Cursors.Default;
            this.abrir.Location = new System.Drawing.Point(173, 26);
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(75, 23);
            this.abrir.TabIndex = 1;
            this.abrir.Text = "ABRIR";
            this.abrir.UseVisualStyleBackColor = true;
            this.abrir.Click += new System.EventHandler(this.abrir_Click);
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(148, 81);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 3;
            // 
            // introduzcaFecha
            // 
            this.introduzcaFecha.AutoSize = true;
            this.introduzcaFecha.Location = new System.Drawing.Point(46, 87);
            this.introduzcaFecha.Name = "introduzcaFecha";
            this.introduzcaFecha.Size = new System.Drawing.Size(93, 13);
            this.introduzcaFecha.TabIndex = 2;
            this.introduzcaFecha.Text = "Introduzca fecha: ";
            // 
            // nuevoAsiento
            // 
            this.nuevoAsiento.Location = new System.Drawing.Point(49, 26);
            this.nuevoAsiento.Name = "nuevoAsiento";
            this.nuevoAsiento.Size = new System.Drawing.Size(105, 23);
            this.nuevoAsiento.TabIndex = 4;
            this.nuevoAsiento.Text = "NUEVO ASIENTO";
            this.nuevoAsiento.UseVisualStyleBackColor = true;
            this.nuevoAsiento.Click += new System.EventHandler(this.nuevoAsiento_Click);
            // 
            // grabarAsiento
            // 
            this.grabarAsiento.Location = new System.Drawing.Point(294, 316);
            this.grabarAsiento.Name = "grabarAsiento";
            this.grabarAsiento.Size = new System.Drawing.Size(75, 23);
            this.grabarAsiento.TabIndex = 19;
            this.grabarAsiento.Text = "GRABAR";
            this.grabarAsiento.UseVisualStyleBackColor = true;
            this.grabarAsiento.Visible = false;
            this.grabarAsiento.Click += new System.EventHandler(this.grabarAsiento_Click);
            // 
            // elemento_label
            // 
            this.elemento_label.AutoSize = true;
            this.elemento_label.Location = new System.Drawing.Point(46, 161);
            this.elemento_label.Name = "elemento_label";
            this.elemento_label.Size = new System.Drawing.Size(54, 13);
            this.elemento_label.TabIndex = 17;
            this.elemento_label.Text = "Elemento:";
            this.elemento_label.Visible = false;
            // 
            // concepto_label
            // 
            this.concepto_label.AutoSize = true;
            this.concepto_label.Location = new System.Drawing.Point(46, 125);
            this.concepto_label.Name = "concepto_label";
            this.concepto_label.Size = new System.Drawing.Size(56, 13);
            this.concepto_label.TabIndex = 15;
            this.concepto_label.Text = "Concepto:";
            this.concepto_label.Visible = false;
            // 
            // area_label
            // 
            this.area_label.AutoSize = true;
            this.area_label.Location = new System.Drawing.Point(46, 202);
            this.area_label.Name = "area_label";
            this.area_label.Size = new System.Drawing.Size(35, 13);
            this.area_label.TabIndex = 13;
            this.area_label.Text = "Area: ";
            this.area_label.Visible = false;
            // 
            // comboConcepto
            // 
            this.comboConcepto.FormattingEnabled = true;
            this.comboConcepto.Location = new System.Drawing.Point(148, 122);
            this.comboConcepto.Name = "comboConcepto";
            this.comboConcepto.Size = new System.Drawing.Size(121, 21);
            this.comboConcepto.TabIndex = 21;
            this.comboConcepto.Visible = false;
            this.comboConcepto.SelectedIndexChanged += new System.EventHandler(this.comboConcepto_SelectedIndexChanged);
            // 
            // nuevoElemento
            // 
            this.nuevoElemento.Location = new System.Drawing.Point(391, 26);
            this.nuevoElemento.Name = "nuevoElemento";
            this.nuevoElemento.Size = new System.Drawing.Size(117, 23);
            this.nuevoElemento.TabIndex = 22;
            this.nuevoElemento.Text = "NUEVO ELEMENTO";
            this.nuevoElemento.UseVisualStyleBackColor = true;
            this.nuevoElemento.Click += new System.EventHandler(this.nuevoElemento_Click);
            // 
            // nuevaArea
            // 
            this.nuevaArea.Location = new System.Drawing.Point(612, 26);
            this.nuevaArea.Name = "nuevaArea";
            this.nuevaArea.Size = new System.Drawing.Size(87, 23);
            this.nuevaArea.TabIndex = 23;
            this.nuevaArea.Text = "NUEVA AREA";
            this.nuevaArea.UseVisualStyleBackColor = true;
            this.nuevaArea.Click += new System.EventHandler(this.nuevaArea_Click);
            // 
            // comboConceptoE
            // 
            this.comboConceptoE.FormattingEnabled = true;
            this.comboConceptoE.Location = new System.Drawing.Point(450, 79);
            this.comboConceptoE.Name = "comboConceptoE";
            this.comboConceptoE.Size = new System.Drawing.Size(121, 21);
            this.comboConceptoE.TabIndex = 27;
            this.comboConceptoE.Visible = false;
            // 
            // elemento
            // 
            this.elemento.Location = new System.Drawing.Point(450, 161);
            this.elemento.Name = "elemento";
            this.elemento.Size = new System.Drawing.Size(100, 20);
            this.elemento.TabIndex = 26;
            this.elemento.Visible = false;
            // 
            // elemento_labelE
            // 
            this.elemento_labelE.AutoSize = true;
            this.elemento_labelE.Location = new System.Drawing.Point(388, 163);
            this.elemento_labelE.Name = "elemento_labelE";
            this.elemento_labelE.Size = new System.Drawing.Size(54, 13);
            this.elemento_labelE.TabIndex = 25;
            this.elemento_labelE.Text = "Elemento:";
            this.elemento_labelE.Visible = false;
            // 
            // concepto_labelE
            // 
            this.concepto_labelE.AutoSize = true;
            this.concepto_labelE.Location = new System.Drawing.Point(388, 81);
            this.concepto_labelE.Name = "concepto_labelE";
            this.concepto_labelE.Size = new System.Drawing.Size(56, 13);
            this.concepto_labelE.TabIndex = 24;
            this.concepto_labelE.Text = "Concepto:";
            this.concepto_labelE.Visible = false;
            // 
            // grabarElemento
            // 
            this.grabarElemento.Location = new System.Drawing.Point(391, 201);
            this.grabarElemento.Name = "grabarElemento";
            this.grabarElemento.Size = new System.Drawing.Size(75, 23);
            this.grabarElemento.TabIndex = 30;
            this.grabarElemento.Text = "GRABAR";
            this.grabarElemento.UseVisualStyleBackColor = true;
            this.grabarElemento.Visible = false;
            this.grabarElemento.Click += new System.EventHandler(this.grabarElemento_Click);
            // 
            // area
            // 
            this.area.Location = new System.Drawing.Point(650, 78);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(100, 20);
            this.area.TabIndex = 29;
            this.area.Visible = false;
            // 
            // area_labelA
            // 
            this.area_labelA.AutoSize = true;
            this.area_labelA.Location = new System.Drawing.Point(609, 81);
            this.area_labelA.Name = "area_labelA";
            this.area_labelA.Size = new System.Drawing.Size(35, 13);
            this.area_labelA.TabIndex = 28;
            this.area_labelA.Text = "Area: ";
            this.area_labelA.Visible = false;
            // 
            // comboElemento
            // 
            this.comboElemento.FormattingEnabled = true;
            this.comboElemento.Location = new System.Drawing.Point(148, 161);
            this.comboElemento.Name = "comboElemento";
            this.comboElemento.Size = new System.Drawing.Size(121, 21);
            this.comboElemento.TabIndex = 31;
            this.comboElemento.Visible = false;
            // 
            // comboArea
            // 
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(148, 199);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(121, 21);
            this.comboArea.TabIndex = 32;
            this.comboArea.Visible = false;
            // 
            // grabarArea
            // 
            this.grabarArea.Location = new System.Drawing.Point(612, 113);
            this.grabarArea.Name = "grabarArea";
            this.grabarArea.Size = new System.Drawing.Size(75, 23);
            this.grabarArea.TabIndex = 33;
            this.grabarArea.Text = "GRABAR";
            this.grabarArea.UseVisualStyleBackColor = true;
            this.grabarArea.Visible = false;
            this.grabarArea.Click += new System.EventHandler(this.grabarArea_Click);
            // 
            // estimado_label
            // 
            this.estimado_label.AutoSize = true;
            this.estimado_label.Location = new System.Drawing.Point(46, 247);
            this.estimado_label.Name = "estimado_label";
            this.estimado_label.Size = new System.Drawing.Size(53, 13);
            this.estimado_label.TabIndex = 34;
            this.estimado_label.Text = "Estimado:";
            this.estimado_label.Visible = false;
            // 
            // estimado
            // 
            this.estimado.Location = new System.Drawing.Point(148, 244);
            this.estimado.Name = "estimado";
            this.estimado.Size = new System.Drawing.Size(100, 20);
            this.estimado.TabIndex = 35;
            this.estimado.Text = "0";
            this.estimado.Visible = false;
            // 
            // descuento
            // 
            this.descuento.Location = new System.Drawing.Point(148, 279);
            this.descuento.Name = "descuento";
            this.descuento.Size = new System.Drawing.Size(100, 20);
            this.descuento.TabIndex = 37;
            this.descuento.Text = "0";
            this.descuento.Visible = false;
            // 
            // descuento_label
            // 
            this.descuento_label.AutoSize = true;
            this.descuento_label.Location = new System.Drawing.Point(47, 282);
            this.descuento_label.Name = "descuento_label";
            this.descuento_label.Size = new System.Drawing.Size(62, 13);
            this.descuento_label.TabIndex = 36;
            this.descuento_label.Text = "Descuento:";
            this.descuento_label.Visible = false;
            // 
            // real
            // 
            this.real.Location = new System.Drawing.Point(149, 316);
            this.real.Name = "real";
            this.real.Size = new System.Drawing.Size(100, 20);
            this.real.TabIndex = 39;
            this.real.Text = "0";
            this.real.Visible = false;
            // 
            // real_label
            // 
            this.real_label.AutoSize = true;
            this.real_label.Location = new System.Drawing.Point(47, 319);
            this.real_label.Name = "real_label";
            this.real_label.Size = new System.Drawing.Size(32, 13);
            this.real_label.TabIndex = 38;
            this.real_label.Text = "Real:";
            this.real_label.Visible = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.real);
            this.Controls.Add(this.real_label);
            this.Controls.Add(this.descuento);
            this.Controls.Add(this.descuento_label);
            this.Controls.Add(this.estimado);
            this.Controls.Add(this.estimado_label);
            this.Controls.Add(this.grabarArea);
            this.Controls.Add(this.comboArea);
            this.Controls.Add(this.comboElemento);
            this.Controls.Add(this.grabarElemento);
            this.Controls.Add(this.area);
            this.Controls.Add(this.area_labelA);
            this.Controls.Add(this.comboConceptoE);
            this.Controls.Add(this.elemento);
            this.Controls.Add(this.elemento_labelE);
            this.Controls.Add(this.concepto_labelE);
            this.Controls.Add(this.nuevaArea);
            this.Controls.Add(this.nuevoElemento);
            this.Controls.Add(this.comboConcepto);
            this.Controls.Add(this.grabarAsiento);
            this.Controls.Add(this.elemento_label);
            this.Controls.Add(this.concepto_label);
            this.Controls.Add(this.area_label);
            this.Controls.Add(this.nuevoAsiento);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.introduzcaFecha);
            this.Controls.Add(this.abrir);
            this.Name = "Menu";
            this.Text = "Departamentos Seguimiento 2018 - Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button abrir;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label introduzcaFecha;
        private System.Windows.Forms.Button nuevoAsiento;
        private System.Windows.Forms.Button grabarAsiento;
        private System.Windows.Forms.Label elemento_label;
        private System.Windows.Forms.Label concepto_label;
        private System.Windows.Forms.Label area_label;
        private System.Windows.Forms.ComboBox comboConcepto;
        private System.Windows.Forms.Button nuevoElemento;
        private System.Windows.Forms.Button nuevaArea;
        private System.Windows.Forms.ComboBox comboConceptoE;
        private System.Windows.Forms.TextBox elemento;
        private System.Windows.Forms.Label elemento_labelE;
        private System.Windows.Forms.Label concepto_labelE;
        private System.Windows.Forms.Button grabarElemento;
        private System.Windows.Forms.TextBox area;
        private System.Windows.Forms.Label area_labelA;
        private System.Windows.Forms.ComboBox comboElemento;
        private System.Windows.Forms.ComboBox comboArea;
        private System.Windows.Forms.Button grabarArea;
        private System.Windows.Forms.Label estimado_label;
        private System.Windows.Forms.TextBox estimado;
        private System.Windows.Forms.TextBox descuento;
        private System.Windows.Forms.Label descuento_label;
        private System.Windows.Forms.TextBox real;
        private System.Windows.Forms.Label real_label;
    }
}

