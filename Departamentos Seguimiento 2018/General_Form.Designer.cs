﻿namespace Departamentos_Seguimiento_2018
{
    partial class General_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(General_Form));
            this.data = new System.Windows.Forms.DataGridView();
            this.real = new System.Windows.Forms.TextBox();
            this.descuento = new System.Windows.Forms.TextBox();
            this.estimado = new System.Windows.Forms.TextBox();
            this.mes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.concepto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.acumulado = new System.Windows.Forms.TextBox();
            this.label_año = new System.Windows.Forms.Label();
            this.comboConcepto = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.eliminar = new System.Windows.Forms.Button();
            this.areaText = new System.Windows.Forms.TextBox();
            this.acumuladoE = new System.Windows.Forms.TextBox();
            this.realE = new System.Windows.Forms.TextBox();
            this.descuentoE = new System.Windows.Forms.TextBox();
            this.estimadoE = new System.Windows.Forms.TextBox();
            this.mesE = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.conceptoE = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.areasButton = new System.Windows.Forms.Button();
            this.elementos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementos)).BeginInit();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.AllowUserToResizeColumns = false;
            this.data.AllowUserToResizeRows = false;
            this.data.BackgroundColor = System.Drawing.Color.Silver;
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.ColumnHeadersVisible = false;
            this.data.Location = new System.Drawing.Point(201, 293);
            this.data.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.data.Name = "data";
            this.data.RowHeadersVisible = false;
            this.data.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.data.Size = new System.Drawing.Size(400, 249);
            this.data.TabIndex = 477;
            this.data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_CellContentClick);
            // 
            // real
            // 
            this.real.Location = new System.Drawing.Point(501, 273);
            this.real.Name = "real";
            this.real.ReadOnly = true;
            this.real.Size = new System.Drawing.Size(100, 20);
            this.real.TabIndex = 476;
            // 
            // descuento
            // 
            this.descuento.Location = new System.Drawing.Point(402, 273);
            this.descuento.Name = "descuento";
            this.descuento.ReadOnly = true;
            this.descuento.Size = new System.Drawing.Size(100, 20);
            this.descuento.TabIndex = 475;
            // 
            // estimado
            // 
            this.estimado.Location = new System.Drawing.Point(303, 273);
            this.estimado.Name = "estimado";
            this.estimado.ReadOnly = true;
            this.estimado.Size = new System.Drawing.Size(100, 20);
            this.estimado.TabIndex = 474;
            // 
            // mes
            // 
            this.mes.AutoSize = true;
            this.mes.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.mes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mes.Location = new System.Drawing.Point(303, 244);
            this.mes.MinimumSize = new System.Drawing.Size(298, 0);
            this.mes.Name = "mes";
            this.mes.Size = new System.Drawing.Size(298, 13);
            this.mes.TabIndex = 473;
            this.mes.Text = "ENERO";
            this.mes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(501, 257);
            this.label5.MinimumSize = new System.Drawing.Size(100, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 472;
            this.label5.Text = "REAL";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 257);
            this.label4.MinimumSize = new System.Drawing.Size(100, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 471;
            this.label4.Text = "DESCUENTO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 257);
            this.label3.MinimumSize = new System.Drawing.Size(100, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 470;
            this.label3.Text = "ESTIMADO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // concepto
            // 
            this.concepto.AutoSize = true;
            this.concepto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.concepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.concepto.Location = new System.Drawing.Point(201, 277);
            this.concepto.MinimumSize = new System.Drawing.Size(100, 0);
            this.concepto.Name = "concepto";
            this.concepto.Size = new System.Drawing.Size(100, 13);
            this.concepto.TabIndex = 469;
            this.concepto.Text = "CONCEPTO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 468;
            this.label1.Text = "ACUMULADO ANUAL";
            // 
            // acumulado
            // 
            this.acumulado.Location = new System.Drawing.Point(69, 274);
            this.acumulado.Name = "acumulado";
            this.acumulado.ReadOnly = true;
            this.acumulado.Size = new System.Drawing.Size(126, 20);
            this.acumulado.TabIndex = 467;
            // 
            // label_año
            // 
            this.label_año.AutoSize = true;
            this.label_año.Location = new System.Drawing.Point(66, 223);
            this.label_año.Name = "label_año";
            this.label_año.Size = new System.Drawing.Size(26, 13);
            this.label_año.TabIndex = 466;
            this.label_año.Text = "Año";
            // 
            // comboConcepto
            // 
            this.comboConcepto.FormattingEnabled = true;
            this.comboConcepto.Location = new System.Drawing.Point(532, 70);
            this.comboConcepto.Name = "comboConcepto";
            this.comboConcepto.Size = new System.Drawing.Size(121, 21);
            this.comboConcepto.TabIndex = 478;
           // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(690, 206);
            this.label20.MinimumSize = new System.Drawing.Size(100, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 13);
            this.label20.TabIndex = 500;
            this.label20.Text = "AREA";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Location = new System.Drawing.Point(705, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 504;
            this.button1.Text = "EXCEL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(95, 71);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 505;
            // 
            // eliminar
            // 
            this.eliminar.BackColor = System.Drawing.Color.DarkSalmon;
            this.eliminar.Location = new System.Drawing.Point(418, 194);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(75, 23);
            this.eliminar.TabIndex = 508;
            this.eliminar.Text = "ELIMINAR";
            this.eliminar.UseVisualStyleBackColor = false;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // areaText
            // 
            this.areaText.Location = new System.Drawing.Point(787, 203);
            this.areaText.Name = "areaText";
            this.areaText.Size = new System.Drawing.Size(100, 20);
            this.areaText.TabIndex = 509;
            // 
            // acumuladoE
            // 
            this.acumuladoE.Location = new System.Drawing.Point(693, 273);
            this.acumuladoE.Name = "acumuladoE";
            this.acumuladoE.ReadOnly = true;
            this.acumuladoE.Size = new System.Drawing.Size(100, 20);
            this.acumuladoE.TabIndex = 522;
            // 
            // realE
            // 
            this.realE.Location = new System.Drawing.Point(1099, 273);
            this.realE.Name = "realE";
            this.realE.ReadOnly = true;
            this.realE.Size = new System.Drawing.Size(100, 20);
            this.realE.TabIndex = 518;
            // 
            // descuentoE
            // 
            this.descuentoE.Location = new System.Drawing.Point(1000, 273);
            this.descuentoE.Name = "descuentoE";
            this.descuentoE.ReadOnly = true;
            this.descuentoE.Size = new System.Drawing.Size(100, 20);
            this.descuentoE.TabIndex = 517;
            // 
            // estimadoE
            // 
            this.estimadoE.Location = new System.Drawing.Point(901, 273);
            this.estimadoE.Name = "estimadoE";
            this.estimadoE.ReadOnly = true;
            this.estimadoE.Size = new System.Drawing.Size(100, 20);
            this.estimadoE.TabIndex = 516;
            // 
            // mesE
            // 
            this.mesE.AutoSize = true;
            this.mesE.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.mesE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mesE.Location = new System.Drawing.Point(901, 244);
            this.mesE.MinimumSize = new System.Drawing.Size(298, 0);
            this.mesE.Name = "mesE";
            this.mesE.Size = new System.Drawing.Size(298, 13);
            this.mesE.TabIndex = 515;
            this.mesE.Text = "ENERO";
            this.mesE.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1099, 257);
            this.label7.MinimumSize = new System.Drawing.Size(100, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 514;
            this.label7.Text = "REAL";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1000, 257);
            this.label8.MinimumSize = new System.Drawing.Size(100, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 513;
            this.label8.Text = "DESCUENTO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(901, 257);
            this.label9.MinimumSize = new System.Drawing.Size(100, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 512;
            this.label9.Text = "ESTIMADO";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // conceptoE
            // 
            this.conceptoE.AutoSize = true;
            this.conceptoE.BackColor = System.Drawing.SystemColors.ControlDark;
            this.conceptoE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conceptoE.Location = new System.Drawing.Point(799, 276);
            this.conceptoE.MinimumSize = new System.Drawing.Size(100, 0);
            this.conceptoE.Name = "conceptoE";
            this.conceptoE.Size = new System.Drawing.Size(100, 13);
            this.conceptoE.TabIndex = 511;
            this.conceptoE.Text = "CONCEPTO";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(693, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 510;
            this.label11.Text = "ACUMULADO";
            // 
            // areasButton
            // 
            this.areasButton.Location = new System.Drawing.Point(298, 193);
            this.areasButton.Name = "areasButton";
            this.areasButton.Size = new System.Drawing.Size(75, 23);
            this.areasButton.TabIndex = 523;
            this.areasButton.Text = "AREAS";
            this.areasButton.UseVisualStyleBackColor = true;
            this.areasButton.Click += new System.EventHandler(this.areasButton_Click);
            // 
            // elementos
            // 
            this.elementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elementos.Location = new System.Drawing.Point(799, 293);
            this.elementos.Name = "elementos";
            this.elementos.Size = new System.Drawing.Size(400, 249);
            this.elementos.TabIndex = 524;
            this.elementos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.elementos_CellContentClick_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(963, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 17);
            this.label2.TabIndex = 525;
            this.label2.Text = "ELEMENTOS POR AREA";
            // 
            // General_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 703);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.elementos);
            this.Controls.Add(this.areasButton);
            this.Controls.Add(this.acumuladoE);
            this.Controls.Add(this.realE);
            this.Controls.Add(this.descuentoE);
            this.Controls.Add(this.estimadoE);
            this.Controls.Add(this.mesE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.conceptoE);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.areaText);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comboConcepto);
            this.Controls.Add(this.data);
            this.Controls.Add(this.real);
            this.Controls.Add(this.descuento);
            this.Controls.Add(this.estimado);
            this.Controls.Add(this.mes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.concepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.acumulado);
            this.Controls.Add(this.label_año);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "General_Form";
            this.Text = "Departamentos Seguimiento 2018 - General_Area";
            this.Load += new System.EventHandler(this.General_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elementos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView data;
        public System.Windows.Forms.TextBox real;
        public System.Windows.Forms.TextBox descuento;
        public System.Windows.Forms.TextBox estimado;
        private System.Windows.Forms.Label mes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label concepto;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox acumulado;
        public System.Windows.Forms.Label label_año;
        private System.Windows.Forms.ComboBox comboConcepto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.TextBox areaText;
        public System.Windows.Forms.TextBox acumuladoE;
        public System.Windows.Forms.TextBox realE;
        public System.Windows.Forms.TextBox descuentoE;
        public System.Windows.Forms.TextBox estimadoE;
        private System.Windows.Forms.Label mesE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label conceptoE;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Button areasButton;
        private System.Windows.Forms.DataGridView elementos;
        private System.Windows.Forms.Label label2;
    }
}