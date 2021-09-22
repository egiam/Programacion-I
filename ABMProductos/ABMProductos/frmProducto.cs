using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ABMProductos
{
    public partial class frmProducto : Form
    {
        bool nuevo = false;

        List<Producto> lProducto = new List<Producto>();

        SqlConnection conexion = new SqlConnection(@"Data Source=IDEAPAD-L340\SQLEXPRESS;Initial Catalog=Informatica;Integrated Security=True");
        //SqlConnection conexion = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Informatica;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;

        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            Habilitar(false);

            //this.cargarCombo(cboMarca, "Marcas");
            //lstProducto.DataSource = consultarTabla("productos");
            //lstProducto.DisplayMember = "detalle";
            CargarCombo(cboMarca, "Marcas");
            CargarLista(lstProducto, "Productos");
        }


        private void CargarLista(ListBox lista, string nombreTabla)
        {
            DataTable tabla = consultarSQL("select codigo, str(codigo)+' - '+detalle+' $'+str(precio) as info from " + nombreTabla);
            lista.DataSource = tabla;
            lista.ValueMember = tabla.Columns[0].ColumnName;
            lista.DisplayMember = tabla.Columns[1].ColumnName;
            //lstProducto.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Forma 1
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

        //Forma 2
        //private void cargarCombo(ComboBox componente, string nombreTabla)
        //{

        //    DataTable tabla = consultarTabla(nombreTabla);
        //    componente.DataSource = tabla;
        //    componente.ValueMember = tabla.Columns[0].ColumnName;
        //    componente.DisplayMember = tabla.Columns[1].ColumnName;
        //    componente.DropDownStyle = ComboBoxStyle.DropDownList;

        //}

        //private DataTable consultarTabla(string nombreTabla)
        //{
        //    conexion.Open();

        //    comando.Connection = conexion;
        //    comando.CommandType = CommandType.Text;
        //    comando.CommandText = "Select * from " + nombreTabla;
        //    DataTable tabla = new DataTable();
        //    tabla.Load(comando.ExecuteReader());

        //    conexion.Close();

        //    return tabla;
        //}

        private void Habilitar(bool x)
        {
            txtCodigo.Enabled = x;
            txtDetalle.Enabled = x;
            txtPrecio.Enabled = x;
            rbtNetBook.Enabled = x;
            rbtNoteBook.Enabled = x;
            dtpFecha.Enabled = x;
            cboMarca.Enabled = x;
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnSalir.Enabled = !x;
            lstProducto.Enabled = !x;
        }

        private void Limpiar()
        {
            txtCodigo.Text = null;
            txtDetalle.Text = null;
            txtPrecio.Text = null;
            cboMarca.SelectedIndex = -1;
            rbtNetBook.Checked = false;
            rbtNoteBook.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            Habilitar(true);
            Limpiar();
            txtCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            Habilitar(false);
            Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
                "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            txtCodigo.Text = lstProducto.SelectedValue.ToString();
            Habilitar(true);
            txtDetalle.Focus();
            txtCodigo.Enabled = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de borrar esta persona ?",
                "BORRANDO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                consultaSql = "Delete productos where codigo = " + lstProducto.SelectedValue.ToString();
                actualizarSQL(consultaSql);
                Limpiar();
                Habilitar(false);
                CargarLista(lstProducto, "Productos");
            }
        }

        private bool Validar()
        {
            return true;
        }

        private string consultaSql = "";

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Producto p = new Producto();
                p.pCodigo = Convert.ToInt32(txtCodigo.Text);
                p.pDetalle = txtDetalle.Text;
                p.pFecha = dtpFecha.Value;
                p.pMarca = Convert.ToInt32(cboMarca.SelectedValue);
                p.pPrecio = Convert.ToDouble(txtPrecio.Text);
                if (rbtNoteBook.Checked)
                {
                    p.pTipo = 1;
                }
                else
                {
                    p.pTipo = 2;
                }

                if (nuevo)
                {
                    consultaSql = "Insert into productos(codigo, detalle, tipo, marca, precio, fecha) " +
                                                 "values(" +
                                                 p.pCodigo + ",'" +
                                                 p.pDetalle + "'," +
                                                 p.pTipo + "," +
                                                 p.pMarca + "," +
                                                 p.pPrecio + ",'" +
                                                 p.pFecha.ToString("yyyy/MM/dd") + "')";
                    actualizarSQL(consultaSql);                    
                }
                else
                {
                    consultaSql = "update productos " +
                        "set detalle = '"+ p.pDetalle +"'," +
                        "tipo = " + p.pTipo + "," +
                        "marca = "+ p.pMarca + "," + 
                        "precio = " + p.pPrecio + "," +
                        "fecha = '" + p.pFecha.ToString("yyyy/MM/dd") +
                        "' where codigo = " + p.pCodigo;
                    actualizarSQL(consultaSql);
                }
                CargarLista(lstProducto, "Productos");

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

        private void lstProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarCampos(lstProducto.SelectedIndex);
        }

        private void CargarCampos(int posicion)
        {
            txtCodigo.Text = lProducto[posicion].pCodigo.ToString();
            txtDetalle.Text = lProducto[posicion].pDetalle;
            txtPrecio.Text = lProducto[posicion].pPrecio.ToString();
            cboMarca.SelectedValue = lProducto[posicion].pMarca;
            dtpFecha.Value = lProducto[posicion].pFecha;
            if (lProducto[posicion].pTipo == 1)
                rbtNoteBook.Checked = true;
            else
                rbtNetBook.Checked = true;

        }
    }
}
