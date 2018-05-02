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
    public partial class Elemento : Form
    {

        public Conexion con;
        DataTable todosConceptos;
        string idelemento, idarea;

        public Elemento(int año,int mes,int dia, string idconcepto, string concepto, string idelemento, string elemento, string idarea, string estimado, string descuento, string real)
        {
            InitializeComponent();
           

            this.fecha.Value = new DateTime(año, mes, dia);
            this.idelemento = idelemento;
            elementoText.Text = elemento;
            this.concepto.Text = concepto;
            this.idarea = idarea;
            this.estimado.Text = estimado;
            this.descuento.Text = descuento;
            this.real.Text = real;

            

        }

        private void Elemento_Load(object sender, EventArgs e)
        {
            comboArea.DataSource = con.dataSet.Tables["dtArea"];
            comboArea.DisplayMember = "Area";
            comboArea.ValueMember = "Id";

        }
    }
}
