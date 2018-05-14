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
    public partial class General_Form : Form
    {
        internal Conexion con;
        private string idarea="";
        string idconcepto = "";

        public General_Form()
        {
            InitializeComponent();
        }

        private void General_Form_Load(object sender, EventArgs e)
        {
        
            // Combo Concepto
            comboConcepto.DataSource = con.tabla("SELECT * FROM CONCEPTO");
            comboConcepto.DisplayMember = "Concepto";
            comboConcepto.ValueMember = "Id";
            idconcepto = comboConcepto.SelectedValue.ToString();
            //Bindeos
            actualizaMes();
           
            label_año.Text = fecha.Value.Year.ToString();

        }

      

        private void comboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            idconcepto = comboConcepto.SelectedValue.ToString();
            conceptoE.Text = concepto.Text = comboConcepto.Text.ToString();
            areas();
            elementosArea();
            
            


        }

        private void fecha_ValueChanged(object sender, EventArgs e)
        {
            
            label_año.Text = fecha.Value.Year.ToString();
            actualizaMes();
            

        }

        private void actualizaMes()
        {
            switch (fecha.Value.Month.ToString())
            {
                case "1": mesE.Text = mes.Text = "ENERO"; break;
                case "2": mesE.Text = mes.Text = "FEBRERO"; break;
                case "3": mesE.Text = mes.Text = "MARZO"; break;
                case "4": mesE.Text = mes.Text = "ABRIL"; break;
                case "5": mesE.Text = mes.Text = "MAYO"; break;
                case "6": mesE.Text = mes.Text = "JUNIO"; break;
                case "7": mesE.Text = mes.Text = "JULIO"; break;
                case "8": mesE.Text = mes.Text = "AGOSTO"; break;
                case "9": mesE.Text = mes.Text = "SEPTIEMBRE"; break;
                case "10": mesE.Text = mes.Text = "OCTUBRE"; break;
                case "11": mesE.Text = mes.Text = "NOVIEMBRE"; break;
                case "12": mesE.Text = mes.Text = "DICIEMBRE"; break;
                
            }

            areas();
            elementosArea();
        }

       

        internal void areas()
        {
            data.DataSource = null;
            data.DataSource = con.tablaAreasConceptoMesAño_(idconcepto, fecha.Value.Month, fecha.Value.Year);
            if (data.Rows.Count > 0)
            {
                data.Columns[0].Visible = false;

                acumulado.Text = con.tablaAcumuladoAño_(idconcepto, fecha.Value.Year).Rows[0][0].ToString();
                DataTable totales = con.tablaTotalesConceptoMesAño_(idconcepto, fecha.Value.Month, fecha.Value.Year);
                estimado.Text = totales.Rows[0][0].ToString();
                descuento.Text = totales.Rows[0][1].ToString();
                real.Text = totales.Rows[0][2].ToString();

                if (data.Rows.Count == 1)
                {
                    if(!idconcepto.Equals("1"))
                        MessageBox.Show("No existen elementos para "+concepto.Text);
                    MessageBox.Show("Debes asociar un Elemento a un Area");
                    this.Close();
                }
            }
        }

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());       
            areaText.Text = data.Rows[numeroFila].Cells[1].Value.ToString();
            idarea = data.Rows[numeroFila].Cells[0].Value.ToString();
            elementosArea();
            
           
        }

        internal void elementosArea()
        {
            if (!idarea.Equals(""))
            {
                elementos.DataSource = null;
                elementos.DataSource = con.tablaElementosConceptoMesAñoArea_(idconcepto, fecha.Value.Month.ToString(), fecha.Value.Year.ToString(), idarea);
                if (elementos.Rows.Count > 0)
                {
                    elementos.Columns[0].Visible = false;

                    acumuladoE.Text = con.tablaAcumuladoAñoArea(idconcepto, fecha.Value.Year.ToString(), idarea).Rows[0][0].ToString();
                    DataTable totales = con.tablaTotalesConceptoMesAñoArea(idconcepto, fecha.Value.Month.ToString(), fecha.Value.Year.ToString(), idarea);
                    estimadoE.Text = totales.Rows[0][0].ToString();
                    descuentoE.Text = totales.Rows[0][1].ToString();
                    realE.Text = totales.Rows[0][2].ToString();
                }
            }
        }

        private void elementos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            string elementoId = elementos.Rows[numeroFila].Cells[0].Value.ToString();
            string elemento = elementos.Rows[numeroFila].Cells[1].Value.ToString();
            string estimado = elementos.Rows[numeroFila].Cells[2].Value.ToString();
            string descuento = elementos.Rows[numeroFila].Cells[3].Value.ToString();
            string real = elementos.Rows[numeroFila].Cells[4].Value.ToString();
            string idasiento = elementos.Rows[numeroFila].Cells[5].Value.ToString();

            Elemento el = new Elemento(idasiento, fecha.Value.Year, idconcepto, elementoId, elemento,idarea, estimado, descuento, real);
            el.con = con;
            el.gf = this;
            el.Show();
        }
    }
}
