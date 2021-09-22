using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUP_PI_Parcial1
{
    public partial class frmViajes : Form
    {
        Viaje nuevoViaje;

        public frmViajes()
        {
            InitializeComponent();
        }

        private void btnRegistrarViaje_Click(object sender, EventArgs e)
        {
            nuevoViaje = new Viaje();
            nuevoViaje.pNumeroViaje = Convert.ToInt32(txtNumeroViaje.Text);
            nuevoViaje.pLugarDestino = txtLugarDestino.Text;
            nuevoViaje.pCostoUnitario = Convert.ToDouble(txtCostoUnitario.Text);
        }

        private void frmViajes_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarEstudiante_Click(object sender, EventArgs e)
        {
            Estudiante e1 = new Estudiante();
            //nuevoViaje = new Viaje();

            e1.pEdad = Convert.ToInt32(txtEdad.Text);
            e1.pLegajo = Convert.ToInt32(txtLegajo.Text);
            e1.pNombre = txtNombre.Text;
            e1.pPromedio = Convert.ToDouble(txtPromedio.Text);
            e1.pSexo = rbtMasculino.Checked;

            nuevoViaje.RegistrarEstudiante(e1);

        }

        private void btnPorcentaje_Click(object sender, EventArgs e)
        {
            lblPorcentajeMayor.Text = nuevoViaje.MostrarPorsentaje().ToString();
        }

        private void btnCostoTotal_Click(object sender, EventArgs e)
        {
            lblCostoTotal.Text = nuevoViaje.CostoTotal().ToString();
        }
    }
}
