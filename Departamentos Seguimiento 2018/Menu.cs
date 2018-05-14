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
            
            comboConceptoE.DataSource = conceptos ;
            comboConceptoE.DisplayMember = "Concepto"; //columna a visualizar
            comboConceptoE.ValueMember = "Id"; //columna a recordar           
            cargaComboAreas();
            cargaComboElementos();

            estimado.Text = "0";
            descuento.Text = "0";
            real.Text = "0";
        }

        private void cargaComboAreas()
        {
            comboAreaA.DataSource = con.tabla("SELECT * FROM AREA");
            comboAreaA.DisplayMember = "Area";
            comboAreaA.ValueMember = "Id";
        }

        private void cargaComboElementos()
        {
            comboElementoA.DataSource = con.tabla("SELECT * FROM elemento");
            comboElementoA.DisplayMember = "elemento";
            comboElementoA.ValueMember = "id";
        }

        private void abrir_Click(object sender, EventArgs e)
        {
            General_Form g = new General_Form();
            g.con = con;
          /*  g.fecha = fecha.Value;     

            g.idConcepto_ingresos = idConcepto_ingresos;
            g.idConcepto_gastos = idConcepto_gastos;
            g.idConcepto_beneficio = idConcepto_beneficio;
            g.idConcepto_cobros = idConcepto_cobros;
            g.idConcepto_pagos = idConcepto_pagos;
            g.idConcepto_diferencia = idConcepto_diferencia;
*/
            g.Show();
        }


        private void grabarElemento_Click(object sender, EventArgs e)
        {
            if (elemento.Text != "" && comboConceptoE.SelectedValue.ToString() != "" && comboAreaA.SelectedValue.ToString()!="")
            {
                
                int r = con.insertarElemento(comboConceptoE.SelectedValue.ToString(), elemento.Text);
                cargaComboElementos();

                if (r == 0)
                {
                    MessageBox.Show("El elemento "+comboConceptoE.Text.ToString()+"-"+elemento.Text+" YA EXISTE.");
                }
                comboConceptoE.Enabled = false;               
                elemento.Enabled = false;
                grabarElemento.Enabled = false;
                comboArea.Enabled = false;
                comboElementoE.Enabled = false;


            } else
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            comboElementoA.Enabled = true;
            comboAreaA.Enabled = true;
            grabarEA.Enabled = true;
        }

      
        private void grabarEA_Click(object sender, EventArgs e)
        {
            comboElementoA.Enabled = false;
            comboAreaA.Enabled = false;
            int n = con.insertarElementoArea(comboElementoA.SelectedValue.ToString(),comboAreaA.SelectedValue.ToString());
            if (n > 0)
            {
                for(int i = 1; i<=12; i++)
                {
                    con.insertarAsientoS(comboElementoA.SelectedValue.ToString(), comboAreaA.SelectedValue.ToString(),new DateTime(fecha.Value.Year,i,fecha.Value.Day),"0","0","0");
                }
            }
        }

        private void comboConceptoE_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboElementoE.DataSource = null;
            comboElementoE.DataSource = con.tablaElementosIdConcepto(comboConceptoE.SelectedValue.ToString());
            comboElementoE.DisplayMember = "Elemento";
       
           
            
        }

        private void comboElementoE_SelectedIndexChanged(object sender, EventArgs e)
        {
            elemento.Text = comboElementoE.Text.ToString();
           
        }

        private void eliminarE_Click(object sender, EventArgs e)
        {
            con.actualizarElemento(comboElementoE.SelectedValue.ToString(),elemento.Text);
        }

        private void comboElemento_SelectedIndexChanged(object sender, EventArgs e)
        {      
            if (comboElemento.SelectedValue!=null)
            {
                //Combo con los elementos del concepto elegido
                DataTable dtconcepto = con.tablaConceptoIdElemento(comboElemento.SelectedValue.ToString());
                if (dtconcepto.Rows.Count != 0)
                {
                    concepto.Text = dtconcepto.Rows[0][0].ToString();
                }
            }
        }

      

      
        private void grabarArea_Click(object sender, EventArgs e)
        {
            if (area.Text != "")
            {
                con.insertarArea(area.Text);
                //Actualizamos areas
                cargaComboAreas();

                area.Enabled = false;
                grabarArea.Enabled = false;
            }
        }


        private void grabarAsiento_Click(object sender, EventArgs e)
        {
            if (concepto.Text!="")
            {               
                //insertamos asiento
                int a = con.insertarAsiento(comboElemento.SelectedValue.ToString(),comboArea.SelectedValue.ToString(), fecha.Value, estimado.Text,descuento.Text,real.Text);
               
                
                comboElemento.Enabled = false;     
                grabarAsiento.Enabled = false;
                estimado.Enabled = false;
                descuento.Enabled = false;
          
                
            }   else {
                MessageBox.Show("Debe seleccionar un elemento");
            }
                
        }

   

        private void nuevoElemento_Click(object sender, EventArgs e)
        {
            comboConceptoE.Enabled = true;          
            comboArea.Enabled = true;
            elemento.Enabled = true;
            grabarElemento.Enabled = true;
            comboElementoE.Enabled = true;
            

           
        }

        private void nuevoAsiento_Click(object sender, EventArgs e)
        {
          
            comboArea.Enabled = true;            
            comboElemento.Enabled = true;
            estimado.Enabled = true;
            descuento.Enabled = true;
            real.Enabled = true;
            grabarAsiento.Enabled = true;

        }

       

      
        private void nuevaArea_Click(object sender, EventArgs e)
        {
            area.Enabled = true;
            grabarArea.Enabled = true;
        }



      /*  private void abrir_Click(object sender, EventArgs e)
        {
            General1 g = new General1();
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
        */
    }
}
