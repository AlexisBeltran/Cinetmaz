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
    public partial class Pelicula : Form
    {
        Modelo Consulta = new Modelo();
        int cve_pelicula;
        public Pelicula()
        {
            InitializeComponent();
        }
        private void Pelicula_Load(object sender, EventArgs e)
        {
            MostrarSala();
            MostrarPeliculas();
        }
        void MostrarSala()
        {
            cb_Sala.DataSource = Consulta.MostrarSalaCB();
            cb_Sala.DisplayMember = "nombre_sala";
            cb_Sala.ValueMember = "cve_sala";
        }
        void MostrarPeliculas()
        {
            dataGridView1.DataSource = Consulta.MostrarPeliculaDG();
            dataGridView1.Columns[0].Visible = false;
        }

        void Limpiar()
        {
            txt_nombre.Clear();
        }
            
            
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            AgregarSala Sala = new AgregarSala();
            Sala.ShowDialog();
            MostrarSala();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cve_pelicula = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txt_nombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cb_Sala.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "")
            {
                Consulta.insertarPelicula(txt_nombre.Text, (int)cb_Sala.SelectedValue);
                MessageBox.Show("Insertado Correctamente");
                MostrarPeliculas();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Rellene el campo");
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "")
            {
                Consulta.ActualizarPelicula(txt_nombre.Text, (int)cb_Sala.SelectedValue, cve_pelicula);
                MessageBox.Show("Actualizado Correctamente");
                MostrarPeliculas();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Rellene el campo");
            }
        }

        private void btn_eliminar_Click_1(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "")
            {
                Consulta.EliminarPelicula(cve_pelicula);
                MessageBox.Show("Eliminado Correctamente");
                MostrarPeliculas();
                Limpiar();
            }
            else
            {

            }
        }
    }
}
