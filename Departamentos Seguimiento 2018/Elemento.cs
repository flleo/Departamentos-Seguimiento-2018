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
        string idasiento,mes;
        Area area;

        public Elemento(Area area,string idasiento,int año,int mes, int dia, string concepto, string idelemento, string elemento, string idarea, string estimado, string descuento, string real)
        {
            InitializeComponent();

            this.idasiento = idasiento;
            this.mes = mes.ToString();
            fecha.Value = new DateTime(año,mes,dia);
            this.idelemento = idelemento;
            elementoText.Text = elemento;
            this.concepto.Text = concepto;
            this.idarea = idarea;
            this.estimado.Text = estimado;
            this.descuento.Text = descuento;
            this.real.Text = real;
            this.area = area;
            

        }

        private void eliminar_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("¿Seguro que desea eliminar el asiento?", "Departamentos Seguimiento 2018 - Eliminar Asiento",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {              
                int r = con.eliminarAsiento(idasiento);
                if (r != 0)
                {
                    area.reloadArea(mes,concepto.Text);
                    this.Close();
                }
            }
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            int r = con.actualizarAsiento(idasiento,comboArea.SelectedValue.ToString(),fecha.Value,estimado.Text,descuento.Text,real.Text);
            if (r != 0)
            {
                area.reloadArea(mes, concepto.Text);
                this.Close();
            }
        }

        private void Elemento_Load(object sender, EventArgs e)
        {
            comboArea.DataSource = con.dataSet.Tables["dtArea"];
            comboArea.DisplayMember = "Area";
            comboArea.ValueMember = "Id";

        }
    }
}
