﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Departamentos_Seguimiento_2018
{
    public partial class Menu : Form
    {
        public Conexion con = new Conexion();
        Area are = new Area();
        public DataTable conceptos, todosconceptos,dtarea;
        string idConcepto_ingresos,idConcepto_gastos,idConcepto_beneficio,idConcepto_cobros,idConcepto_pagos,idConcepto_diferencia;
        int i = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {           
            //Tabla conceptos
            con.tablaDataSet("select * from concepto where id !=3 and id!=6", "dtConceptos");
            conceptos = con.dataSet.Tables["dtConceptos"];
            //Inicializamos idconcepto
            con.tablaDataSet("select * from concepto", "dtTodosConceptos");
            todosconceptos = con.dataSet.Tables["dtTodosConceptos"];

            idConcepto_ingresos = todosconceptos.Rows[0][0].ToString();
            idConcepto_gastos = todosconceptos.Rows[1][0].ToString();
            idConcepto_beneficio = todosconceptos.Rows[2][0].ToString();
            idConcepto_cobros = todosconceptos.Rows[3][0].ToString();
            idConcepto_pagos = todosconceptos.Rows[4][0].ToString();
            idConcepto_diferencia = todosconceptos.Rows[5][0].ToString();



           

            //Inicializamos combos
            comboConcepto.DataSource = conceptos;
            comboConcepto.DisplayMember = "Concepto"; //columna a visualizar
            comboConcepto.ValueMember = "Id"; //columna a recordar  
            comboConceptoE.DataSource = conceptos;
            comboConceptoE.DisplayMember = "Concepto"; //columna a visualizar
            comboConceptoE.ValueMember = "Id"; //columna a recordar 
            //TablaArea
            con.tablaDataSet("SELECT * FROM AREA", "dtArea");
            dtarea = con.dataSet.Tables["dtArea"];
        }

        ToolTip buttonToolTip = new ToolTip();

        private void ComboConcepto__MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("hola");
            buttonToolTip.ToolTipTitle = "Seleccione un concepto";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 0;

            buttonToolTip.SetToolTip(comboConcepto, comboConcepto.Text);
        }

        private void abrir_Click(object sender, EventArgs e)
        {

            General g = new General();
            g.con = con;
            g.fecha = fecha.Value;
         

            g.idConcepto_ingresos = idConcepto_ingresos;
            g.idConcepto_gastos = idConcepto_gastos;
            g.idConcepto_beneficio = idConcepto_beneficio;
            g.idConcepto_cobros = idConcepto_cobros;
            g.idConcepto_pagos = idConcepto_pagos;
            g.idConcepto_diferencia = idConcepto_diferencia;


            g.Show();
        }


        private void grabarElemento_Click(object sender, EventArgs e)
        {
            if (elemento.Text != "" && comboConceptoE.SelectedValue.ToString() != "")
            {
                MessageBox.Show(comboConceptoE.SelectedValue.ToString());
                con.insertarElemento(comboConceptoE.SelectedValue.ToString(), elemento.Text);

                concepto_labelE.Visible = false;
                comboConceptoE.Visible = false;
                elemento_labelE.Visible = false;
                elemento.Visible = false;
                grabarElemento.Visible = false;
            }
        }

        private void grabarArea_Click(object sender, EventArgs e)
        {
            if (area.Text != "")
            {
                con.insertarArea(area.Text);
                //Actualizamos areas
                dtarea = con.tabla("SELECT * FROM AREA");

                area_labelA.Visible = false;
                area.Visible = false;
                grabarArea.Visible = false;
            }
        }


        private void grabarAsiento_Click(object sender, EventArgs e)
        {
            if (comboArea.SelectedIndex.ToString()!="" && comboElemento.SelectedIndex.ToString()!="" && comboConcepto.SelectedIndex.ToString()!="")
            {
              
                //insertamos asiento
                int a = con.insertarAsiento(comboElemento.SelectedValue.ToString(), comboArea.SelectedValue.ToString(), fecha.Value, estimado.Text,descuento.Text,real.Text);

                concepto_label.Visible = false;
                comboConcepto.Visible = false;
                elemento_label.Visible = false;
                comboElemento.Visible = false;
                area_label.Visible = false;
                comboArea.Visible = false;
                grabarAsiento.Visible = false;
                estimado_label.Visible = false;
                estimado.Visible = false;
                descuento_label.Visible = false;
                descuento.Visible = false;
                real_label.Visible = false;
                real.Visible = false;
                
            }


           
        }

   

        private void nuevoElemento_Click(object sender, EventArgs e)
        {
            concepto_labelE.Visible = true;
            comboConceptoE.Visible = true;
            elemento_labelE.Visible = true;
            elemento.Visible = true;
            grabarElemento.Visible = true;
        }

        private void nuevoAsiento_Click(object sender, EventArgs e)
        {      
            comboArea.DataSource = dtarea;
            comboArea.DisplayMember = "Area";
            comboArea.ValueMember = "Id";
  
            concepto_label.Visible = true;
            comboConcepto.Visible = true;

            estimado.Text = "0";
            descuento.Text = "0";
            real.Text = "0";

            
        }

        private void comboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            i++;
            if (i > 1)
            {
                //Combo con los elementos del concepto elegido
                DataTable dtelemento = con.tablaId(con.qElementosIdConcepto, comboConcepto.SelectedValue.ToString());
               
                comboElemento.DataSource = dtelemento;
                comboElemento.DisplayMember = "Elemento";
                comboElemento.ValueMember = "Id";

                elemento_label.Visible = true;
                comboElemento.Visible = true;
                area_label.Visible = true;
                comboArea.Visible = true;
                grabarAsiento.Visible = true;
                estimado_label.Visible = true;
                estimado.Visible = true;
                descuento_label.Visible = true;
                descuento.Visible = true;
                real_label.Visible = true;
                real.Visible = true;

            }
        }

        private void nuevaArea_Click(object sender, EventArgs e)
        {
            area_labelA.Visible = true;
            area.Visible = true;
            grabarArea.Visible = true;
        }

       
       
     
        
    }
}