using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.DTO;
using Negocio;

namespace Acceso_a_Datos
{
    public partial class MostrarUsuarios : Form
    {
        Modelo Consulta = new Modelo();

        int Cve_Usuario;
        public MostrarUsuarios()
        {
            InitializeComponent();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Consulta.ElimanarUsuario(Cve_Usuario);
            Limpiar(this);
            MostrarUsuario();
        }

        private void MostrarUsuarios_Load(object sender, EventArgs e)
        {
            MostrarUsuario();
        }
        void MostrarUsuario()
        {
            dataGridView1.DataSource = Consulta.MostrarUsuarios();
            dataGridView1.Columns[0].Visible = false;
        }

        void Limpiar(Form formulario )
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cve_Usuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txt_nombreUsuario.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_nombreCompleto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_apellido.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_edad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
