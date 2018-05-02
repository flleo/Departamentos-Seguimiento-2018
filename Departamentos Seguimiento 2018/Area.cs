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
        public Conexion con;
        public DateTime fecha;
        public string areaId;
        public string idConcepto_ingresos, idConcepto_gastos, idConcepto_beneficio, idConcepto_cobros, idConcepto_pagos, idConcepto_diferencia;
        string concepto_ingresos, concepto_gastos, concepto_beneficio, concepto_cobros, concepto_pagos, concepto_diferencia;
        DataTable todosconceptos;


        public Area()
        {
            InitializeComponent();
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


            //Tabla acumulado ingresos por año area
            DataTable acumuladoIngresosAñoArea = con.tablaAcumuladoAñoArea(idConcepto_ingresos, fecha.Year.ToString(), areaId);
            if (acumuladoIngresosAñoArea.Rows.Count != 0)
                acumulado_ingresos.Text = acumuladoIngresosAñoArea.Rows[0][0].ToString();
            //Tabla totales ingresos enero año area
            DataTable totalesIngresosEneroAñoArea = con.tablaTotalesConceptoMesAñoArea(idConcepto_ingresos, "1", fecha.Year.ToString(), areaId);
            if (totalesIngresosEneroAñoArea.Rows.Count != 0)
            {
                ingresosEstimadosEnero.Text = totalesIngresosEneroAñoArea.Rows[0][0].ToString();
                ingresosDescuentoEnero.Text = totalesIngresosEneroAñoArea.Rows[0][1].ToString();
                ingresosRealEnero.Text = totalesIngresosEneroAñoArea.Rows[0][2].ToString();
            }
            //Tabla elementos ingresos enero año area
            DataTable t = con.tablaElementosConceptoMesAñoArea(idConcepto_ingresos, "1", fecha.Year.ToString(), areaId);
            if (t.Rows.Count != 0)
            {
                elementosIngresoEnero.DataSource = t;
                elementosIngresoEnero.Columns[0].Visible = false;
                elementosIngresoEnero.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void elementosIngresoEnero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            string idelemento = elementosIngresoEnero.Rows[numeroFila].Cells[0].Value.ToString();
            string elemento = elementosIngresoEnero.Rows[numeroFila].Cells[1].Value.ToString();
            string estimado = elementosIngresoEnero.Rows[numeroFila].Cells[2].Value.ToString();
            string descuento = elementosIngresoEnero.Rows[numeroFila].Cells[3].Value.ToString();
            string real = elementosIngresoEnero.Rows[numeroFila].Cells[4].Value.ToString();
            string fecha = elementosIngresoEnero.Rows[numeroFila].Cells[5].Value.ToString();


            
            Elemento el = new Elemento(this.fecha.Year,this.fecha.Month,Int32.Parse(fecha.Substring(0,2)),idConcepto_ingresos, concepto_ingresos, idelemento, elemento, areaId,estimado,descuento,real);
            el.con = con;

            el.Show();
        }
    }
}
