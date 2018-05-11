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
        string idasiento;
        internal Area area;
        internal Area2 area2;
        internal Area3 area3;
        internal Area4 area4;
        internal string areaName;       // Nombre de la clase
        internal string nombreDelArea;  // Como hemos llamado al área




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

        private void eliminar_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("¿Desea eliminar el elemento \""+elementoText.Text+"\" , del area \""+nombreDelArea+"\"?", "Departamentos Seguimiento 2018 - Eliminar Asiento",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {              
                int r = con.eliminarAsientoIdElemento(idelemento,idarea);
                if (r != 0)
                {
                    con.eliminarElementoArea(idelemento, idarea);
                    reloadArea();                   
                    this.Close();
                }
            }
        }

        private void reloadArea()
        {
            switch (areaName)
            {
                case "Area": area.reloadArea(); break;
                case "Area2": area2.reloadArea(); break;
                case "Area3": area3.reloadArea(); break;
                case "Area4": area4.reloadArea(); break;

            }
        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            int r = con.actualizarAsiento(idasiento,estimado.Text,descuento.Text,real.Text);
            r = con.actualizarElemento(idelemento,elementoText.Text);
            if (r != 0)
            {
                reloadArea();              
                this.Close();
            }
        }

        private void Elemento_Load(object sender, EventArgs e)
        {
           

        }
    }
}
