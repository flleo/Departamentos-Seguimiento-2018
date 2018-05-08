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
        General gen;
        public Conexion con;
        public DateTime fecha;
        public string areaId;
        public string idConcepto_ingresos, idConcepto_gastos, idConcepto_beneficio, idConcepto_cobros, idConcepto_pagos, idConcepto_diferencia;
        string concepto_ingresos, concepto_gastos, concepto_beneficio, concepto_cobros, concepto_pagos, concepto_diferencia;
        DataTable todosconceptos;
        DataTable tablaElementosIngresos;



        Elemento el;



        public Area(General gen)
        {
            InitializeComponent();

            this.gen = gen;
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

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el area, con todos sus elementos?", "Departamentos Seguimiento 2018 - Eliminar Area",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int r = con.eliminarArea(areaId);
                if (r != 0)
                {
                    gen.Close();                   
                    this.Close();
                }
            }
        }

        private void reloadArea()
        {
            acumuladoIngresos();          
            reloadAreaIngresos();
            totales();
           
        }

        private void totales()
        {
            //Tabla totales ingresos enero año area
            DataTable totalesIngresosEneroAñoArea = con.tablaTotalesConceptoMesAñoArea(idConcepto_ingresos, "1", fecha.Year.ToString(), areaId);
            if (totalesIngresosEneroAñoArea.Rows.Count != 0)
            {
                ingresosEstimadosEnero.Text = totalesIngresosEneroAñoArea.Rows[0][0].ToString();
                ingresosDescuentoEnero.Text = totalesIngresosEneroAñoArea.Rows[0][1].ToString();
                ingresosRealEnero.Text = totalesIngresosEneroAñoArea.Rows[0][2].ToString();
            }
            //Tabla totales ingresos febr año area
            DataTable t = con.tablaTotalesConceptoMesAñoArea(idConcepto_ingresos, "2", fecha.Year.ToString(), areaId);
            if (t.Rows.Count != 0)
            {
                ingresosEstimadosFebrero.Text = t.Rows[0][0].ToString();
                ingresosDescuentoFebrero.Text = t.Rows[0][1].ToString();
                ingresosRealFebrero.Text = t.Rows[0][2].ToString();
            }
        }

        private void reloadTablaElementosMesesAñoArea()
        {
            
            tablaElementosIngresos = con.tablaElementosConceptoMesesAñoArea(idConcepto_ingresos, fecha.Year.ToString(), areaId);
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

        public void reloadArea(string concepto)
        {

          
                reloadAreaIngresos();
          
  
        }

        private void reloadAreaIngresos()
        {
            reloadTablaElementosMesesAñoArea();        

            elementosIngresoEnero.DataSource = con.tablaElementosConceptoMesesAñoArea(idConcepto_ingresos, fecha.Year.ToString(), areaId);
            elementosIngresoFebrero.DataSource = con.tablaElementosConceptoMesesAñoArea(idConcepto_ingresos, fecha.Year.ToString(), areaId);

            if (tablaElementosIngresos.Rows.Count != 0)
            {               
                string idp ="",id="",mes="";
                int ie=0;int ife=0;
                for (int i=0; i< tablaElementosIngresos.Rows.Count; i++)
                {
                    try
                    {
                        id = tablaElementosIngresos.Rows[i][0].ToString();
                        mes = tablaElementosIngresos.Rows[i][5].ToString();
                    }
                    catch (DeletedRowInaccessibleException) { }

                    if (!id.Equals(idp))
                    {                      
                        if (mes.Equals("1"))
                        {
                            try
                            {
                                elementosIngresoFebrero.Rows.Remove(elementosIngresoFebrero.Rows[i-ife]);
                                ife++;
                            }
                            catch (InvalidOperationException) { }
                        }
                        else if (mes.Equals("2"))
                        {
                            try
                            {
                                elementosIngresoEnero.Rows.Remove(elementosIngresoEnero.Rows[i-ie]);
                                ie++;
                            }
                            catch (InvalidOperationException) { }
                        }
                            

                    }
                    else if (mes.Equals("2"))
                    {
                        try
                        {
                            elementosIngresoEnero.Rows.Remove(elementosIngresoEnero.Rows[i-ie]);
                            ie++;
                        }
                        catch (InvalidOperationException) { }
                    }
                    else if (mes.Equals("1"))
                    {
                        try
                        {                           
                            elementosIngresoFebrero.Rows.Remove(elementosIngresoFebrero.Rows[i-ife]);
                            ife++;
                        }
                        catch (InvalidOperationException) { }
                    }

                    idp = id;

                   

                }
                
              

              
                if (elementosIngresoEnero.ColumnCount != 0)
                {                          
                    elementosIngresoEnero.Columns[0].Visible = false;
                    elementosIngresoEnero.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
                }

                
                if (elementosIngresoFebrero.ColumnCount != 0)
                {
                    elementosIngresoFebrero.Columns[0].Visible = false;
                    elementosIngresoFebrero.Columns[1].Visible = false;
                    elementosIngresoFebrero.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
                }

            }

           

        }

        private void elementosIngresoEnero_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            string idelemento = elementosIngresoEnero.Rows[numeroFila].Cells[0].Value.ToString();
            string elemento = elementosIngresoEnero.Rows[numeroFila].Cells[1].Value.ToString();
            string estimado = elementosIngresoEnero.Rows[numeroFila].Cells[2].Value.ToString();
            string descuento = elementosIngresoEnero.Rows[numeroFila].Cells[3].Value.ToString();
            string real = elementosIngresoEnero.Rows[numeroFila].Cells[4].Value.ToString();
            string mes = elementosIngresoEnero.Rows[numeroFila].Cells[5].Value.ToString();
            string dia = elementosIngresoEnero.Rows[numeroFila].Cells[6].Value.ToString();
            string idasiento = elementosIngresoEnero.Rows[numeroFila].Cells[7].Value.ToString();



            el = new Elemento(this, idasiento, this.fecha.Year, mes, dia, concepto_ingresos, idelemento, elemento, areaId, estimado, descuento, real);
            el.con = con;

            el.Show();
        }


        private void elementosIngresoFebrero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            string idelemento = elementosIngresoFebrero.Rows[numeroFila].Cells[0].Value.ToString();
            string elemento = elementosIngresoFebrero.Rows[numeroFila].Cells[1].Value.ToString();
            string estimado = elementosIngresoFebrero.Rows[numeroFila].Cells[2].Value.ToString();
            string descuento = elementosIngresoFebrero.Rows[numeroFila].Cells[3].Value.ToString();
            string real = elementosIngresoFebrero.Rows[numeroFila].Cells[4].Value.ToString();
            string mes = elementosIngresoFebrero.Rows[numeroFila].Cells[5].Value.ToString();
            string dia = elementosIngresoFebrero.Rows[numeroFila].Cells[6].Value.ToString();
            string idasiento = elementosIngresoFebrero.Rows[numeroFila].Cells[7].Value.ToString();



            el = new Elemento(this, idasiento, this.fecha.Year, mes, dia, concepto_ingresos, idelemento, elemento, areaId, estimado, descuento, real);
            el.con = con;

            el.Show();
        }
    }
}
