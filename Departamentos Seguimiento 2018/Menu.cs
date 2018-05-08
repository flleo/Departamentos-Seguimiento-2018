using System;
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
        public DataTable  conceptos,todosconceptos;
        string idConcepto_ingresos,idConcepto_gastos,idConcepto_beneficio,idConcepto_cobros,idConcepto_pagos,idConcepto_diferencia;
        int i = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //Tabla conceptos
            conceptos = con.tabla("select * from concepto where id !=3 and id!=6");

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
            comboConceptoE.DataSource = conceptos ;
            comboConceptoE.DisplayMember = "Concepto"; //columna a visualizar
            comboConceptoE.ValueMember = "Id"; //columna a recordar           
            cargaComboAreas();
        }

        private void cargaComboAreas()
        {         
            con.tablaDataSet("SELECT * FROM AREA", "dtAreas");
            comboArea.DataSource = con.dataSet.Tables["dtAreas"];
            comboArea.DisplayMember = "Area";
            comboArea.ValueMember = "Id";
            comboAreaE.DataSource = con.dataSet.Tables["dtAreas"];
            comboAreaE.DisplayMember = "Area";
            comboAreaE.ValueMember = "Id";

            
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
            if (elemento.Text != "" && comboConceptoE.SelectedValue.ToString() != "" && comboAreaE.SelectedValue.ToString() != "")
            {              
                con.insertarElemento(comboConceptoE.SelectedValue.ToString(), comboAreaE.SelectedValue.ToString(), elemento.Text);

                concepto_labelE.Visible = false;
                comboConceptoE.Visible = false;
                area_labelE.Visible = false;
                comboAreaE.Visible = false;
                elemento_labelE.Visible = false;
                elemento.Visible = false;
                grabarElemento.Visible = false;

            } else
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
        }

        private void comboConcepto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            i++;
            if (i > 1)
            {
                //Combo con los elementos del concepto elegido
                DataTable dtelemento = con.tablaId(con.qElementosIdConcepto, comboConcepto.SelectedValue.ToString(), comboArea.SelectedValue.ToString());

                comboElemento.DataSource = dtelemento;
                comboElemento.DisplayMember = "Elemento";
                comboElemento.ValueMember = "Id";

                elemento_label.Visible = true;
                comboElemento.Visible = true;
                grabarAsiento.Visible = true;
                estimado_label.Visible = true;
                estimado.Visible = true;
                descuento_label.Visible = true;
                descuento.Visible = true;
                real_label.Visible = true;
                real.Visible = true;

            }
        }

      
        private void grabarArea_Click(object sender, EventArgs e)
        {
            if (area.Text != "")
            {
                con.insertarArea(area.Text);
                //Actualizamos areas
                cargaComboAreas();

                area_labelA.Visible = false;
                area.Visible = false;
                grabarArea.Visible = false;
            }
        }


        private void grabarAsiento_Click(object sender, EventArgs e)
        {
            if (comboElemento.SelectedIndex.ToString()!="")
            {            
                //insertamos asiento
                int a = con.insertarAsiento(comboElemento.SelectedValue.ToString(), fecha.Value, estimado.Text,descuento.Text,real.Text);
               
                elemento_label.Visible = false;
                comboElemento.Visible = false;     
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
            area_labelE.Visible = true;
            comboAreaE.Visible = true;
            elemento_labelE.Visible = true;
            elemento.Visible = true;
            grabarElemento.Visible = true;

            if (comboAreaE.Items.Count == 0)
            {
                MessageBox.Show("No existen áreas");
            }
           
        }

        private void nuevoAsiento_Click(object sender, EventArgs e)
        {
            area_label.Visible = true;
            comboArea.Visible = true;
            concepto_label.Visible = true;
            comboConcepto.Visible = true;
            elemento_label.Visible = true;
            comboElemento.Visible = true;
            estimado.Text = "0";
            descuento.Text = "0";
            real.Text = "0";

        }

       

      
        private void nuevaArea_Click(object sender, EventArgs e)
        {
            area_labelA.Visible = true;
            area.Visible = true;
            grabarArea.Visible = true;
        }

       
       
     
        
    }
}
