using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace Departamentos_Seguimiento_2018
{
    public partial class General2 : Form
    {
        public Conexion con;
        public string idConcepto_ingresos, idConcepto_gastos, idConcepto_beneficio, idConcepto_cobros, idConcepto_pagos, idConcepto_diferencia;
        public DateTime fecha;



        public General2()
        {
            InitializeComponent();
        }


        private void General2_Load(object sender, EventArgs e)
        {
            label_año.Text = fecha.Year.ToString();

            acumuladoIngresosG();
            ingresosTotalesMes("1", ingresosEstimados1, ingresosDescuento1, ingresosReal1);
            ingresosTotalesMes("2", ingresosEstimados2, ingresosDescuento2, ingresosReal2);
            ingresosTotalesMes("3", ingresosEstimados3, ingresosDescuento3, ingresosReal3);
            areasIdConceptoMes(idConcepto_ingresos, "1", ingresos1);
            areasIdConceptoMes(idConcepto_ingresos, "2", ingresos2);
            areasIdConceptoMes(idConcepto_ingresos, "3", ingresos3);

        }

      

        private void ingresos1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Area2 area = new Area2();
            area.con = con;
            area.general2 = this;

            area.idConcepto_ingresos = idConcepto_ingresos;
            area.idConcepto_gastos = idConcepto_gastos;
            area.idConcepto_beneficio = idConcepto_beneficio;
            area.idConcepto_cobros = idConcepto_cobros;
            area.idConcepto_pagos = idConcepto_pagos;
            area.idConcepto_diferencia = idConcepto_diferencia;

            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            area.areaId = ingresos1.Rows[numeroFila].Cells[0].Value.ToString();
            area.areaText.Text = ingresos1.Rows[numeroFila].Cells[1].Value.ToString();
            area.fecha = fecha;

            area.Show();
        }

        

        private void areasIdConceptoMes(string idconcepto, string mes, DataGridView d)
        {
            //Tabla areas ingresos enero año
            DataTable t = con.tablaAreasConceptoMesAño(idconcepto, mes, label_año.Text);
            if (t.Rows.Count != 0)
            {
                d.DataSource = t;
                d.Columns[0].Visible = false;
                d.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
                if (!mes.Equals("1"))
                {
                    d.Columns[1].Visible = false;
                }
            }
        }



        private void ingresosTotalesMes(string mes, TextBox estimados, TextBox descuentos, TextBox reales)
        {
            DataTable t = con.tablaTotalesConceptoMesAño(idConcepto_ingresos, mes, label_año.Text);
            if (t.Rows.Count != 0)
            {
                estimados.Text = t.Rows[0][0].ToString();
                descuentos.Text = t.Rows[0][1].ToString();
                reales.Text = t.Rows[0][2].ToString();
            }
        }




        private void acumuladoIngresosG()
        {
            //Tabla acumulado ingresos por año
            DataTable a = con.tablaAcumuladoAño(idConcepto_ingresos, label_año.Text);
            if (a.Rows.Count != 0)
                acumuladoIngresos.Text = a.Rows[0][0].ToString();
        }


        private void siguiente_Click(object sender, EventArgs e)
        {
            General3 g = new General3();
            g.con = con;
            g.fecha = fecha;



            g.idConcepto_ingresos = idConcepto_ingresos;
            g.idConcepto_gastos = idConcepto_gastos;
            g.idConcepto_beneficio = idConcepto_beneficio;
            g.idConcepto_cobros = idConcepto_cobros;
            g.idConcepto_pagos = idConcepto_pagos;
            g.idConcepto_diferencia = idConcepto_diferencia;

            g.Show();
        }


    }
}
