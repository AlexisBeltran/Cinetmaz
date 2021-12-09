using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Negocio;

namespace Acceso_a_Datos
{
    public partial class AgregarUsuario : Form
    {
        Modelo CapaModelo = new Modelo();
        public AgregarUsuario()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text != "" && txt_apellidopaterno.Text != "" && txt_apellidomaterno.Text != "" && txt_edad.Text != "" && txt_nombreUsuario.Text != "" && txt_contraseña.Text != "" && txt_confirmarContra.Text != "")
            {
                if (txt_contraseña.Text == txt_confirmarContra.Text)
                {
                    CapaModelo.agregarusuario(txt_nombreUsuario.Text, txt_nombre.Text, txt_apellidopaterno.Text, txt_apellidomaterno.Text, Convert.ToInt32(txt_edad.Text), txt_contraseña.Text);
                    MessageBox.Show("Agregado Correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos");
            }   
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
