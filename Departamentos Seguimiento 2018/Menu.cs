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
        General_Form gf = new General_Form();
        int i = 0;
        private int ceE;

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //Tabla conceptos
            //conceptos = con.tabla("select * from concepto where id !=3 and id!=6");
            
            //Inicializamos idconcepto     
            todosconceptos = con.tabla("SELECT * FROM concepto");
     
            idConcepto_ingresos = todosconceptos.Rows[0][0].ToString();
            idConcepto_gastos = todosconceptos.Rows[1][0].ToString();
            idConcepto_beneficio = todosconceptos.Rows[2][0].ToString();
            idConcepto_cobros = todosconceptos.Rows[3][0].ToString();
            idConcepto_pagos = todosconceptos.Rows[4][0].ToString();
            idConcepto_diferencia = todosconceptos.Rows[5][0].ToString();

            //Inicializamos combos
            
            comboConcepto.DataSource = todosconceptos ;
            comboConcepto.DisplayMember = "Concepto"; //columna a visualizar
            comboConcepto.ValueMember = "Id"; //columna a recordar    
            
            
            cargaComboAreas();
            cargaComboElementos();


           
        }


      

        private void nuevaArea_Click(object sender, EventArgs e)
        {
            area.Enabled = true;
            grabarArea.Enabled = true;
           

        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            grabarArea_();
        }


        internal void cargaComboAreas()
        {
            DataTable areas = con.tabla("SELECT * FROM AREA");

            comboAreaA.DataSource = areas;
            comboAreaA.DisplayMember = "Area";
            comboAreaA.ValueMember = "Id";

            comboAreas.DataSource = areas;
            comboAreas.DisplayMember = "Area";
            comboAreas.ValueMember = "Id";
        }

        private void cargaComboElementos()
        {
            comboElementoA.DataSource = con.tabla("SELECT * FROM elemento");
            comboElementoA.DisplayMember = "elemento";
            comboElementoA.ValueMember = "id";

            comboElementoE.DataSource = null;
        }

        private void abrir_Click(object sender, EventArgs e)
        {
            gf = new General_Form();
            gf.con = con;
            gf.menu = this;
            gf.Show();
        }


        private void grabarElemento_Click(object sender, EventArgs e)
        {
            if (elemento.Text != "" && comboConcepto.SelectedValue.ToString() != "")
            {
                if (comboConcepto.SelectedValue.ToString().Equals("3") || comboConcepto.SelectedValue.ToString().Equals("6"))
                {
                    MessageBox.Show("No se permiten crear elementos para ese concepto");
                }
                else
                {
                    int r = con.insertarElemento(comboConcepto.SelectedValue.ToString(), elemento.Text);
                    cargaComboElementos();

                    if (r == 0)
                    {
                        MessageBox.Show("El elemento " + comboConcepto.Text.ToString() + "-" + elemento.Text + " YA EXISTE.");
                    }
                }
            } else
            {
                MessageBox.Show("Debes escribir un elemento");
            }
        }

       

    
      
        private void grabarEA_Click(object sender, EventArgs e)
        {         
            int r = 0;
            try
            {
               // MessageBox.Show(comboElementoA.SelectedValue.ToString(), comboAreaA.SelectedValue.ToString());
                int n = con.insertarElementoArea(comboElementoA.SelectedValue.ToString(), comboAreaA.SelectedValue.ToString());
                int año = fecha.Value.Year;
                int dia = fecha.Value.Day;
                
                for (int i = 1; i <= 12; i++)
                {                    
                    r = 0;
                    //MessageBox.Show(año+"@"+i+"@"+1);
                    DateTime fecha1 = new DateTime(año,i,1);
                    r = con.insertarAsiento(comboElementoA.SelectedValue.ToString(), comboAreaA.SelectedValue.ToString(),fecha1, "0", "0", "0");
                    
                }
                if (r == 1)
                {
                    MessageBox.Show("Se han añadido los asientos correspondientes para el area \"" + comboAreaA.Text.ToString() + "\", elemento \"" + comboElementoA.Text.ToString() +
                        "\", y el año " + fecha.Value.Year + " con EXITO");
                }
                else
                {
                    MessageBox.Show("Ya existen elementos para esa área, y ese año");
                }
            }
            catch { MessageBox.Show("Deben de existir campos para poder relacionarlos"); }
     
        }

     

        private void eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                eliminarArea(comboAreas.SelectedValue.ToString());
                cargaComboAreas();
            } catch
            {
                MessageBox.Show("No hay areas que eliminar");
            }
        }

        internal void eliminarArea(string idarea)
        {
            if (!idarea.Equals(""))
            {
                if (MessageBox.Show("¿Desea eliminar el area \"" + comboAreas.Text + "\", con todos sus elementos?", "Departamentos Seguimiento 2018 - Eliminar Area",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                   // MessageBox.Show(idarea);
                    int r = con.eliminarAreaIdArea(idarea);
                    if (r > 0)
                    {
                        MessageBox.Show("Area eliminada");
                        cargaComboAreas();
                        gf.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Debes seleccionar un área");
            }
        }
    


        private void comboAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            eliminar.Enabled = true;
            this.AcceptButton = eliminar;
        }

        private void nuevaArea_Click_1(object sender, EventArgs e)
        {
            area.Enabled = true;
            grabarArea.Enabled = true;

           
        }

        private void elementoArea_Click(object sender, EventArgs e)
        {
            comboElementoA.Enabled = true;
            comboAreaA.Enabled = true;
            grabarEA.Enabled = true;

            this.AcceptButton = grabarEA;
        }

        private void elemento_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = grabarEA;
        }

        private void area_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = grabarArea;
        }

        private void eliminarElemento_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Desea eliminar el elemento \"" + comboElementoE.Text + "\"?", "Departamentos Seguimiento 2018 - Eliminar Elemento",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string idEle = comboElementoE.SelectedValue.ToString();
                con.eliminarAsientoIdElemento(idEle);
                con.eliminarElementoAreaIdEle(idEle);
                int r = con.eliminarElemento(idEle);
                if (r > 0)
                {
                    cargaComboElementos();
                }
            }
        }

       
       

        private void comboElementoE_SelectedIndexChanged_1(object sender, EventArgs e)
        {           
                if (ceE > 1)
                    eliminarElemento.Enabled = true;
                ceE++;           
        }

        private void comboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboConcepto.SelectedValue.ToString().Equals("System.Data.DataRowView"))
            {
               // MessageBox.Show(comboConcepto.SelectedValue.ToString());
                comboElementoE.DataSource = null;
                comboElementoE.DataSource = con.tablaElementosIdConcepto(comboConcepto.SelectedValue.ToString());
                comboElementoE.DisplayMember = "Elemento";
                comboElementoE.ValueMember = "Id";
            }

        }

       

       

        private void comboElementoE_SelectedIndexChanged(object sender, EventArgs e)
        {
            elemento.Text = comboElementoE.Text.ToString();
           
        }

        private void eliminarE_Click(object sender, EventArgs e)
        {
            con.actualizarElemento(comboElementoE.SelectedValue.ToString(),elemento.Text);
        }

       

      

      
        private void grabarArea_Click(object sender, EventArgs e)
        {
            grabarArea_();
           
        }

        private void grabarArea_()
        {
            if (area.Text != "")
            {
                con.insertarArea(area.Text);
                //Actualizamos areas
                cargaComboAreas();

            }
            else
            {
                MessageBox.Show("Debes rellenar el campo \"Area\"");
            }
        }

        private void nuevoElemento_Click(object sender, EventArgs e)
        {
            comboConcepto.Enabled = true;          
            elemento.Enabled = true;
            grabarElemento.Enabled = true;
            comboElementoE.Enabled = true;

            this.AcceptButton = grabarElemento;
        }


        }
}
