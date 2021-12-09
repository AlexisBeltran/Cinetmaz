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
using Common.DTO;

namespace Acceso_a_Datos
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Users_Load(object sender, EventArgs e)
        {
            CargarUsuario();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirFormulario<EditarPerfil>();
        }
        private void bt_reservar_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Reservacion>();

        }
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformulario.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
                                                                                    //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformulario.Controls.Add(formulario);
                panelformulario.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void pb_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Cargar posición y tamaño antes de maximizar para restaurar.
        int Lx, Ly;
        int Sw, Sh;

        private void pb_maximizar_Click(object sender, EventArgs e)
        {
            Lx = this.Location.X;
            Ly = this.Location.Y;
            Sw = this.Size.Width;
            Sh = this.Size.Height;

            pb_maximizar.Visible = false;
            pb_restaurarImagen.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size; //Tamaño sera igual al tamaño de la pantalla principal.
            this.Location = Screen.PrimaryScreen.WorkingArea.Location; //La posición por defecto de la pantalla principal.
        }
        private void pb_restaurarImagen_Click(object sender, EventArgs e)
        {
            pb_maximizar.Visible = true;
            pb_restaurarImagen.Visible = false;
            this.Size = new Size(Sw, Sh);
            this.Location = new Point(Lx, Ly);
        }

        private void pb_SesionCerrada_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirFormulario<EditarPerfil>();
        }

        private void pb_cerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void CargarUsuario()
        {
            lbl_datosusuario.Text = Usuario.nombre_completo + " " + Usuario.apepaterno_usuario + " ";
            lbl_edad.Text = "Edad: " + Usuario.edad_usuario.ToString();
        }
    }
}
