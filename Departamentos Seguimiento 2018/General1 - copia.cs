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
    public partial class General1 : Form
    {
        public Conexion con;
        public string idConcepto_ingresos, idConcepto_gastos, idConcepto_beneficio, idConcepto_cobros, idConcepto_pagos, idConcepto_diferencia;
        public DateTime fecha;
       
        

        public General1()
        {
            InitializeComponent();
        }

        private void excel_Click(object sender, EventArgs e)
        {
            //Exportar los datos de la tabla que visualicemos en un datagridview a una hoja de Excel
            // Creamos un objeto Excel.
            Excel.Application Mi_Excel =default(Excel.Application);
            // Creamos un objeto WorkBook. Para crear el documento Excel.           
            Excel.Workbook LibroExcel =default(Excel.Workbook);
            // Creamos un objeto WorkSheet. Para crear la hoja del documento.    
            Excel.Worksheet HojaExcel =default(Excel.Worksheet);
            // Iniciamos una instancia a Excel, y podemos hacerlo visible al final si se desea.
            Mi_Excel =new Excel.Application();
            Mi_Excel.Visible =true;

        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            General2 g = new General2();
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

     
        private void areasIngresosEnero_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Area area = new Area();
            area.con = con;
            area.genIng1 = this;

            area.idConcepto_ingresos = idConcepto_ingresos;
            area.idConcepto_gastos = idConcepto_gastos;
            area.idConcepto_beneficio = idConcepto_beneficio;
            area.idConcepto_cobros = idConcepto_cobros;
            area.idConcepto_pagos = idConcepto_pagos;
            area.idConcepto_diferencia = idConcepto_diferencia;

            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            area.areaId = areasIngresosEnero.Rows[numeroFila].Cells[0].Value.ToString();
            area.areaText.Text = areasIngresosEnero.Rows[numeroFila].Cells[1].Value.ToString();
            area.fecha = fecha;

            area.Show();
        }

        private void General_Load(object sender, EventArgs e)
        {
            label_año.Text = fecha.Year.ToString();

            acumuladoIngresosG();
            ingresosTotalesMes("1",ingresosEstimadosEnero,ingresosDescuentoEnero,ingresosRealEnero);
            ingresosTotalesMes("2", ingresosEstimadosFebrero, ingresosDescuentoFebrero, ingresosRealFebrero);
            ingresosTotalesMes("3", ingresosEstimadosMarzo, ingresosDescuentoMarzo, ingresosRealMarzo);
            areasIdConceptoMes(idConcepto_ingresos, "1", areasIngresosEnero);
            areasIdConceptoMes(idConcepto_ingresos, "2", areasIngresosFebrero);
            areasIdConceptoMes(idConcepto_ingresos, "3", areasIngresosMarzo);

        }

       
        private void areasIdConceptoMes(string idconcepto, string mes, DataGridView d)
        {
            //Tabla areas ingresos enero año
            DataTable t = con.tablaAreasConceptoMesAño(idconcepto,mes, label_año.Text);
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

       
       


    }
}
