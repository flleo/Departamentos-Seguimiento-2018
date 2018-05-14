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
    public partial class Area2 : Form
    {
        internal General1 general1;
        internal General2 general2;
        internal General3 general3;
        internal General4 general4;
        internal string generalName;  // Nombre de la clase
        public Conexion con;
        public DateTime fecha;
        public string areaId;
        public string idConcepto_ingresos, idConcepto_gastos, idConcepto_beneficio, idConcepto_cobros, idConcepto_pagos, idConcepto_diferencia;
        string concepto_ingresos, concepto_gastos, concepto_beneficio, concepto_cobros, concepto_pagos, concepto_diferencia;



        DataTable todosconceptos;
        Elemento el;
        private string elementoId;
        private string gen;

        public Area2()
        {
            InitializeComponent();

        }


       

        private void Area2_Load(object sender, EventArgs e)
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


        private void ingresos1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(ingresos1, e);
        }


        private void ingresos2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(ingresos2, e);
        }



        private void ingresos3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(ingresos3, e);
        }




        private void gastos1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(gastos1, e);
        }


        private void gastos2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(gastos2, e);
        }



        private void gastos3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(gastos3, e);
        }



        private void cobros1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(cobros1, e);
        }



        private void cobros2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(cobros2, e);
        }



        private void cobros3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(cobros3, e);
        }


        private void pagos1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(pagos1, e);
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
          /*  Area3 g = new Area3();
            g.con = con;
            g.fecha = fecha;

            g.idConcepto_ingresos = idConcepto_ingresos;
            g.idConcepto_gastos = idConcepto_gastos;
            g.idConcepto_beneficio = idConcepto_beneficio;
            g.idConcepto_cobros = idConcepto_cobros;
            g.idConcepto_pagos = idConcepto_pagos;
            g.idConcepto_diferencia = idConcepto_diferencia;

            g.Show();*/
        }

      

        private void pagos2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(pagos2, e);
        }

        private void pagos3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show(pagos3, e);
        }


        private void show(DataGridView d, DataGridViewCellEventArgs e)
        {
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            elementoId = d.Rows[numeroFila].Cells[0].Value.ToString();
            string elemento = d.Rows[numeroFila].Cells[1].Value.ToString();
            string estimado = d.Rows[numeroFila].Cells[2].Value.ToString();
            string descuento = d.Rows[numeroFila].Cells[3].Value.ToString();
            string real = d.Rows[numeroFila].Cells[4].Value.ToString();
            string idasiento = d.Rows[numeroFila].Cells[5].Value.ToString();

            el = new Elemento(idasiento, this.fecha.Year, concepto_ingresos, elementoId, elemento, areaId, estimado, descuento, real);
            el.con = con;
            el.area2 = this;
            el.nombreDelArea = areaText.Text;
            el.areaName = this.Name;

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
                    switch (generalName)
                    {
                        case "General1": general1.Close(); break;
                        case "General2": general2.Close(); break;
                        case "General3": general3.Close(); break;
                        case "General4": general4.Close(); break;
                    }
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
            totalesConceptoMesAñoArea(ingresosEstimados1, ingresosDescuento1, ingresosReal1, idConcepto_ingresos, "1");
            totalesConceptoMesAñoArea(ingresosEstimados2, ingresosDescuento2, ingresosReal2, idConcepto_ingresos, "2");
            totalesConceptoMesAñoArea(ingresosEstimados3, ingresosDescuento3, ingresosReal3, idConcepto_ingresos, "3");
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
                acumuladoIngreso.Text = acumuladoIngresosAñoArea.Rows[0][0].ToString();

            }
        }



        private void reloadAreaIngresos()
        {

            ingresos1.DataSource = con.tablaElementosConceptoMesAñoArea(con.qElementosConceptoEneroAñoArea, idConcepto_ingresos, fecha.Year.ToString(), areaId);
            ingresos2.DataSource = con.tablaElementosConceptoMesAñoArea(con.qElementosConceptoFebreroAñoArea, idConcepto_ingresos, fecha.Year.ToString(), areaId);
            ingresos3.DataSource = con.tablaElementosConceptoMesAñoArea(con.qElementosConceptoMarzoAñoArea, idConcepto_ingresos, fecha.Year.ToString(), areaId);

            dataGridVisual(ingresos1);
            dataGridVisual(ingresos2);
            dataGridVisual(ingresos3);



        }

        private void dataGridVisual(DataGridView elementosIngreso)
        {
            if (elementosIngreso.ColumnCount != 0)
            {

                if (elementosIngreso.Name.Equals("ingresos1"))
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



