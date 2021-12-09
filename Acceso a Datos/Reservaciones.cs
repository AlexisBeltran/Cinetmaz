using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Acceso_a_Datos
{
    public partial class Reservaciones : Form 
    {
        Modelo CapaNegocio = new Modelo();
        int cveReservacion;
        public Reservaciones()
        {
            InitializeComponent();
        }
        private void Clasificacion_Load(object sender, EventArgs e)
        {
            mostrarClasificacion();
        }

        public void mostrarClasificacion()
        {
            dataGridView1.DataSource = CapaNegocio.MostrarReservacion();
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cveReservacion = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txt_nombreUsuario.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_apellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_pelicula.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_numeroAsiento.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_asiento.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            CapaNegocio.EliminarReservacion(cveReservacion);
            MessageBox.Show("Eliminador Correctamente");
            Limpiar(this);
            mostrarClasificacion(); //Reservacion
        }
        void Limpiar(Form formulario)
        {
            //Checar todos los textbox del formulario
            foreach (Control item in formulario.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
