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
using Common.Cache;
using Common.DTO;


namespace Acceso_a_Datos
{
    public partial class Login : Form
    {
        Modelo CapaNegocio = new Modelo();
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txt_usuario_Enter(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "Usuario")
            {
                txt_usuario.Text = "";
                txt_usuario.ForeColor = Color.LightGray;
            }
        }

        private void txt_contraseña_Enter(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "Contraseña")
            {
                txt_contraseña.Text = "";
                txt_contraseña.UseSystemPasswordChar = true;
                txt_contraseña.ForeColor = Color.LightGray;
            }
        }

        private void txt_usuario_Leave(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "")
            {
                txt_usuario.Text = "Usuario";
                txt_usuario.ForeColor = Color.DarkGray;
            }
        }

        private void txt_contraseña_Leave(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "")
            {
                txt_contraseña.Text = "Contraseña";
                txt_contraseña.UseSystemPasswordChar = false;
                txt_contraseña.ForeColor = Color.DarkGray;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_acceder_Click(object sender, EventArgs e)
        {
            Guardar();
        }
      
        private void Guardar()
        {
            if ((txt_usuario.Text != "Usuario" && txt_usuario.TextLength > 2) || txt_contraseña.Text != "Contraseña")
            {
                var ValidarUsuario = CapaNegocio.Usuario(txt_usuario.Text, txt_contraseña.Text);
                if (ValidarUsuario == true)
                {
                    this.Hide(); //Oculta Login
                    if (Usuario.nombre_usuario == "admin")
                    {
                        Menu menu = new Menu();
                        MessageBox.Show("Bienvenido " + Usuario.nombre_completo + " " + Usuario.apepaterno_usuario);
                        menu.Show();
                        menu.FormClosed += SalirUsuario;   //handler 
                    }
                    else
                    {
                        Users usuario_form = new Users();
                        MessageBox.Show("Bienvenido " + Usuario.nombre_completo + " " + Usuario.apepaterno_usuario);
                        usuario_form.Show();
                        usuario_form.FormClosed += SalirUsuario; //handler
                    }
                            
                   
                }
                else
                {
                    MensajeError("Usuario y/o Contraseña Incorrecto");
                    txt_contraseña.Text = "Contraseña";
                    txt_contraseña.UseSystemPasswordChar = false;
                    txt_contraseña.Focus();
                }
            }
            else
            {
                MensajeError("Ingresa Usuario y/o Contraseña");
            }
        }
        private void MensajeError(string Msg)
        {
            lblErrorMensaje.Text = "     " + Msg;
            lblErrorMensaje.Visible = true;
        }
        private void SalirUsuario(object sender, FormClosedEventArgs e) //Investigar FormCloseEvent
        {
            txt_contraseña.Text = "Contraseña";
            txt_contraseña.UseSystemPasswordChar = false;
            txt_contraseña.ForeColor = Color.DimGray;
            txt_usuario.Text = "Usuario";
            lblErrorMensaje.Visible = false;
            txt_usuario.ForeColor = Color.DimGray;
            this.Show();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AgregarUsuario AgregarUsuario = new AgregarUsuario();
            AgregarUsuario.ShowDialog();

        }

     
    }
}
