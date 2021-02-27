using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuiroPizza.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var productosBL = new ProductoBL();
            var listadeProductos = productosBL.ObtenerProductos();

            listadeProductosBindingSource.DataSource = listadeProductos;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listadeProductosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listadeProductosBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
