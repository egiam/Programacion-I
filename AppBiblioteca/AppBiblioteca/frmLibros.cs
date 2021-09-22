using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBiblioteca
{
    public partial class frmLibros : Form
    {
        public frmLibros()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtISBN.Text = "";
            txtTitulo.Clear();
            txtPaginas.Text = string.Empty;
            cboAutor.SelectedIndex = -1;
            txtISBN.Focus();
        }
    }
}
