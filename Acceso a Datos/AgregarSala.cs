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
    public partial class AgregarSala : Form
    {
        Modelo Consulta = new Modelo();
        int CveSala;
        public AgregarSala()
        {
            InitializeComponent();
        }

        private void AgregarSala_Load(object sender, EventArgs e)
        {
            Clasificacion();
            MostrarSala();
        }
        void Clasificacion()
        {
            cb_clasificacion.DataSource = Consulta.Clasificacion();
            cb_clasificacion.DisplayMember = "tipo_clsificacion";
            cb_clasificacion.ValueMember = "cve_clasificacion";
        }
        void MostrarSala()
        {
            dataGridView1.DataSource = Consulta.MostrarSala();
            dataGridView1.Columns[0].Visible = false;
        }
        private void pb_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Limpiar()
        {
            txt_nobreSala.Clear();
            txt_capacidadSala.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CveSala = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txt_nobreSala.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_capacidadSala.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cb_clasificacion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void Btn_agregar_Click(object sender, EventArgs e)
        {
            if (txt_nobreSala.Text != "" && txt_capacidadSala.Text != "")
            {
                Consulta.InsertarSala(txt_nobreSala.Text, Convert.ToInt32(txt_capacidadSala.Text), (int)cb_clasificacion.SelectedValue);
                MessageBox.Show("Agregado Corectamente");
                MostrarSala();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Rellena todos los campos");
            }
            
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (txt_nobreSala.Text != "" && txt_capacidadSala.Text != "")
            {
                Consulta.ActualizarSala(txt_nobreSala.Text, Convert.ToInt32(txt_capacidadSala.Text), (int)cb_clasificacion.SelectedValue, CveSala);
                MessageBox.Show("Actualizado Correctamente");
                MostrarSala();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Rellena todos los campos");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_nobreSala.Text != "" && txt_capacidadSala.Text != "")
            {
                Consulta.EliminarSala(CveSala);
                MessageBox.Show("Eliminado Correctamente");
                MostrarSala();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Rellena todos los campos");
            }
        }
    }
}
