using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos ObjectoCN = new CN_Productos();
        private string idPro = null;
        private bool editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            CN_Productos Objecto = new CN_Productos();
            dataGridView1.DataSource = Objecto.MostrarProd();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnA_Click(object sender, EventArgs e)
        {
           
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtSctok.Text = dataGridView1.CurrentRow.Cells["sctok"].Value.ToString();
                idPro = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Por favor seleccione el producto que desea editar");
            }
        }

        private void limpiar()
        {
            txtDesc.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtNombre.Clear();
            txtSctok.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idPro = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                ObjectoCN.EliminarMod(idPro);
                MessageBox.Show("El producto ha sido eliminado");
                MostrarDatos();
                limpiar();

            }
            else
            {
                MessageBox.Show("Por favor seleccione el producto que desea eliminar");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btng_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    ObjectoCN.InsertarMod(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtSctok.Text);
                    MessageBox.Show("Se guardo el producto correctamente");
                    MostrarDatos();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR al guardar el producto" + ex);
                }
            }

            if (editar == true)
            {
                try
                {
                    ObjectoCN.EditarMod(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtSctok.Text, idPro);
                    MessageBox.Show("Se edito el prodcuto correctamente");
                    MostrarDatos();
                    limpiar();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR al editar el producto" + ex);
                }
            }
        }
    }


}