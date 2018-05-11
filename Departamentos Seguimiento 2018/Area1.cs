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
    public partial class Area : Form
    {
        internal General1 genIng1;
        internal General2 genIng2;
        //   internal GeneralIngresos3 genIng3;
        //   internal GeneralIngresos4 genIng4;
        public Conexion con;
        public DateTime fecha;
        public string areaId;
        public string idConcepto_ingresos, idConcepto_gastos, idConcepto_beneficio, idConcepto_cobros, idConcepto_pagos, idConcepto_diferencia;
        string concepto_ingresos, concepto_gastos, concepto_beneficio, concepto_cobros, concepto_pagos, concepto_diferencia;



        DataTable todosconceptos;
        DataTable tablaElementosIngresos;
        Elemento el;
        private string elementoId;
        private string gen;

        public Area()
        {
            InitializeComponent();
            //  this.gen = gen;

        }



        private void area_Load(object sender, EventArgs e)
        {

            todosconceptos = con.dataSet.Tables["dtTodosConceptos"];

            concepto_ingresos = todosconceptos.Rows[0][1].ToString();
            concepto_gastos = todosconceptos.Rows[1][1].ToString();
            concepto_beneficio = todosconceptos.Rows[2][1].ToString();
            concepto_cobros = todosconceptos.Rows[3][1].ToString();
            concepto_pagos = todosconceptos.Rows[4][1].ToString();
            concepto_diferencia = todosconceptos.Rows[5][1].ToString();



            reloadArea();

        }



        private void elementosIngresoEnero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showElemento(elementosIngresoEnero, e);
        }

        private void elementosIngresoFebrero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showElemento(elementosIngresoFebrero, e);
        }

        private void elementosIngresoMarzo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showElemento(elementosIngresoMarzo, e);
        }


        private void showElemento(DataGridView d, DataGridViewCellEventArgs e)
        {
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            elementoId = d.Rows[numeroFila].Cells[0].Value.ToString();
            string elemento = d.Rows[numeroFila].Cells[1].Value.ToString();
            string estimado = d.Rows[numeroFila].Cells[2].Value.ToString();
            string descuento = d.Rows[numeroFila].Cells[3].Value.ToString();
            string real = d.Rows[numeroFila].Cells[4].Value.ToString();
            string idasiento = d.Rows[numeroFila].Cells[5].Value.ToString();

            el = new Elemento(this, idasiento, this.fecha.Year, concepto_ingresos, elementoId, elemento, areaId, estimado, descuento, real);
            el.con = con;
            el.nombreDelArea = areaTop.Text;

            el.Show();
        }


        private void eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el area, con todos sus elementos?", "Departamentos Seguimiento 2018 - Eliminar Area",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int r = con.eliminarArea(areaId, elementoId);

                if (r != 0)
                {

                    genIng1.Close();
                    genIng2.Close();
                    this.Close();

                }
            }
        }

        internal void reloadArea()
        {
            acumuladoIngresos();
            totales();
            reloadAreaIngresos();


        }

        private void totales()
        {
            totalesConceptoMesAñoArea(ingresosEstimadosEnero, ingresosDescuentoEnero, ingresosRealEnero, idConcepto_ingresos, "1");
            totalesConceptoMesAñoArea(ingresosEstimadosFebrero, ingresosDescuentoFebrero, ingresosRealFebrero, idConcepto_ingresos, "2");
            totalesConceptoMesAñoArea(ingresosEstimadosMarzo, ingresosDescuentosMarzo, ingresosRealesMarzo, idConcepto_ingresos, "3");
        }

        private void totalesConceptoMesAñoArea(TextBox ingresosEstimados, TextBox ingresosDescuento, TextBox ingresosReal, string idConcepto, string mes)
        {
            DataTable totalesIngresosEneroAñoArea = con.tablaTotalesConceptoMesAñoArea(idConcepto, mes, fecha.Year.ToString(), areaId);
            if (totalesIngresosEneroAñoArea.Rows.Count != 0)
            {
                ingresosEstimados.Text = totalesIngresosEneroAñoArea.Rows[0][0].ToString();
                ingresosDescuento.Text = totalesIngresosEneroAñoArea.Rows[0][1].ToString();
                ingresosReal.Text = totalesIngresosEneroAñoArea.Rows[0][2].ToString();
            }

        }

        private void acumuladoIngresos()
        {

            //Tabla acumulado ingresos por año area
            DataTable acumuladoIngresosAñoArea = con.tablaAcumuladoAñoArea(idConcepto_ingresos, fecha.Year.ToString(), areaId);
            if (acumuladoIngresosAñoArea.Rows.Count != 0)
            {
                acumulado_ingresos.Text = acumuladoIngresosAñoArea.Rows[0][0].ToString();

            }
        }



        private void reloadAreaIngresos()
        {

            elementosIngresoEnero.DataSource = con.tablaElementosConceptoMesAñoArea(con.qElementosConceptoEneroAñoArea, idConcepto_ingresos, fecha.Year.ToString(), areaId);
            elementosIngresoFebrero.DataSource = con.tablaElementosConceptoMesAñoArea(con.qElementosConceptoFebreroAñoArea, idConcepto_ingresos, fecha.Year.ToString(), areaId);
            elementosIngresoMarzo.DataSource = con.tablaElementosConceptoMesAñoArea(con.qElementosConceptoMarzoAñoArea, idConcepto_ingresos, fecha.Year.ToString(), areaId);

            dataGridVisual(elementosIngresoEnero);
            dataGridVisual(elementosIngresoFebrero);
            dataGridVisual(elementosIngresoMarzo);
            


        }

        private void dataGridVisual(DataGridView elementosIngreso)
        {
            if (elementosIngreso.ColumnCount != 0)
            {

                if (elementosIngreso.Name.Equals("elementosIngresoEnero") || elementosIngreso.Name.Equals("elementosIngresoAbril"))
                {
                    elementosIngreso.Columns[0].Visible = false;
                    elementosIngreso.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    elementosIngreso.Columns[0].Visible = false;
                    elementosIngreso.Columns[1].Visible = false;
                }
            }



        }
    }


}

       

