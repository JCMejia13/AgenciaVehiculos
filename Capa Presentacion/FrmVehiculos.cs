using Capa_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmVehiculos : Form
    {
        public FrmVehiculos()
        {
            InitializeComponent();
        }

        public void mtdMostrar()
        {
            CD_Vehiculos dataAccess = new CD_Vehiculos();
            DataTable tblmostrar = dataAccess.MtMostrar();
            dgvVehiculo.DataSource = tblmostrar;
        }

        public void mtdEliminar()
        {
            CD_Vehiculos classDatos = new CD_Vehiculos();
         

            try
            {

                classDatos.MtdEliminar(int.Parse(txtID.Text));
                MessageBox.Show("El cliente se eliminó con éxito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtdMostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void mtdAgregar()
        {
            CD_Vehiculos cD_Vehiculos = new CD_Vehiculos();
            try
            {
                cD_Vehiculos.MtdAgregar(txtMarca.Text,txtModelo.Text,int.Parse(txtAño.Text),double.Parse(txtPrecio.Text),txtEstado.Text);
                MessageBox.Show("El cliente se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtdMostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void mtdActualizar()
        {
            CD_Vehiculos cD_Vehiculos = new CD_Vehiculos();



            try
            {
                cD_Vehiculos.MtdActualizar(int.Parse(txtID.Text), txtMarca.Text, txtModelo.Text, int.Parse(txtAño.Text), double.Parse(txtPrecio.Text), txtEstado.Text);
                MessageBox.Show("El cliente se actualizo con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtdMostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void mtdBuscar()
        {
           
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            mtdMostrar();
        }

        private void dgvComercial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvVehiculo.SelectedCells[0].Value.ToString();
            txtMarca.Text = dgvVehiculo.SelectedCells[1].Value.ToString();
            txtModelo.Text = dgvVehiculo.SelectedCells[2].Value.ToString();
            txtAño.Text = dgvVehiculo.SelectedCells[3].Value.ToString();
            txtPrecio.Text = dgvVehiculo.SelectedCells[4].Value.ToString();
            txtEstado.Text = dgvVehiculo.SelectedCells[5].Value.ToString();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            mtdAgregar();
            mtdMostrar();

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            mtdActualizar();
            mtdMostrar();


        }

        private void btn4_Click(object sender, EventArgs e)
        {
            mtdEliminar();
            mtdMostrar();

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtAño.Text = "";
            txtPrecio.Text = "";
            txtEstado.Text = "";

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
