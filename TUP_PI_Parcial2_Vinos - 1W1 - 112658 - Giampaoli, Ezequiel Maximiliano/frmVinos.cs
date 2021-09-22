using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//1W1 - 112658 - Giampaoli, Ezequiel Maximiliano

namespace TUP_PI_Parcial2_Vinos
{
    public partial class frmVinos : Form
    {
        List<Vino> lVino = new List<Vino>();

        SqlConnection conexion = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Vinoteca;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;
        private string consultaSql = "";

        bool nuevo = false;

        public frmVinos()
        {
            InitializeComponent();
        }

        private void frmVinos_Load(object sender, EventArgs e)
        {
            Habilitar(false);

            CargarCombo(cboBodega, "Bodegas");
            CargarLista(lstVinos, "Vinos");
            //CargarGrilla(grdVinos, "Vinos");
        }

        //private void CargarGrilla(DataGridView grilla, string nombreTabla)
        //{
        //    DataTable tabla = consultarSQL("Select distinct nombre, b.nombre, precio " +
        //                                    "from Vinos v, Bodegas b " +
        //                                    "where v.")
        //}

        private void CargarLista(ListBox lista, string nombreTabla)
        {
            DataTable tabla = consultarSQL("select codigo, str(codigo)+' - '+nombre as bodega from " + nombreTabla);
            lista.DataSource = tabla;
            lista.ValueMember = tabla.Columns[0].ColumnName;
            lista.DisplayMember = tabla.Columns[1].ColumnName;
        }

        private void CargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = consultarSQL("select * from " + nombreTabla);
            combo.DataSource = tabla;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private DataTable consultarSQL(string consultaSQL)
        {
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSQL;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;
        }

        private void Habilitar(bool x)
        {            
            txtPrecio.Enabled = x;
            txtNombre.Enabled = x;
            txtCodigo.Enabled = x;
            cboBodega.Enabled = x;
            btnGuardar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnSalir.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnCancelar.Enabled = x;
            lstVinos.Enabled = !x;
        }

        private void Limpiar()
        {
            txtCodigo.Text = null;
            txtNombre.Text = null;
            txtPrecio.Text = null;
            cboBodega.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar(true);
        }

        private bool Validar()
        {
            if(txtCodigo.Text == "")
            {
                MessageBox.Show("Debe ingresar un Codigo.");
                txtCodigo.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtCodigo.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe ingresar valores numericos en el Codigo.");
                    txtCodigo.Focus();
                    return false;
                }
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un Nombre.");
                txtNombre.Focus();
                return false;
            }

            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Debe ingresar un Precio.");
                txtPrecio.Focus();
                return false;
            }

            if (cboBodega.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Bodega.");
                cboBodega.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Vino vin = new Vino();
                vin.pBodega = Convert.ToInt32(cboBodega.SelectedValue);
                vin.pCodigo = Convert.ToInt32(txtCodigo.Text);
                vin.pNombre = txtNombre.Text;
                vin.pPrecio = Convert.ToDouble(txtPrecio.Text);

                consultaSql = "Insert into Vinos values(" +
                                vin.pCodigo + ",'" +
                                vin.pNombre + "'," +
                                vin.pBodega + "," +
                                vin.pPrecio + ")";
                actualizarSQL(consultaSql);
                CargarLista(lstVinos, "Vinos");

                Limpiar();
                Habilitar(false);
                MessageBox.Show("La operacion fue realizada con exito.");
            }
        }

        private void actualizarSQL(string consulta)
        {
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
                "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Close();
        }

        private void llblAutor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Los Autores de este Form son: Ezequiel Maximiliano Giampaoli, Oscar Ernesto Botta y Joaquín Mellibosky");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilitar(false);
            Limpiar();
            CargarLista(lstVinos, "Vinos");
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string deleteSql = "DELETE FROM Vinos WHERE codigo = " + lstVinos.SelectedValue.ToString();
            actualizarSQL(deleteSql);
            CargarLista(lstVinos, "Vinos");
        }
    }
}

//1W1 - 112658 - Giampaoli, Ezequiel Maximiliano
