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
        internal General_Form gf;
        public Conexion con;
        string idelemento, idarea;
        string idasiento;
        
       
        internal string nombreDelArea;  // Como hemos llamado al área


        public Elemento()
        {
            InitializeComponent();
        }


        public Elemento(string idasiento,int año, string concepto, string idelemento, string elemento, string idarea, string estimado, string descuento, string real)
        {
            InitializeComponent();

            this.idasiento = idasiento;        
            this.idelemento = idelemento;
            elementoText.Text = elemento;
            this.idarea = idarea;
            this.estimado.Text = estimado;
            this.descuento.Text = descuento;
            this.real.Text = real;
         
            

        }

   
        private void actualizar_Click(object sender, EventArgs e)
        {
            int r = con.actualizarAsiento(idasiento,estimado.Text,descuento.Text,real.Text);
            r = con.actualizarElemento(idelemento,elementoText.Text);
            if (r != 0)
            {
                gf.elementosArea(gf.fecha.Value.Month);
                gf.areas(gf.fecha.Value.Month);
                this.Close();
            }
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el elemento \"" + elementoText.Text + "\" , del area \"" + nombreDelArea + "\"?", "Departamentos Seguimiento 2018 - Eliminar Asiento",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                eliminarElemento(idelemento, idarea);
            }
        }

        internal void eliminarElemento(string idelemento, string idarea)
        {           
                int r = con.eliminarAsientoIdElemento(idelemento, idarea);
                r = con.eliminarElementoArea(idelemento, idarea);
                if (r != 0)
                {
                    gf.elementosArea(gf.fecha.Value.Month);
                    gf.areas(gf.fecha.Value.Month);
                    this.Close();
                }          
        }

        private void Elemento_Load(object sender, EventArgs e)
        {
           

        }
    }
}
