using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//1w1 – 112658 – Giampaoli – Ezequiel Maximiliano

namespace TUP_PI_EF_JJOOI
{
    public partial class frmCompetidores : Form
    {
        bool nuevo = false;
        List<Competidor> lCompetidor = new List<Competidor>();

        SqlConnection conexion = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=JJOO;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;

        public frmCompetidores()
        {
            InitializeComponent();
        }

        private void frmCompetidores_Load(object sender, EventArgs e)
        {
            habilitar(false);

            this.CargarCombo(cboDisciplina, "Disciplinas");
            this.CargarLista(lstCompetidores, "Competidores");
        }

        private void CargarLista(ListBox lista, string nombreTabla)
        {
            lCompetidor.Clear();
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            lector = comando.ExecuteReader();
            while (lector.Read() == true)
            {
                Competidor c = new Competidor();
                if (!lector.IsDBNull(0))
                    c.pNumero = lector.GetInt32(0);
                if (!lector.IsDBNull(1))
                    c.pNombre = lector.GetString(1);
                if (!lector.IsDBNull(2))
                    c.pDisciplina = lector.GetInt32(2);
                if (!lector.IsDBNull(3))
                    c.pSexo = lector.GetString(3);
                if (!lector.IsDBNull(4))
                    c.pFechaNacimiento = lector.GetDateTime(4);

                lCompetidor.Add(c);
            }
            lector.Close();
            conexion.Close();

            lista.Items.Clear();
            for (int i = 0; i < lCompetidor.Count; i++)
            {
                lista.Items.Add(lCompetidor[i].ToString());
            }
            lista.SelectedIndex = 0;
        }

        private void CargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
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
            txtNombre.Enabled = x;
            txtNumero.Enabled = x;
            cboDisciplina.Enabled = x;
            rbtFemenino.Enabled = x;
            rbtMasculino.Enabled = x;
            btnGuardar.Enabled = x;
            btnCancelar.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
            btnSalir.Enabled = !x;
            lstCompetidores.Enabled = !x;
            //dtpFechaNacimiento.Enabled = x;
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            txtNumero.Text = "";
            cboDisciplina.SelectedIndex = -1;
            rbtFemenino.Checked = false;
            rbtMasculino.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            limpiar();
            habilitar(true);
            txtNumero.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitar(true);
            txtNumero.Enabled = false;
            txtNombre.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de borrar esta persona ?",
                "BORRANDO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string consultaSql = "DELETE FROM Competidores WHERE numero=" + lCompetidor[lstCompetidores.SelectedIndex].pNumero;
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = consultaSql;
                comando.ExecuteNonQuery();
                conexion.Close();

                this.CargarLista(lstCompetidores, "Competidores");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitar(false);
            nuevo = false;
        }

        private bool ValidarCampos()
        {
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string consultaSql = "";

            if (ValidarCampos())
            {
                Competidor c = new Competidor();
                c.pNumero = int.Parse(txtNumero.Text);
                c.pNombre = txtNombre.Text;
                c.pDisciplina = Convert.ToInt32(cboDisciplina.SelectedValue);
                c.pFechaNacimiento = dtpFechaNacimiento.Value;
                if (rbtFemenino.Checked)
                    c.pSexo = "F";
                else
                    c.pSexo = "M";

                if (nuevo)
                {
                    //Insert
                    consultaSql = "INSERT INTO Competidores (numero, nombre, disciplina, fechaNacimiento, sexo) VALUES ("
                                                      + c.pNumero + ",'"
                                                      + c.pNombre + "',"
                                                      + c.pDisciplina + ",'"
                                                      + c.pFechaNacimiento + "','"
                                                      + c.pSexo + "')";
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consultaSql;
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                else
                {
                    //Update
                    consultaSql = "UPDATE Competidores SET nombre='" + c.pNombre + "',"
                                                    + " disciplina=" + c.pDisciplina + ","
                                                    + " sexo='" + c.pSexo + "',"
                                                    + " fechaNacimiento='" + c.pFechaNacimiento
                                                    + "' WHERE documento=" + c.pNumero;
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consultaSql;
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }

                this.CargarLista(lstCompetidores, "Competidores");
                //this.CargarGrilla(grdPersonas, "personas");
                habilitar(false);
                nuevo = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de abandonar la aplicación ?",
                "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }

        private void lstCompetidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarCampos(lstCompetidores.SelectedIndex);
        }

        private void CargarCampos(int posicion)
        {
            txtNumero.Text = lCompetidor[posicion].pNumero.ToString();
            txtNombre.Text = lCompetidor[posicion].pNombre;
            cboDisciplina.SelectedValue = lCompetidor[posicion].pDisciplina;
            if (lCompetidor[posicion].pSexo == "F")
                rbtFemenino.Checked = true;
            else
                rbtMasculino.Checked = true;
            dtpFechaNacimiento.Value = lCompetidor[posicion].pFechaNacimiento;
        }
    }
}
