using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//CURSO: – LEGAJO: – APELLIDO: – NOMBRE:

namespace TUP_PI_Parcial2_Joyas
{
    public partial class frmJoyas : Form
    {
        bool nuevo = true;
        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-VODM8NI\SQLEXPRESS;Initial Catalog=Joyeria;Integrated Security=True");
        SqlCommand comando = new SqlCommand();

        //muestra la tabla actualizada
        private void actualizarSql(string consultaSql)
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSql;
            comando.ExecuteNonQuery();
            conexion.Close();

        }
        //carga la listbox
        private void cargarLista(ListBox lista, string nombreTabla)
        {
            DataTable tabla = consultarSql(consultaSql: "select codigo ,'    '+str(codigo)+'    ' +nombre + '    '+' $'+str(precio) + '    '+str(tipo) as INFO  from " + nombreTabla);
            lista.DataSource = tabla;
            //valor del item de la tabla
            lista.ValueMember = tabla.Columns[0].ColumnName;
            // nombre de columnas que quiero mostrar
            lista.DisplayMember = tabla.Columns[1].ColumnName;
        }
        //carga el combobox
        private void cargarCombo(ComboBox combo, string nombreTabla)//metodo cargar combo box
        {
            DataTable tabla = consultarSql("select * from " + nombreTabla + " order by 2");
            combo.DataSource = tabla;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;//me desailita el escribir en el cmbobox
        }
        //recibe un string que es la sentencia SQL y me devuelve una tabla cargada con esa sentencia
        private DataTable consultarSql(string consultaSql)//me devuelve la consulta como un datatable
        {
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;//dice q es tipo texto 
            comando.CommandText = consultaSql;

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();
            return tabla;

        }
        private void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cboTipo.SelectedIndex = -1;
            txtPrecio.Text = "";
        }

        private void habilitar(bool x)
        {
            txtCodigo.Enabled = x;
            txtNombre.Enabled = x;
            cboTipo.Enabled = x;
            txtPrecio.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnGuardar.Enabled = x;
            btnCancelar.Enabled = x;
            btnBorrar.Enabled = !x;
            lstJoyas.Enabled = !x;

        }
        private bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar un codigo.");
                txtCodigo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del articulo.");
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Debe ingresar el precio.");
                txtPrecio.Focus();
                return false;
            }
            else

                return true;
        }





        public frmJoyas()
        {
            InitializeComponent();
        }

        private void frmJoyas_Load(object sender, EventArgs e)
        {
            cargarCombo(cboTipo,"Tipos");
            cargarLista(lstJoyas, "Joyas");
            habilitar(false);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validarCampos())
            {
                Joya j = new Joya();
                j.pCodigo = Convert.ToInt32(txtCodigo.Text);
                j.pNombre = txtNombre.Text;
                j.pPrecio = Convert.ToDouble(txtPrecio.Text);
                j.pTipo = cboTipo.SelectedIndex;

                if (nuevo)
                {
                    string insertSql = "INSERT INTO Joyas VALUES (" + j.pCodigo + ",'" + j.pNombre + "'," + j.pTipo + "," + j.pPrecio + ")";
                    actualizarSql(insertSql);
                    cargarLista(lstJoyas, "Joyas");
                }
                else
                {
                    string updateSql = "UPDATE Joyas SET codigo= '" + j.pCodigo + "'," + "nombre= '" + j.pNombre + "'," + "tipo= " + j.pTipo + "," + "precio= " + j.pPrecio + " WHERE codigo=" + j.pCodigo;
                    actualizarSql(updateSql);
                    cargarLista(lstJoyas, "Joyas");
                }



                habilitar(false);
                limpiar();
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //mensaje que le pregunta al usuario si desea salir
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
            "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitar(true);
            nuevo = true;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            nuevo = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string deleteSql = "DELETE FROM Joyas WHERE codigo = " + lstJoyas.SelectedValue.ToString();
            actualizarSql(deleteSql);
            cargarLista(lstJoyas, "Joyas");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitar(false);
            limpiar();
        }
    }
}
