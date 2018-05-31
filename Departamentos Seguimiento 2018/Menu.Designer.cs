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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.abrir = new System.Windows.Forms.Button();
            this.grabarAsiento = new System.Windows.Forms.Button();
            this.nuevoElemento = new System.Windows.Forms.Button();
            this.nuevaArea = new System.Windows.Forms.Button();
            this.elemento = new System.Windows.Forms.TextBox();
            this.elemento_labelE = new System.Windows.Forms.Label();
            this.concepto_labelE = new System.Windows.Forms.Label();
            this.grabarElemento = new System.Windows.Forms.Button();
            this.area = new System.Windows.Forms.TextBox();
            this.grabarArea = new System.Windows.Forms.Button();
            this.area_labelE = new System.Windows.Forms.Label();
            this.comboAreaA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboElementoA = new System.Windows.Forms.ComboBox();
            this.elementoArea = new System.Windows.Forms.Button();
            this.grabarEA = new System.Windows.Forms.Button();
            this.elementos_labelE = new System.Windows.Forms.Label();
            this.comboElementoE = new System.Windows.Forms.ComboBox();
            this.comboConcepto = new System.Windows.Forms.ComboBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.comboAreas = new System.Windows.Forms.ComboBox();
            this.eliminar = new System.Windows.Forms.Button();
            this.area_labelA = new System.Windows.Forms.Label();
            this.eliminarElemento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // abrir
            // 
            this.abrir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.abrir.Cursor = System.Windows.Forms.Cursors.Default;
            this.abrir.Location = new System.Drawing.Point(441, 22);
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(117, 23);
            this.abrir.TabIndex = 1;
            this.abrir.Text = "ABRIR";
            this.abrir.UseVisualStyleBackColor = false;
            this.abrir.Click += new System.EventHandler(this.abrir_Click);
            // 
            // grabarAsiento
            // 
            this.grabarAsiento.Location = new System.Drawing.Point(351, 750);
            this.grabarAsiento.Name = "grabarAsiento";
            this.grabarAsiento.Size = new System.Drawing.Size(75, 23);
            this.grabarAsiento.TabIndex = 19;
            this.grabarAsiento.Text = "GRABAR";
            this.grabarAsiento.UseVisualStyleBackColor = true;
            this.grabarAsiento.Visible = false;
            // 
            // nuevoElemento
            // 
            this.nuevoElemento.Location = new System.Drawing.Point(79, 69);
            this.nuevoElemento.Name = "nuevoElemento";
            this.nuevoElemento.Size = new System.Drawing.Size(117, 23);
            this.nuevoElemento.TabIndex = 22;
            this.nuevoElemento.Text = "NUEVO ELEMENTO";
            this.nuevoElemento.UseVisualStyleBackColor = true;
            this.nuevoElemento.Click += new System.EventHandler(this.nuevoElemento_Click);
            // 
            // nuevaArea
            // 
            this.nuevaArea.Location = new System.Drawing.Point(441, 69);
            this.nuevaArea.Name = "nuevaArea";
            this.nuevaArea.Size = new System.Drawing.Size(87, 23);
            this.nuevaArea.TabIndex = 23;
            this.nuevaArea.Text = "NUEVA AREA";
            this.nuevaArea.UseVisualStyleBackColor = true;
            this.nuevaArea.Click += new System.EventHandler(this.nuevaArea_Click_1);
            // 
            // elemento
            // 
            this.elemento.Enabled = false;
            this.elemento.Location = new System.Drawing.Point(82, 247);
            this.elemento.Name = "elemento";
            this.elemento.Size = new System.Drawing.Size(100, 20);
            this.elemento.TabIndex = 26;
            this.elemento.TextChanged += new System.EventHandler(this.elemento_TextChanged);
            // 
            // elemento_labelE
            // 
            this.elemento_labelE.AutoSize = true;
            this.elemento_labelE.Location = new System.Drawing.Point(79, 218);
            this.elemento_labelE.Name = "elemento_labelE";
            this.elemento_labelE.Size = new System.Drawing.Size(54, 13);
            this.elemento_labelE.TabIndex = 25;
            this.elemento_labelE.Text = "Elemento:";
            // 
            // concepto_labelE
            // 
            this.concepto_labelE.AutoSize = true;
            this.concepto_labelE.Location = new System.Drawing.Point(79, 114);
            this.concepto_labelE.Name = "concepto_labelE";
            this.concepto_labelE.Size = new System.Drawing.Size(56, 13);
            this.concepto_labelE.TabIndex = 24;
            this.concepto_labelE.Text = "Concepto:";
            // 
            // grabarElemento
            // 
            this.grabarElemento.Enabled = false;
            this.grabarElemento.Location = new System.Drawing.Point(82, 290);
            this.grabarElemento.Name = "grabarElemento";
            this.grabarElemento.Size = new System.Drawing.Size(75, 23);
            this.grabarElemento.TabIndex = 30;
            this.grabarElemento.Text = "GRABAR";
            this.grabarElemento.UseVisualStyleBackColor = true;
            this.grabarElemento.Click += new System.EventHandler(this.grabarElemento_Click);
            // 
            // area
            // 
            this.area.Enabled = false;
            this.area.Location = new System.Drawing.Point(554, 71);
            this.area.Name = "area";
            this.area.ShortcutsEnabled = false;
            this.area.Size = new System.Drawing.Size(100, 20);
            this.area.TabIndex = 29;
            this.area.TextChanged += new System.EventHandler(this.area_TextChanged);
            // 
            // grabarArea
            // 
            this.grabarArea.Enabled = false;
            this.grabarArea.Location = new System.Drawing.Point(681, 69);
            this.grabarArea.Name = "grabarArea";
            this.grabarArea.Size = new System.Drawing.Size(75, 23);
            this.grabarArea.TabIndex = 33;
            this.grabarArea.Text = "GRABAR";
            this.grabarArea.UseVisualStyleBackColor = true;
            this.grabarArea.Click += new System.EventHandler(this.grabarArea_Click);
            // 
            // area_labelE
            // 
            this.area_labelE.AutoSize = true;
            this.area_labelE.Location = new System.Drawing.Point(825, 186);
            this.area_labelE.Name = "area_labelE";
            this.area_labelE.Size = new System.Drawing.Size(35, 13);
            this.area_labelE.TabIndex = 46;
            this.area_labelE.Text = "Area: ";
            // 
            // comboAreaA
            // 
            this.comboAreaA.Enabled = false;
            this.comboAreaA.FormattingEnabled = true;
            this.comboAreaA.Location = new System.Drawing.Point(885, 183);
            this.comboAreaA.Name = "comboAreaA";
            this.comboAreaA.Size = new System.Drawing.Size(121, 21);
            this.comboAreaA.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(825, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Elemento:";
            // 
            // comboElementoA
            // 
            this.comboElementoA.Enabled = false;
            this.comboElementoA.FormattingEnabled = true;
            this.comboElementoA.Location = new System.Drawing.Point(885, 152);
            this.comboElementoA.Name = "comboElementoA";
            this.comboElementoA.Size = new System.Drawing.Size(121, 21);
            this.comboElementoA.TabIndex = 49;
            // 
            // elementoArea
            // 
            this.elementoArea.Location = new System.Drawing.Point(826, 69);
            this.elementoArea.Name = "elementoArea";
            this.elementoArea.Size = new System.Drawing.Size(117, 23);
            this.elementoArea.TabIndex = 50;
            this.elementoArea.Text = "ELEMENTO-AREA";
            this.elementoArea.UseVisualStyleBackColor = true;
            this.elementoArea.Click += new System.EventHandler(this.elementoArea_Click);
            // 
            // grabarEA
            // 
            this.grabarEA.Enabled = false;
            this.grabarEA.Location = new System.Drawing.Point(826, 222);
            this.grabarEA.Name = "grabarEA";
            this.grabarEA.Size = new System.Drawing.Size(75, 23);
            this.grabarEA.TabIndex = 51;
            this.grabarEA.Text = "GRABAR";
            this.grabarEA.UseVisualStyleBackColor = true;
            this.grabarEA.Click += new System.EventHandler(this.grabarEA_Click);
            // 
            // elementos_labelE
            // 
            this.elementos_labelE.AutoSize = true;
            this.elementos_labelE.Location = new System.Drawing.Point(226, 114);
            this.elementos_labelE.Name = "elementos_labelE";
            this.elementos_labelE.Size = new System.Drawing.Size(59, 13);
            this.elementos_labelE.TabIndex = 54;
            this.elementos_labelE.Text = "Elementos:";
            // 
            // comboElementoE
            // 
            this.comboElementoE.FormattingEnabled = true;
            this.comboElementoE.Location = new System.Drawing.Point(229, 145);
            this.comboElementoE.Name = "comboElementoE";
            this.comboElementoE.Size = new System.Drawing.Size(121, 21);
            this.comboElementoE.TabIndex = 56;
            this.comboElementoE.SelectedIndexChanged += new System.EventHandler(this.comboElementoE_SelectedIndexChanged_1);
            // 
            // comboConcepto
            // 
            this.comboConcepto.FormattingEnabled = true;
            this.comboConcepto.Location = new System.Drawing.Point(82, 145);
            this.comboConcepto.Name = "comboConcepto";
            this.comboConcepto.Size = new System.Drawing.Size(121, 21);
            this.comboConcepto.TabIndex = 479;
            this.comboConcepto.SelectedIndexChanged += new System.EventHandler(this.comboConcepto_SelectedIndexChanged);
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(826, 117);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 506;
            // 
            // comboAreas
            // 
            this.comboAreas.FormattingEnabled = true;
            this.comboAreas.Location = new System.Drawing.Point(441, 145);
            this.comboAreas.Name = "comboAreas";
            this.comboAreas.Size = new System.Drawing.Size(121, 21);
            this.comboAreas.TabIndex = 507;
            this.comboAreas.SelectedIndexChanged += new System.EventHandler(this.comboAreas_SelectedIndexChanged);
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(602, 143);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(75, 23);
            this.eliminar.TabIndex = 508;
            this.eliminar.Text = "ELIMINAR";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // area_labelA
            // 
            this.area_labelA.AutoSize = true;
            this.area_labelA.Location = new System.Drawing.Point(438, 114);
            this.area_labelA.Name = "area_labelA";
            this.area_labelA.Size = new System.Drawing.Size(35, 13);
            this.area_labelA.TabIndex = 28;
            this.area_labelA.Text = "Area: ";
            // 
            // eliminarElemento
            // 
            this.eliminarElemento.Enabled = false;
            this.eliminarElemento.Location = new System.Drawing.Point(229, 290);
            this.eliminarElemento.Name = "eliminarElemento";
            this.eliminarElemento.Size = new System.Drawing.Size(75, 23);
            this.eliminarElemento.TabIndex = 509;
            this.eliminarElemento.Text = "ELIMINAR";
            this.eliminarElemento.UseVisualStyleBackColor = true;
            this.eliminarElemento.Click += new System.EventHandler(this.eliminarElemento_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1162, 465);
            this.Controls.Add(this.eliminarElemento);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.comboAreas);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.comboConcepto);
            this.Controls.Add(this.comboElementoE);
            this.Controls.Add(this.elementos_labelE);
            this.Controls.Add(this.grabarEA);
            this.Controls.Add(this.elementoArea);
            this.Controls.Add(this.comboElementoA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboAreaA);
            this.Controls.Add(this.area_labelE);
            this.Controls.Add(this.grabarArea);
            this.Controls.Add(this.grabarElemento);
            this.Controls.Add(this.area);
            this.Controls.Add(this.area_labelA);
            this.Controls.Add(this.elemento);
            this.Controls.Add(this.elemento_labelE);
            this.Controls.Add(this.concepto_labelE);
            this.Controls.Add(this.nuevaArea);
            this.Controls.Add(this.nuevoElemento);
            this.Controls.Add(this.grabarAsiento);
            this.Controls.Add(this.abrir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Departamentos Seguimiento 2018 - Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button abrir;
        private System.Windows.Forms.Button grabarAsiento;
        private System.Windows.Forms.Button nuevoElemento;
        private System.Windows.Forms.Button nuevaArea;
        private System.Windows.Forms.TextBox elemento;
        private System.Windows.Forms.Label elemento_labelE;
        private System.Windows.Forms.Label concepto_labelE;
        private System.Windows.Forms.Button grabarElemento;
        private System.Windows.Forms.TextBox area;
        private System.Windows.Forms.Button grabarArea;
        private System.Windows.Forms.Label area_labelE;
        private System.Windows.Forms.ComboBox comboAreaA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboElementoA;
        private System.Windows.Forms.Button elementoArea;
        private System.Windows.Forms.Button grabarEA;
        private System.Windows.Forms.Label elementos_labelE;
        private System.Windows.Forms.ComboBox comboElementoE;
        private System.Windows.Forms.ComboBox comboConcepto;
        internal System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.ComboBox comboAreas;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.Label area_labelA;
        private System.Windows.Forms.Button eliminarElemento;
    }
}

