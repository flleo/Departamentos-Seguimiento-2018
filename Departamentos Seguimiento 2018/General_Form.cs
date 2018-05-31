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
    public partial class General_Form : Form
    {
        internal Conexion con;
        private string idarea="";
        string idconcepto = "";
        internal Menu menu;
        private int ex;

        public General_Form()
        {
            InitializeComponent();
        }

        private void General_Form_Load(object sender, EventArgs e)
        {
            elementos.ScrollBars=0;
            // Combo Concepto
            comboConcepto.DataSource = con.tabla("SELECT * FROM CONCEPTO");
            comboConcepto.DisplayMember = "Concepto";
            comboConcepto.ValueMember = "Id";
            idconcepto = comboConcepto.SelectedValue.ToString();
            //Bindeos
            actualizaMes();
            areas(fecha.Value.Month);
            elementosArea(fecha.Value.Month);
            label_año.Text = fecha.Value.Year.ToString();

            
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
        }


        internal void areas(int mes)
        {
            double r1,r2,di3;
            data.DataSource = null;
            if (idconcepto.Equals("3"))
            {
                r1 = 0; r2 = 0; di3 = 0.0;
                DataTable totalesIngresos = con.tablaTotalesConceptoMesAño_("1", mes, fecha.Value.Year);
                DataTable totalesGastos = con.tablaTotalesConceptoMesAño_("2", mes, fecha.Value.Year);
                try
                {
                    estimado.Text = (Double.Parse(totalesIngresos.Rows[0][0].ToString()) - Double.Parse(totalesGastos.Rows[0][0].ToString())).ToString();
                    descuento.Text = (Double.Parse(totalesIngresos.Rows[0][1].ToString()) - Double.Parse(totalesGastos.Rows[0][1].ToString())).ToString();
                    real.Text = (Double.Parse(totalesIngresos.Rows[0][2].ToString()) - Double.Parse(totalesGastos.Rows[0][2].ToString())).ToString();
                    for (int i = 1; i <= 12; i++)
                    {
                        r1 += Double.Parse(con.tablaTotalesConceptoMesAño_("1", i, fecha.Value.Year).Rows[0][2].ToString());
                        r2 += Double.Parse(con.tablaTotalesConceptoMesAño_("2", i, fecha.Value.Year).Rows[0][2].ToString());
                    }
                    di3 = r1 - r2;
                    acumulado.Text = di3.ToString();
                }
                catch {
                    acumulado.Text = 0.ToString();
                    estimado.Text = 0.ToString();
                    descuento.Text = 0.ToString();
                    real.Text = 0.ToString();
                }
            }
            else if (idconcepto.Equals("6"))
            {
                r1 = 0; r2 = 0; di3 = 0.0;
                DataTable totalesIngresos = con.tablaTotalesConceptoMesAño_("4", mes, fecha.Value.Year);
                DataTable totalesGastos = con.tablaTotalesConceptoMesAño_("5", mes, fecha.Value.Year);
                try
                {
                    estimado.Text = (Double.Parse(totalesIngresos.Rows[0][0].ToString()) - Double.Parse(totalesGastos.Rows[0][0].ToString())).ToString();
                    descuento.Text = (Double.Parse(totalesIngresos.Rows[0][1].ToString()) - Double.Parse(totalesGastos.Rows[0][1].ToString())).ToString();
                    real.Text = (Double.Parse(totalesIngresos.Rows[0][2].ToString()) - Double.Parse(totalesGastos.Rows[0][2].ToString())).ToString();
                    for (int i = 1; i <= 12; i++)
                    {
                        r1 += Double.Parse(con.tablaTotalesConceptoMesAño_("4", i, fecha.Value.Year).Rows[0][2].ToString());
                        r2 += Double.Parse(con.tablaTotalesConceptoMesAño_("5", i, fecha.Value.Year).Rows[0][2].ToString());
                    }
                    di3 = r1 - r2;
                    acumulado.Text = di3.ToString();
                }
                catch
                {
                    acumulado.Text = 0.ToString();
                    estimado.Text = 0.ToString();
                    descuento.Text = 0.ToString();
                    real.Text = 0.ToString();
                }
            }
            else
            {
                data.DataSource = con.tablaAreasConceptoMesAño_(idconcepto, mes, fecha.Value.Year);
                try
                {
                    //    if (data.Rows.Count > 0)
                    //   {
                    data.Columns[0].Visible = false;
                    acumulado.Text = con.tablaAcumuladoAño_(idconcepto, fecha.Value.Year).Rows[0][0].ToString();
                    DataTable totales = con.tablaTotalesConceptoMesAño_(idconcepto, fecha.Value.Month, fecha.Value.Year);
                    estimado.Text = totales.Rows[0][0].ToString();
                    descuento.Text = totales.Rows[0][1].ToString();
                    real.Text = totales.Rows[0][2].ToString();
                    
                } catch  {
                    if (idconcepto.Equals("1") || idconcepto.Equals("2") || idconcepto.Equals("4") || idconcepto.Equals("5"))
                        MessageBox.Show("No existen elementos relacionados para " + concepto.Text + " en " + fecha.Value.Year + "\nDebes asociar un Elemento a un Area"
                            + "\nSólo se permitiran registros nuevos en el presente año");
                    else
                        MessageBox.Show("Debes asociar un Elemento a un Area");
                    if(ex==0)
                        this.Close();
                }
            }
        }

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            eliminar.Enabled = true;
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());       
            areaText.Text = data.Rows[numeroFila].Cells[1].Value.ToString();
            string ida = data.Rows[numeroFila].Cells[0].Value.ToString();
            idarea = ida;
            elementosArea(fecha.Value.Month);         
           
        }

        internal void elementosArea(int mes)
        {
           // MessageBox.Show(idarea);
            if (!idarea.Equals(""))
            {

                elementos.DataSource = null;
                if (idconcepto.Equals("3")) totales_("1", "2");
                else if (idconcepto.Equals("6")) totales_("4", "5");
                else { 
                // MessageBox.Show(elementos.Rows.Count.ToString());
                // MessageBox.Show(idconcepto+"@"+ mes.ToString()+"@"+ fecha.Value.Year.ToString()+"@"+ idarea);
                elementos.DataSource = con.tablaElementosConceptoMesAñoArea_(idconcepto, mes.ToString(), fecha.Value.Year.ToString(), idarea);
                    //  MessageBox.Show(elementos.RowCount.ToString());

                    acumuladoE.Text = con.tablaAcumuladoAñoArea(idconcepto, fecha.Value.Year.ToString(), idarea).Rows[0][0].ToString();
                    DataTable totales = con.tablaTotalesConceptoMesAñoArea(idconcepto, mes.ToString(), fecha.Value.Year.ToString(), idarea);
                    estimadoE.Text = totales.Rows[0][0].ToString();
                    descuentoE.Text = totales.Rows[0][1].ToString();
                    realE.Text = totales.Rows[0][2].ToString();

                    if (elementos.Rows.Count > 0)
                    {
                        elementos.Columns[0].Visible = false;
                        elementos.ColumnHeadersVisible = false;
                        elementos.RowHeadersVisible = false;

                    }
                }
            }
        }

        private void totales_(string idcon1,string idcon2)
        {
            double esting=0, desing=0, reaing=0, estgas=0, desgas=0, reagas=0, totreaing=0, totreagas=0;
           // MessageBox.Show(idcon1, fecha.Value.Year.ToString()+"@"+ idarea);
            DataTable totreaingDT = con.tablaTotalesRealesConceptoAñoArea(idcon1, fecha.Value.Year.ToString(), idarea);
            DataTable totreagasDT = con.tablaTotalesRealesConceptoAñoArea(idcon2, fecha.Value.Year.ToString(), idarea);

            if (!totreaingDT.Rows[0][0].ToString().Equals("")) totreaing = Double.Parse(totreaingDT.Rows[0][0].ToString());           
            if (!totreagasDT.Rows[0][0].ToString().Equals("")) totreagas = Double.Parse(totreagasDT.Rows[0][0].ToString());

            acumuladoE.Text = (totreaing - totreagas).ToString();
          //  MessageBox.Show(idcon1+"@"+fecha.Value.Month.ToString()+"@"+ fecha.Value.Year.ToString() + "@" + idarea);
            DataTable toting = con.tablaTotalesConceptoMesAñoArea(idcon1, fecha.Value.Month.ToString(), fecha.Value.Year.ToString(), idarea);
            DataTable totgas = con.tablaTotalesConceptoMesAñoArea(idcon2, fecha.Value.Month.ToString(), fecha.Value.Year.ToString(), idarea);
           
            if (!toting.Rows[0][0].ToString().Equals(""))
            {
             //   
                esting = Double.Parse(toting.Rows[0][0].ToString());// - Double.Parse(totgas.Rows[0][0].ToString());
                desing = Double.Parse(toting.Rows[0][1].ToString());// - Double.Parse(totgas.Rows[0][1].ToString());
                reaing = Double.Parse(toting.Rows[0][2].ToString());// - Double.Parse(totgas.Rows[0][2].ToString());
            }
            if (!totgas.Rows[0][0].ToString().Equals(""))
            {
                estgas = Double.Parse(totgas.Rows[0][0].ToString());// Double.Parse(toting.Rows[0][0].ToString()) -
                desgas = Double.Parse(totgas.Rows[0][1].ToString());//Double.Parse(toting.Rows[0][1].ToString()) - 
                reagas = Double.Parse(totgas.Rows[0][2].ToString());// Double.Parse(toting.Rows[0][2].ToString()) -
            }
            estimadoE.Text  = (esting - estgas).ToString();
            descuentoE.Text = (desing - desgas).ToString();
            realE.Text = (reaing - reagas).ToString();
           
        }
            
    

        private void elementos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int numeroFila = Convert.ToInt16(e.RowIndex.ToString());
            string elementoId = elementos.Rows[numeroFila].Cells[0].Value.ToString();
            string elemento = elementos.Rows[numeroFila].Cells[1].Value.ToString();
            string estimado = elementos.Rows[numeroFila].Cells[2].Value.ToString();
            string descuento = elementos.Rows[numeroFila].Cells[3].Value.ToString();
            string real = elementos.Rows[numeroFila].Cells[4].Value.ToString();
            string idasiento = elementos.Rows[numeroFila].Cells[5].Value.ToString();

            Elemento el = new Elemento(idasiento, fecha.Value.Year, idconcepto, elementoId, elemento, idarea, estimado, descuento, real);
            el.nombreDelArea = areaText.Text;
            el.con = con;
            el.gf = this;
            el.Show();
        }
       

        private void areasButton_Click(object sender, EventArgs e)
        {
            label_año.Text = fecha.Value.Year.ToString();
            idconcepto = comboConcepto.SelectedValue.ToString();       
            conceptoE.Text = concepto.Text = comboConcepto.Text.ToString();
            actualizaMes();
            elementosArea(Int32.Parse(fecha.Value.Month.ToString()));
            //elementos.DataSource = null;
            areas(fecha.Value.Month);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ex = 1;
            //Exportar los datos de la tabla que visualicemos en un datagridview a una hoja de Excel
            // Creamos un objeto Excel.
            Excel.Application excel = default(Excel.Application);
            // Creamos un objeto WorkBook. Para crear el documento Excel.           
            Excel.Workbook ds2018 = default(Excel.Workbook);
            // Creamos un objeto WorkSheet. Para crear la hoja del documento.    
           // Excel.Worksheet general = default(Excel.Worksheet);           
            // Iniciamos una instancia a Excel, y podemos hacerlo visible al final si se desea.
            excel = new Excel.Application();
            excel.Visible = true;
            /*Ahora creamos un nuevo documento y seleccionamos la primera hoja del documento en la cual crearemos nuestro informe.               */
            // Creamos una instancia del Workbooks de excel.                         
            ds2018 = excel.Workbooks.Add();
            // Creamos una instancia de la primera hoja de trabajo de excel
            //general = ds2018.Worksheets[1];

          
            // AREA///////////////////////
            // Creamos una instancia de la  hoja de trabajo de excel 
            int n,filas;
           // data.DataSource = null;
            DataTable dt = con.tabla("select distinct idarea,area from  Elemento_Area as ea inner join area as a on a.id=ea.idarea");
            n = filas = dt.Rows.Count;
            //MessageBox.Show(filas.ToString());
            while (filas>0)
            {
                //MessageBox.Show(n.ToString());
                int idarea = Int32.Parse(dt.Rows[filas-1][0].ToString());
                string area = dt.Rows[filas-1][1].ToString();
                // ds2018.Worksheets.Add();
                Excel.Worksheet area1 = ds2018.Worksheets.Add();
                //default(Excel.Worksheet);
                //area1 = ds2018.Worksheets.Add(n+1);

                area1.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                // Hacemos esta hoja la visible en pantalla  (como seleccionamos la primera esto no es necesario, si seleccionamos una diferente a la primera si lo  necesitariamos).            
                area1.Activate();
                // Año             
                //hojadetrabajo.Cells[3, c + 1].Borders.Value = 9;
                area1.Range["A2"].Borders.LineStyle = true;
                area1.Range["A2"].Font.Bold = true;
                area1.Range["A2"].Value = "ÁREA:";
                // hoja.Range[hoja.Cells["B2"], hoja.Cells["C2"]].Borders.LineStyle = true;
                area1.Range["B2","C2"].Borders.LineStyle = true;
                area1.Range["B2", "C2"].Merge();
                area1.Range["B2"].Value = area;
                area1.Name = area;
               
                hoja(area1, idarea);
            //    MessageBox.Show(filas+"@"+n);
                filas--;
            }
            
            // GENERAL///////////////////////
            Excel.Worksheet general = ds2018.Worksheets.Add();
            general.Visible = Excel.XlSheetVisibility.xlSheetVisible;
            // Hacemos esta hoja la visible en pantalla  (como seleccionamos la primera esto no es necesario             // si seleccionamos una diferente a la primera si lo  necesitariamos).            
            general.Activate();
            //Año
            general.Range["A2"].Borders.LineStyle = true;
            general.Range["A2"].Font.Bold = true;
            general.Range["A2"].Value = label_año.Text;
            general.Name = "GENERAL";
            hoja(general, 0);

            //Eliminamos la ultima hoja por defecto
            Excel.Worksheet worksheet = (Excel.Worksheet)ds2018.Worksheets[n+2];
            worksheet.Delete();


            ex = 0;
        }

        private void hoja(Excel.Worksheet hoja,int idarea)
        {           
            hoja.Cells.HorizontalAlignment = Excel.Constants.xlCenter;
            //Fila 5
            hoja.Range["A5"].Font.Bold = true;
            hoja.Range["A5"].Value = "ACUMULADO";
            hoja.Range["A5"].Columns.AutoFit();

            // Definimos variables para enumerar las celdas
            int j, j1 = 0; int oarea = 2; int farea = 3; int omes = 4; int fmes = 6; int salto = 0;
            string E = ""; string D = ""; string R = "";
            int[] saltosv = new int[6];
            string[] conceptos = new string[6];
            saltosv[j1] = 0;
            // Conceptos           
            for (j = 1; j <= 6; j++)
            {
                idconcepto = j.ToString();
                comboConcepto.SelectedValue = j;
                conceptos[j - 1] = comboConcepto.Text.ToString();
                if (!hoja.Name.Equals("GENERAL"))
                {                 
                    data.DataSource = null;
                    data.DataSource = con.tablaElementosConceptoMesAñoArea_(idconcepto,"1" , fecha.Value.Year.ToString(), idarea.ToString());
                 //   MessageBox.Show(data.Rows.Count.ToString());
                }
                else
                {
                    data.DataSource = null;
                    data.DataSource = con.tablaAreasConceptoMesAño_(idconcepto,1,fecha.Value.Year);
                }
               
                // f = nºfilas
                int f = 1;
                int k = 0;

                // Filas: Areas/Elementos Estimado Descuento Real para conceptos distintos de beneficio ó diferencia                      
                while (f < data.Rows.Count && j != 3 && j != 6)
                {
                    // Areas/Elementos
                    hoja.Range[hoja.Cells[7 + k + saltosv[j1], oarea], hoja.Cells[7 + k + saltosv[j1], farea]].Interior.Color = Color.Silver;
                    hoja.Range[hoja.Cells[7 + k + saltosv[j1], oarea], hoja.Cells[7 + k + saltosv[j1], farea]].Merge();
                    hoja.Range[hoja.Cells[7 + k + saltosv[j1], oarea], hoja.Cells[7 + k + saltosv[j1], farea]].Borders.LineStyle = true;
                    hoja.Cells[7 + k + saltosv[j1], oarea] = data.Rows[k].Cells[1].Value.ToString();
                    f++;
                    k++;
                }

                //Acumulado
                hoja.Cells[6 + saltosv[j1], "A"].Interior.Color = Color.LightSkyBlue;
                hoja.Cells[6 + saltosv[j1], "A"].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                hoja.Cells[6 + saltosv[j1], "A"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThick;
                hoja.Cells[6 + saltosv[j1], "A"].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThick;
                hoja.Cells[6 + saltosv[j1], "A"].Font.Bold = true;
                hoja.Cells[6 + saltosv[j1], "A"].FormulaLocal = "=SUMA(F" + (6 + saltosv[j1]).ToString() + ";I" + (6 + saltosv[j1]).ToString() + ";L" + (6 + saltosv[j1]).ToString() + ";O" + (6 + saltosv[j1]).ToString() + ";R" + (6 + saltosv[j1]).ToString() + ";U" + (6 + saltosv[j1]).ToString() + ";AA" + (6 + saltosv[j1]).ToString() + ";AD" + (6 + saltosv[j1]).ToString() + ";AG" + (6 + saltosv[j1]).ToString() + ";AJ" + (6 + saltosv[j1]).ToString() + ";AM" + (6 + saltosv[j1]).ToString() + ";AP" + (6 + saltosv[j1]).ToString() + ")";
              
                // Concepto
                hoja.Range[hoja.Cells[6 + saltosv[j1], "B"], hoja.Cells[6 + saltosv[j1], "C"]].Merge();
                hoja.Range[hoja.Cells[6 + saltosv[j1], "B"], hoja.Cells[6 + saltosv[j1], "C"]].Interior.Color = Color.Gray;
                hoja.Range[hoja.Cells[6 + saltosv[j1], "B"], hoja.Cells[6 + saltosv[j1], "C"]].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                hoja.Range[hoja.Cells[6 + saltosv[j1], "B"], hoja.Cells[6 + saltosv[j1], "C"]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                hoja.Range[hoja.Cells[6 + saltosv[j1], "B"], hoja.Cells[6 + saltosv[j1], "C"]].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                hoja.Cells[6 + saltosv[j1], "B"].Font.Bold = true;
                hoja.Cells[6 + saltosv[j1], "B"].Value2 = conceptos[j1];
                //  MessageBox.Show(saltosv[j1].ToString());
                if (j1 < 5)
                {
                    j1++; if (j == 3) saltosv[j1] = saltosv[j1 - 1] + f + 1; else saltosv[j1] = saltosv[j1 - 1] + f;
                }
            }

            //Calculo de Estimado, Descuento, Real para los 6 conceptos y los 12 meses          
            for (int i = 0; i < 12; i++)
            {
                j1 = 0;
                // Actualizamos fecha para el mes
                DateTime f = new DateTime(fecha.Value.Year, i + 1, 1);
                fecha.Value = f;
                actualizaMes();
                // Mes Enunciado [FILA,COLUMNA]
                hoja.Range[hoja.Cells[4, omes + salto + i], hoja.Cells[4, fmes + salto + i]].Font.Bold = true;
                hoja.Range[hoja.Cells[4, omes + salto + i], hoja.Cells[4, fmes + salto + i]].Interior.Color = Color.Gray;               
                hoja.Range[hoja.Cells[4, omes + salto + i], hoja.Cells[4, fmes + salto + i]].Merge();
                hoja.Range[hoja.Cells[4, omes + salto + i], hoja.Cells[4, fmes + salto + i]].Borders.LineStyle = true;
                hoja.Cells[4, omes + salto + i] = mes.Text;
                // Estimado Descuento Real Enunciado
                hoja.Range[hoja.Cells[5, omes + salto + i], hoja.Cells[5, fmes + salto + i]].Font.Bold = true;
                hoja.Range[hoja.Cells[5, omes + salto + i], hoja.Cells[5, fmes + salto + i]].Interior.Color = Color.Silver;
                hoja.Range[hoja.Cells[5, omes + salto + i], hoja.Cells[5, fmes + salto + i]].Borders.LineStyle = true;
                hoja.Cells[5, omes + salto + i] = "ESTIMADO";
                hoja.Cells[5, omes + salto + i + 1] = "DESCUENTO";
                hoja.Cells[5, omes + salto + i + 2] = "REAL";
                // Totales: Estimado Descuento Real
                switch (i)
                {
                    case 0: { E = "D"; D = "E"; R = "F"; break; }
                    case 1: { E = "G"; D = "H"; R = "I"; break; }
                    case 2: { E = "J"; D = "K"; R = "L"; break; }
                    case 3: { E = "M"; D = "N"; R = "O"; break; }
                    case 4: { E = "P"; D = "Q"; R = "R"; break; }
                    case 5: { E = "S"; D = "T"; R = "U"; break; }
                    case 6: { E = "V"; D = "W"; R = "X"; break; }
                    case 7: { E = "Y"; D = "Z"; R = "AA"; break; }
                    case 8: { E = "AB"; D = "AC"; R = "AD"; break; }
                    case 9: { E = "AE"; D = "AF"; R = "AG"; break; }
                    case 10: { E = "AH"; D = "AI"; R = "AJ"; break; }
                    case 11: { E = "AK"; D = "AL"; R = "AM"; break; }
                    case 12: { E = "AN"; D = "AO"; R = "AP"; break; }
                }
                // Valores para las areas en los 12 meses
                for (j = 1; j <= 6; j++)
                {
                    idconcepto = j.ToString();
                   
                    int f1 = 1;
                    int k = 0;
                    // Para General
                    if (idarea == 0)
                    {
                        areas(fecha.Value.Month);
                        // Filas (Areas) por Concepto:  Estimado Descuento Real para conceptos distintos de beneficio ó diferencia  
                        while (f1 < data.Rows.Count)
                        {
                            // Areas
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i] = Double.Parse(data.Rows[k].Cells[2].Value.ToString());
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i + 1] = Double.Parse(data.Rows[k].Cells[3].Value.ToString());
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i + 2] = Double.Parse(data.Rows[k].Cells[4].Value.ToString());

                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i + 1].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i + 2].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                            f1++;
                            k++;
                        }               
                    }
                    // Para Areas los Elementos
                    else
                    {
                        // Filas (Elementos) por Concepto: Estimado Descuento Real para conceptos distintos de beneficio ó diferencia 
                        this.idarea = idarea.ToString();
                        elementosArea(fecha.Value.Month);

                        //   MessageBox.Show(elementos.Rows.Count.ToString());
                        while (f1 < elementos.Rows.Count)
                        {
                            // Elementos
                            // MessageBox.Show(estimado.Text);
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i] = Double.Parse(estimadoE.Text);
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i + 1] = Double.Parse(descuentoE.Text);
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i + 2] = Double.Parse(realE.Text);

                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i + 1].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                            hoja.Cells[7 + k + saltosv[j1], omes + salto + i + 2].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                            f1++;
                            k++;
                        }
                    }
                   
                    // Para todos:

                    // Totales Areas Negrita
                    hoja.Cells[6 + saltosv[j1], omes + salto + i].Font.Bold = true;
                    hoja.Cells[6 + saltosv[j1], omes + salto + i + 1].Font.Bold = true;
                    hoja.Cells[6 + saltosv[j1], omes + salto + i + 2].Font.Bold = true;


                    if (j == 3 || j == 6)
                    {
                        hoja.Cells[6 + saltosv[j1], omes + salto + i].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                        hoja.Cells[6 + saltosv[j1], omes + salto + i + 1].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                        hoja.Cells[6 + saltosv[j1], omes + salto + i + 2].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                     
                        hoja.Cells[6 + saltosv[j1], omes + salto + i].FormulaLocal = "=" + E + (6 + saltosv[j1 - 2]).ToString() + "-" + E + (6 + saltosv[j1 - 1]).ToString();
                        hoja.Cells[6 + saltosv[j1], omes + salto + i + 1].FormulaLocal = "=" + D + (6 + saltosv[j1 - 2]).ToString() + "-" + D + (6 + saltosv[j1 - 1]).ToString();
                        hoja.Cells[6 + saltosv[j1], omes + salto + i + 2].FormulaLocal = "=" + R + (6 + saltosv[j1 - 2]).ToString() + "-" + R + (6 + saltosv[j1 - 1]).ToString();
                    }
                    else
                    {
                        // Totales 
                        if (k > 0)     // Existen registros
                        {
                            hoja.Cells[6 + saltosv[j1], omes + salto + i].FormulaLocal = "=SUMA(" + E + (7 + saltosv[j1]).ToString() + ":" + E + (6 + saltosv[j1] + k).ToString() + ")";
                            hoja.Cells[6 + saltosv[j1], omes + salto + i + 1].FormulaLocal = "=SUMA(" + D + (7 + saltosv[j1]).ToString() + ":" + D + (6 + saltosv[j1] + k).ToString() + ")";
                            hoja.Cells[6 + saltosv[j1], omes + salto + i + 2].FormulaLocal = "=SUMA(" + R + (7 + saltosv[j1]).ToString() + ":" + R + (6 + saltosv[j1] + k).ToString() + ")";

                            hoja.Cells[6 + saltosv[j1], omes + salto + i].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                            hoja.Cells[6 + saltosv[j1], omes + salto + i + 1].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                            hoja.Cells[6 + saltosv[j1], omes + salto + i + 2].NumberFormat = "#.##0,00€;[Rojo]#.##0,00€";
                        }

                    }
                    j1++; //Cambiamos de concepto

                }
                salto += 2;
            }
            
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            eliminarArea(idarea);
           
        }

        internal void eliminarArea(string idarea)
        {
            if (!idarea.Equals(""))
            {
                if (MessageBox.Show("¿Desea eliminar el area \"" + areaText.Text + "\", con todos sus elementos?", "Departamentos Seguimiento 2018 - Eliminar Area",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    MessageBox.Show(idarea);
                    int r = con.eliminarAreaIdArea(idarea);
                    if (r > 0)
                    {
                        MessageBox.Show("Area eliminada");
                        areas(fecha.Value.Month);
                        menu.cargaComboAreas();
                    }
                }

            }
            else
            {
                MessageBox.Show("Debes seleccionar un área");
            }
        }

      
    }
        

       
    
}
