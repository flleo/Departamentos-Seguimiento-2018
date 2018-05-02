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
    public partial class General : Form
    {
        public Conexion con;
        public string idConcepto_ingresos, idConcepto_gastos, idConcepto_beneficio, idConcepto_cobros, idConcepto_pagos, idConcepto_diferencia;
        DataTable totalesIngresosEneroAño,acumuladoIngresosAño;
        public DateTime fecha;
       




        public General()
        {
            InitializeComponent();
        }

       

        private void General_Load(object sender, EventArgs e)
        {
            año.Text = fecha.Year.ToString();
            
            //Tabla acumulado ingresos por año
            acumuladoIngresosAño = con.tablaAcumuladoAño(idConcepto_ingresos, año.Text);
            if (acumuladoIngresosAño.Rows.Count != 0)
                acumuladoIngresos.Text = acumuladoIngresosAño.Rows[0][0].ToString();
            //Tabla totales ingresos enero año
            totalesIngresosEneroAño = con.tablaTotalesConceptoMesAño(idConcepto_ingresos, "1", año.Text);
            if (totalesIngresosEneroAño.Rows.Count != 0)
            {
                ingresosEstimadosEnero.Text = totalesIngresosEneroAño.Rows[0][0].ToString();
                ingresosDescuentoEnero.Text = totalesIngresosEneroAño.Rows[0][1].ToString();
                ingresosRealEnero.Text = totalesIngresosEneroAño.Rows[0][2].ToString();
            }
            //Tabla areas ingresos enero año
            DataTable t = con.tablaAreasConceptoMesAño(idConcepto_ingresos, "1", año.Text);
            if (t.Rows.Count != 0)
            {               
                areasIngresosEnero.DataSource = t;
                areasIngresosEnero.Columns[0].Visible = false;
                areasIngresosEnero.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void areasIngresosEnero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Area area = new Area();
            area.con = con;

            area.idConcepto_ingresos = idConcepto_ingresos;
            area.idConcepto_gastos = idConcepto_gastos;
            area.idConcepto_beneficio = idConcepto_beneficio;
            area.idConcepto_cobros = idConcepto_cobros;
            area.idConcepto_pagos = idConcepto_pagos;
            area.idConcepto_diferencia = idConcepto_diferencia;

            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            area.areaTop.Text =  areasIngresosEnero.Rows[numeroFila].Cells[1].Value.ToString();
            area.areaId = areasIngresosEnero.Rows[numeroFila].Cells[0].Value.ToString();
            area.fecha = fecha;
           
            area.Show();
          

        }

      
    }
}
