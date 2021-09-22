using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ABMPersonas
{
    public partial class frmPersona : Form
    {

        bool nuevo = false;
        const int tam = 100;
        Persona[] aPersona = new Persona[tam];
        List<Persona> lPersona = new List<Persona>(); //Lista...
        SqlDataReader lector;
        int c;

        //Pertenecen a SqlClient - DataTable lo toma de Data
        //SqlConnection conexion = new SqlConnection(@"Data Source=138.99.7.66;Initial Catalog=TUPPI;User ID=usrTUP;Password=1298@TuP");
        SqlConnection conexion = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True");
        //usar el comando a traves de esta conexion
        SqlCommand comando = new SqlCommand();
        //ejecutar el select
        DataTable tabla = new DataTable();
        //Recibir los datos que haga en el query
      
        public frmPersona()
        {
            InitializeComponent();
        }

        private void frmPersona_Load(object sender, EventArgs e)
        {
            habilitar(false);

            //Para conectar con la base de datos
            //conexion.ConnectionString = @"Data Source=IDEAPAD-L340\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True";
            //conexion.ConnectionString = @"Data Source=localhost;Initial Catalog=TUPPI;Integrated Security=True";


            //conexion.Open();

            //comando.Connection = conexion;
            ////Utiliza la conexion que acabas de abrir
            //comando.CommandType = CommandType.Text;
            //comando.CommandText = "Select * from tipo_documento";
            ////Consulta DML
            //tabla.Load(comando.ExecuteReader());
            ////Con select Reader, Con insert, update, delete NonQuery
            ////tabla.Load(---); Cargando la tabla

            //conexion.Close();

            //cboTipoDocumento.DataSource = tabla;
            ////Para que ese combobox muestre todos los datos de la tabla
            //cboTipoDocumento.DisplayMember = "n_tipo_documento";
            ////Para que muestre solo es campo
            //cboTipoDocumento.ValueMember = "id_tipo_documento";
            ////El identificador/valor/pk de lo que muestra

            ////tabla.Reset();

            //tabla = new DataTable();

            //conexion.Open();

            //comando.Connection = conexion;
            //comando.CommandType = CommandType.Text;
            //comando.CommandText = "Select * from estado_civil";
            //tabla.Load(comando.ExecuteReader());

            //conexion.Close();

            //cboEstadoCivil.DataSource = tabla;
            //cboEstadoCivil.DisplayMember = "n_estado_civil";
            //cboEstadoCivil.ValueMember = "id_estado_civil";

            this.cargarCombo(cboTipoDocumento, "tipo_documento");
            this.cargarCombo(cboEstadoCivil, "estado_civil");
            //lstPersonas.DataSource = consultarTabla("personas");
            //lstPersonas.DisplayMember = "apellido";
            this.CargarLista(lstPersonas, "personas");
            grdPersonas.DataSource = consultarTabla("personas");
            //this.cargarGrilla(grdPersonas, "personas");

        }

        private void cargarGrilla(DataGridView grilla, string nombreTable)
        {
            //DataTable tabla = 
        }

        private void CargarLista(ListBox lista, string nombreTabla)
        {
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from " + nombreTabla;
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Persona p = new Persona();
                if (!lector.IsDBNull(0))
                {
                    p.pApellido = lector.GetString(0);
                }
                if (!lector.IsDBNull(1))
                    p.pNombres = lector.GetString(1);
                if (!lector.IsDBNull(2))
                    p.pTipoDocumento = lector.GetInt32(2);
                if (!lector.IsDBNull(3))
                    p.pDocumento = lector.GetInt32(3);
                if (!lector.IsDBNull(4))
                    p.pEstadoCivil = lector.GetInt32(4);
                if (!lector.IsDBNull(5))
                    p.pSexo = lector.GetInt32(5);
                if (!lector.IsDBNull(6))
                    p.pFallecio = lector.GetBoolean(6);

                aPersona[c] = p; //Arreglo
                //lPersona.Add(p); //Lista
                c++;
            }
            lector.Close();
            //DataTable tabla = new DataTable();
            //tabla.Load(comando.ExecuteReader());

            conexion.Close();

            lista.Items.Clear();
            for (int i = 0; i < c; i++)
            {
                lista.Items.Add(aPersona[i].ToString());
            }
            lista.SelectedIndex = 0;
            //grdPersonas.DataSource = aPersona;
        }

        private void cargarCombo(ComboBox componente, string nombreTabla)
        {
            //conexion.ConnectionString = @"Data Source=IDEAPAD-L340\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True";

            DataTable tabla = consultarTabla(nombreTabla);
            componente.DataSource = tabla;
            componente.ValueMember = tabla.Columns[0].ColumnName;
            componente.DisplayMember = tabla.Columns[1].ColumnName;

            //if (tabla.Columns[0].DataType != typeof(System.Int32))
            //{
            //    componente.ValueMember = tabla.Columns[0].ColumnName;
            //    componente.DisplayMember = tabla.Columns[1].ColumnName;
            //}
            //else
            //{
            //    componente.ValueMember = tabla.Columns[1].ColumnName;
            //    componente.DisplayMember = tabla.Columns[0].ColumnName;
            //}
        }

        private DataTable consultarTabla(string nombreTabla)
        {
            conexion.Open();

            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from " + nombreTabla;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return tabla;
        }

        private void habilitar(bool x)
        {
            txtApellido.Enabled = x;
            txtNombres.Enabled = x;
            cboTipoDocumento.Enabled = x;
            txtDocumento.Enabled = x;
            cboEstadoCivil.Enabled = x;
            rbtFemenino.Enabled = x;
            rbtMasculino.Enabled = x;
            chkFallecio.Enabled = x;
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnSalir.Enabled = !x;
            lstPersonas.Enabled = !x;
        }

        private void limpiar()
        {
            txtApellido.Text = "";
            txtNombres.Text = "";
            cboTipoDocumento.SelectedIndex = -1;
            txtDocumento.Text = "";
            cboEstadoCivil.SelectedIndex = -1;
            rbtFemenino.Checked = false;
            rbtMasculino.Checked = false;
            chkFallecio.Checked = false;
        }
      
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            habilitar(true);
            limpiar();
            txtApellido.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            habilitar(true);
            cboTipoDocumento.Enabled = false;
            txtDocumento.Enabled = false;
            txtApellido.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de borrar esta persona ?",
                "BORRANDO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //consultaSql = "Delete from personas " +
                //                  " where documento = " + aPersona[lstPersonas.SelectedIndex].pDocumento;
                consultaSql = "Delete from personas " +
                                  " where documento = " + lPersona[lstPersonas.SelectedIndex].pDocumento;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = consultaSql;
                comando.ExecuteNonQuery();

                conexion.Close();

                limpiar();
                habilitar(false);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(false);
            nuevo = false;
        }

        private bool validar()
        {
            if (txtApellido.Text == "")
            {
                MessageBox.Show("Debe ingresar un Apellido.");
                txtApellido.Focus();
                return false;
            }

            if (txtNombres.Text == "")
            {
                MessageBox.Show("Debe ingresar al menos un nombre.");
                txtNombres.Focus();
                return false;
            }

            if (cboEstadoCivil.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un Estado Civil.");
                cboEstadoCivil.Focus();
                return false;
            }

            if (txtDocumento.Text == "")
            {
                MessageBox.Show("Debe ingresar su Documento.");
                txtDocumento.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtDocumento.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe ingresar valores numericos.");
                    txtDocumento.Focus();
                    return false;
                }
            }

            if (cboTipoDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de documento.");
                cboTipoDocumento.Focus();
                return false;
            }

            if (!rbtMasculino.Checked && !rbtFemenino.Checked)
            {
                MessageBox.Show("Seleccione un sexo.");
                rbtFemenino.Focus();
                return false;
            }

            return true;            
        }

        string consultaSql = "";

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                Persona p = new Persona();
                //Crear una persona creada y cargada para mandar a
                //la base de datos
                p.pApellido = txtApellido.Text;
                p.pNombres = txtNombres.Text;
                p.pTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                p.pDocumento = Convert.ToInt32(txtDocumento.Text);
                p.pEstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                if (rbtFemenino.Checked)
                {
                    p.pSexo = 1;
                } 
                else
                {
                    p.pSexo = 2;
                }
                p.pFallecio = chkFallecio.Checked;
                //if (chkFallecio.Checked)
                //{
                //    p.pFallecio = 1;
                //}
                //else
                //{
                //    p.pFallecio = 0;
                //}

                //insert o update
                if (nuevo) //es lo mismo a (nuevo == true)
                {
                    //insert
                    consultaSql = "insert into personas(apellido, nombres, tipo_documento, documento, estado_civil, sexo, fallecio) values ('" +
                                                       p.pApellido + "','" +
                                                       p.pNombres + "'," +
                                                       p.pTipoDocumento + "," +
                                                       p.pDocumento + "," +
                                                       p.pEstadoCivil + "," +
                                                       p.pSexo + ",'" +
                                                       p.pFallecio + "'" +
                                                       ")";
                    conexion.Open();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consultaSql;
                    comando.ExecuteNonQuery();

                    conexion.Close();
                }
                else
                {
                    //update
                    consultaSql = "Update personas " +
                                  "set apellido = '" + p.pApellido + "'," +
                                  "nombres = '" + p.pNombres + "'," +
                                  "sexo = " + p.pSexo + "," +
                                  "fallecio = '" + p.pFallecio + "'," +
                                  "estado_civil = " + p.pEstadoCivil +
                                  " where documento = " + p.pDocumento;
                    conexion.Open();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consultaSql;
                    comando.ExecuteNonQuery();

                    conexion.Close();
                }


                habilitar(false);
                nuevo = false;

            }

            //tabla = new DataTable();

            //conexion.Open();

            //comando.Connection = conexion;
            //comando.CommandType = CommandType.Text;
            //comando.CommandText = "insert into personas(apellido,nombres,tipo_documento,documento,estado_civil,sexo,fallecio) " +
            //       "values(txtApellido.Text,txtNombres.Text,cboTipoDocumento.Text,txtDocumento.ToInt32())";
            //tabla.Load(comando.ExecuteReader());

            //conexion.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
                "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Close();
        }

        private void grdPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarCampos(lstPersonas.SelectedIndex);
        }

        private void cargarCampos(int posicion)
        {
            //Arreglo
            txtApellido.Text = aPersona[posicion].pApellido;
            txtNombres.Text = aPersona[posicion].pNombres;
            cboTipoDocumento.SelectedValue = aPersona[posicion].pTipoDocumento;
            cboEstadoCivil.SelectedValue = aPersona[posicion].pEstadoCivil;
            txtDocumento.Text = aPersona[posicion].pDocumento.ToString();
            if (aPersona[posicion].pSexo == 1)
            {
                rbtFemenino.Checked = true;
            }
            else
            {
                rbtMasculino.Checked = true;
            }
            chkFallecio.Checked = aPersona[posicion].pFallecio;

            //List
            //txtApellido.Text = lPersona[posicion].pApellido;
            //txtNombres.Text = lPersona[posicion].pNombres;
            //cboTipoDocumento.SelectedValue = lPersona[posicion].pTipoDocumento;
            //cboEstadoCivil.SelectedValue = lPersona[posicion].pEstadoCivil;
            //txtDocumento.Text = lPersona[posicion].pDocumento.ToString();
            //if (lPersona[posicion].pSexo == 1)
            //{
            //    rbtFemenino.Checked = true;
            //}
            //else
            //{
            //    rbtMasculino.Checked = true;
            //}
            //chkFallecio.Checked = lPersona[posicion].pFallecio;
        }
    }
}
