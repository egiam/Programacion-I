using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data.OleDb;

namespace ABMPersonas
{
    public partial class frmPersona : Form
    {
        bool nuevo = false;
        //const int tam = 10;
        //Persona[] aPersona = new Persona[tam]; // arreglo estatico para tam Personas

        List<Persona> lPersona = new List<Persona>(); // lista dinamica para n Personas

        int c;

        // Cadena de conexion para SQL Server REMOTO con proveedor SqlClient
        SqlConnection conexion = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TUPPI;Integrated Security=True");
        //SqlConnection conexion = new SqlConnection(@"Data Source=138.99.7.66;Initial Catalog=TUPPI;User ID=usrTUP;Password=1298@TuP");
        SqlCommand comando = new SqlCommand();
        //OleDbConnection conexion = new OleDbConnection();
        //OleDbCommand comando = new OleDbCommand();
        SqlDataReader lector;

        public frmPersona()
        {
            InitializeComponent();
        }

        private void frmPersona_Load(object sender, EventArgs e)
        {
            habilitar(false);
            // Cadena de conexion para SQL Server con proveedor SqlClient
            //conexion.ConnectionString = @"Data Source=CX-OSCAR;Initial Catalog=TUPPI;Integrated Security=True";
            //conexion.ConnectionString = @"Data Source = localhost; Initial Catalog = TUPPI; Integrated Security = True";

            // Cadena de conexion para SQL Server con proveedor OleDb
            //conexion.ConnectionString = @"Provider =SQLNCLI11;Data Source=localhost;Integrated Security=SSPI;Initial Catalog=TUPPI";

            // Cadena de conexion para ACCESS con proveedor OleDb
            //conexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Oscar\UTN\ProgramacionI\2021\1Cuatrimestre\ABMPersonas\DBF_ABM_alumno_personas.mdb";
            
            //**************** Programación original para cargar los 2 combos del form ***********
            //conexion.Open();

            //comando.Connection = conexion;
            //comando.CommandType = CommandType.Text;
            //comando.CommandText = "SELECT * FROM tipo_documento";

            //DataTable tabla = new DataTable();
            //tabla.Load(comando.ExecuteReader());

            //conexion.Close();

            //cboTipoDocumento.DataSource = tabla;
            //cboTipoDocumento.DisplayMember = "n_tipo_documento";
            //cboTipoDocumento.ValueMember = "id_tipo_documento";

            //tabla = new DataTable();

            //conexion.Open();
            //comando.Connection = conexion;
            //comando.CommandType = CommandType.Text;
            //comando.CommandText = "SELECT * FROM estado_civil";
            //tabla.Load(comando.ExecuteReader());
            //conexion.Close();

            //cboEstadoCivil.DataSource = tabla;
            //cboEstadoCivil.DisplayMember = "n_estado_civil";
            //cboEstadoCivil.ValueMember = "id_estado_civil";
            //****************************************************************************************

            this.cargarCombo(cboTipoDocumento, "tipo_documento");
            this.cargarCombo(cboEstadoCivil, "estado_civil");
            //lstPersonas.DataSource = consultarTabla("personas");
            //lstPersonas.DisplayMember = "apellido";
            this.cargarLista(lstPersonas, "personas");

            //llena un componente DataGridView con un DataTable como ejemplo para TP de Laboratorio
            //grdPersonas.DataSource = consultarSQL("SELECT p.apellido as Apellido, t.n_tipo_documento as TipoDoc FROM personas p, tipo_documento t WHERE p.tipo_documento=t.id_tipo_documento" );     
            this.cargarGrilla(grdPersonas, "personas");
        }

        private void cargarGrilla(DataGridView grilla, string nombreTabla)
        {
            DataTable tabla = consultarSQL("SELECT distinct p.apellido, p.nombres, t.n_tipo_documento, p.documento  " +
                                             "FROM personas p, tipo_documento t " +
                                            "WHERE p.tipo_documento=t.id_tipo_documento");
            grilla.Rows.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grilla.Rows.Add(tabla.Rows[i]["apellido"], tabla.Rows[i][1], tabla.Rows[i][2], tabla.Rows[i]["documento"]);
            }

        }

        private void cargarLista(ListBox lista, string nombreTabla)
        {
            c = 0;
            lPersona.Clear();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            lector=comando.ExecuteReader();
            while (lector.Read()==true)
            {
                Persona p = new Persona();
                if(!lector.IsDBNull(0))
                    p.pApellido = lector.GetString(0);
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

                //aPersona[c] = p;
                lPersona.Add(p);
                c++;
            }
            lector.Close();
            conexion.Close();

            lista.Items.Clear();
            //for (int i = 0; i < c; i++)
            //{
            //    lista.Items.Add(aPersona[i].ToString());

            //}
            for (int i = 0; i < lPersona.Count; i++)
            {
                lista.Items.Add(lPersona[i].ToString());
            }
            lista.SelectedIndex = 0;
            
        }

        private void cargarCombo(ComboBox combo,string nombreTabla)
        {
            DataTable tabla = consultarTabla(nombreTabla);
            combo.DataSource = tabla;                               //Suponiendo que siempre llenamos un combo con una TABLA AUXILIAR
            combo.ValueMember = tabla.Columns[0].ColumnName;        //Donde el primer campo es la PK
            combo.DisplayMember = tabla.Columns[1].ColumnName;      // y el segundo campo el DESCRIPTOR
        }
        private DataTable consultarTabla(string nombreTabla)
        {
            DataTable tabla = new DataTable();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        private DataTable consultarSQL(string consultaSQL)
        {
            DataTable tabla = new DataTable();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = consultaSQL;
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
            habilitar(true);
            txtDocumento.Enabled = false;
            txtApellido.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de borrar esta persona ?",
                "BORRANDO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // Delete --> borramos el objeto seleccionado en la lista
                //string consultaSql = "DELETE FROM personas WHERE documento=" + aPersona[lstPersonas.SelectedIndex].pDocumento;
                string consultaSql = "DELETE FROM personas WHERE documento=" + lPersona[lstPersonas.SelectedIndex].pDocumento; 
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = consultaSql;
                comando.ExecuteNonQuery();
                conexion.Close();

                this.cargarLista(lstPersonas, "personas");
            }
                

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            limpiar();
            habilitar(false);
            nuevo = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string consultaSql = "";

            if (validarCampos())
            {
                Persona p = new Persona();
                p.pApellido = txtApellido.Text;
                p.pNombres = txtNombres.Text;
                p.pTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                p.pDocumento = int.Parse(txtDocumento.Text);
                p.pEstadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                if (rbtFemenino.Checked)
                    p.pSexo = 1;
                else
                    p.pSexo = 2;
                p.pFallecio = chkFallecio.Checked;

                if (nuevo) //(nuevo==true) es equivalente
                {

                    // VALIDAR QUE NO EXISTA LA PK !!!!!! (SI NO ES AUTOINCREMENTAL / IDENTITY)

                    // insert con sentencia SQL tradicional
                    //consultaSql = "INSERT INTO personas (apellido, nombres, tipo_documento, documento, estado_civil, sexo, fallecio) VALUES ('"
                    //                                  + p.pApellido + "','"
                    //                                  + p.pNombres + "',"
                    //                                  + p.pTipoDocumento + ","
                    //                                  + p.pDocumento + ","
                    //                                  + p.pEstadoCivil + ","
                    //                                  + p.pSexo + ",'"
                    //                                  + p.pFallecio + "')";
                    //conexion.Open();
                    //comando.Connection = conexion;
                    //comando.CommandType = CommandType.Text;
                    //comando.CommandText = consultaSql;
                    //comando.ExecuteNonQuery();
                    //conexion.Close();

                    // insert usando parámetros
                    consultaSql = "INSERT INTO personas (apellido, nombres, tipo_documento, documento, estado_civil, sexo, fallecio)" +
                                               " VALUES (@apellido,@nombres,@tipo_documento,@documento,@estado_civil,@sexo,@fallecio)";
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consultaSql;
                    comando.Parameters.AddWithValue("@apellido", p.pApellido);
                    comando.Parameters.AddWithValue("@nombres", p.pNombres);
                    comando.Parameters.AddWithValue("@tipo_documento", p.pTipoDocumento);
                    comando.Parameters.AddWithValue("@documento", p.pDocumento);
                    comando.Parameters.AddWithValue("@estado_civil", p.pEstadoCivil);
                    comando.Parameters.AddWithValue("@sexo", p.pSexo);
                    comando.Parameters.AddWithValue("@fallecio", p.pFallecio);
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    //lstPersonas.DataSource = consultarTabla("personas");
                }
                else
                {
                    // update con sentencia SQL tradicional
                    //consultaSql = "UPDATE personas SET apellido='" + p.pApellido + "',"
                    //                                + " nombres='" + p.pNombres + "',"
                    //                                + " tipo_documento=" + p.pTipoDocumento + ","
                    //                                + " estado_civil=" + p.pEstadoCivil + ","
                    //                                + " sexo=" + p.pSexo + ","
                    //                                + " fallecio='" + p.pFallecio + "'"
                    //                                + " WHERE documento=" + p.pDocumento;
                    //conexion.Open();
                    //comando.Connection = conexion;
                    //comando.CommandType = CommandType.Text;
                    //comando.CommandText = consultaSql;
                    //comando.ExecuteNonQuery();
                    //conexion.Close();

                    // UPDATE usando parámetros
                    consultaSql = "UPDATE personas SET apellido=@apellido," +
                                                       " nombres=@nombres," +
                                                       " tipo_documento=@tipo_documento," +
                                                       " estado_civil=@estado_civil," +
                                                       " sexo=@sexo," +
                                                       " fallecio=@fallecio" +
                                                       " WHERE documento=@documento";
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consultaSql;
                    comando.Parameters.AddWithValue("@apellido", p.pApellido);
                    comando.Parameters.AddWithValue("@nombres", p.pNombres);
                    comando.Parameters.AddWithValue("@tipo_documento", p.pTipoDocumento);
                    comando.Parameters.AddWithValue("@estado_civil", p.pEstadoCivil);
                    comando.Parameters.AddWithValue("@sexo", p.pSexo);
                    comando.Parameters.AddWithValue("@fallecio", p.pFallecio);
                    comando.Parameters.AddWithValue("@documento", p.pDocumento);                    
                    comando.ExecuteNonQuery();
                    conexion.Close();

                }

                this.cargarLista(lstPersonas, "personas");
                //this.cargarGrilla(grdPersonas, "personas");

                habilitar(false);
                nuevo = false;
            }
        }

        private bool validarCampos()
        {
            if (txtApellido.Text=="")
            {
                MessageBox.Show("Debe ingresar un apellido...");
                txtApellido.Focus();
                return false;
            }
            if (txtNombres.Text==string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre...");
                txtNombres.Focus();
                return false;
            }
            if (cboTipoDocumento.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar un tipo documento...");
                cboTipoDocumento.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDocumento.Text))
            {
                MessageBox.Show("Debe ingresar un numero de documento...");
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
                    MessageBox.Show("Debe ingresar valores numéricos...");
                    txtDocumento.Focus();
                    return false;
                }
            }
            if (cboEstadoCivil.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado civil...");
                cboEstadoCivil.Focus();
                return false;
            }
            if (!rbtMasculino.Checked && !rbtFemenino.Checked)
            {
                MessageBox.Show("Debe seleccionar un sexo...");
                rbtFemenino.Focus();
                return false;
            }

            return true;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
                "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }

        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarCampos(lstPersonas.SelectedIndex);
        }

        private void cargarCampos(int posicion)
        {
            // desde un arreglo
            //txtApellido.Text = aPersona[posicion].pApellido;
            //txtNombres.Text = aPersona[posicion].pNombres;
            //cboTipoDocumento.SelectedValue = aPersona[posicion].pTipoDocumento;
            //txtDocumento.Text = aPersona[posicion].pDocumento.ToString();
            //cboEstadoCivil.SelectedValue = aPersona[posicion].pEstadoCivil;
            //if (aPersona[posicion].pSexo == 1)
            //    rbtFemenino.Checked = true;
            //else
            //    rbtMasculino.Checked = true;
            //chkFallecio.Checked = aPersona[posicion].pFallecio;

            //desde un List
            txtApellido.Text = lPersona[posicion].pApellido;
            txtNombres.Text = lPersona[posicion].pNombres;
            cboTipoDocumento.SelectedValue = lPersona[posicion].pTipoDocumento;
            txtDocumento.Text = lPersona[posicion].pDocumento.ToString();
            cboEstadoCivil.SelectedValue = lPersona[posicion].pEstadoCivil;
            if (lPersona[posicion].pSexo == 1)
                rbtFemenino.Checked = true;
            else
                rbtMasculino.Checked = true;
            chkFallecio.Checked = lPersona[posicion].pFallecio;
        }

        private void grdPersonas_SelectionChanged(object sender, EventArgs e)
        {
            this.cargarCampos(grdPersonas.SelectedRows[0].Index);
        }

        private void grdPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
